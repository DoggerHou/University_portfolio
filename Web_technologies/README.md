# Web-технологии — учебный веб-проект

Учебный проект по дисциплине **«Web-технологии»**.  
Пять лабораторных работ последовательно развивают один и тот же сайт: от статической вёрстки до полноценного веб-приложения на Flask с БД, REST-API и авторизацией.

Тематика сайта — лендинг/витрина смартфонов iPhone с формой заказа и личным кабинетом.


## Структура проекта

```text
web_app/
  main.py             # точка входа Flask-приложения
  config.py           # конфигурация Flask и подключения к БД
  appdb.sqlite        # база sqlite (может пересоздаваться из SQL-скрипта)
  requirements.txt    # зависимости Python

  appiphnoe/          # пакет приложения
    __init__.py       # создание объекта Flask, регистрация blueprint'ов
    routes.py         # маршруты, view-функции, декораторы
    dbservice.py      # работа с БД, CRUD и авторизация
    utils.py          # вспомогательные функции
    appdb_script.sql  # скрипт создания таблиц

    templates/        # Jinja2-шаблоны страниц
      base.html
      index.html
      color.html
      whatnew.html
      order.html
      login.html
      register.html
      account.html

    static/
      css/            # стили
      js/             # скрипты (script.js, form-order.js, whatnew_animation.js, ...)
      img/            # изображения
```


---

## Фронтенд

### Шаблоны

- `base.html` — базовый шаблон:
  - шапка, меню навигации, подвал;
  - блоки `{% block content %}` и `{% block scriptjs %}`, которые переопределяются в дочерних страницах.
- Остальные страницы (`index.html`, `color.html`, `whatnew.html`, `order.html`, `login.html`, `register.html`, `account.html`) делают `extends "base.html"` и задают свой контент:
  - `index` — главная страница с описанием продукта;
  - `color` — выбор цвета/конфигурации;
  - `whatnew` — блок «что нового»;
  - `order` — форма заказа + список заявок;
  - `login` / `register` — формы авторизации;
  - `account` — личный кабинет пользователя.

Навигационное меню (`navmenu`, `navmenu_authorisation`) формируется в `routes.py` и передаётся в шаблоны, активный пункт подсвечивается.

### JavaScript

- `static/js/script.js`:
  - подсветка активного пункта меню;
  - hover-эффекты для элементов меню и телефонов;
  - привязка обработчиков событий к DOM-элементам.
- `static/js/whatnew_animation.js`:
  - разворачивание/сворачивание блоков текста по клику на заголовки новостей;
  - анимация и увеличение изображений в блоке «что нового».
- `static/js/form-order.js`:
  - перехват отправки формы заказа;
  - сбор данных полей (имя, фамилия, телефон, email);
  - отправка JSON на сервер в REST-endpoint `/api/contactrequest`;
  - обработка ответа: очистка формы, вывод статуса/ошибки без перезагрузки страницы.
- Используется `jquery-3.6.0.min.js` для более компактной работы с DOM.

---

## Бэкенд (Flask + SQLite)

### Конфигурация

- `config.py`:
  - настройки Flask (`SECRET_KEY`, имя cookie, параметры сессии);
  - путь к базе SQLite и строка подключения;
  - инициализация SQLAlchemy.
- `appiphnoe/__init__.py`:
  - создание объекта `Flask(__name__)`;
  - загрузка конфигурации;
  - инициализация БД;
  - регистрация маршрутов из `routes.py`.

### Маршруты и страницы (`routes.py`)

Основные view-функции:

- `GET /`, `/index` — главная страница.
- `GET /whatnew` — страница новостей.
- `GET /color` — страница выбора вариаций устройства.
- `GET /login`, `POST /login` — форма авторизации.
- `GET /register`, `POST /register` — регистрация пользователя.
- `GET /order` — страница с формой заказа и списком заявок  
  (защищена декоратором `@login_required`, доступна только авторизованным пользователям).
- `GET /account` — личный кабинет (данные текущего пользователя).

Маршруты возвращают `render_template(...)` с нужным шаблоном и переменными (меню, данные пользователя и т.д.).

---

## Работа с базой данных и авторизацией (`dbservice.py`)

Используется SQLite (файл `appdb.sqlite`) с таблицами, которые создаются из `appdb_script.sql` либо через ORM.

### Заявки (таблица `orderrequests`)

Функции для работы с заказами:

- `get_contact_req_all()` — получить все заявки.
- `get_contact_req_by_id(id)` — заявка по идентификатору.
- `get_contact_req_by_author(firstname)` — заявки по имени автора.
- `create_contact_req(json_data)` — добавить заявку из JSON-объекта.
- `update_contact_email_by_id(id, json_data)` — обновить email заявки.
- `delete_contact_req_by_id(id)` — удалить заявку.

### Пользователи и авторизация

Функции для работы с пользователями:

- `register_user(form_data)`:
  - проверка обязательных полей формы;
  - хеширование пароля через `bcrypt` (+ соль);
  - запись нового пользователя в БД;
  - при успехе — редирект на страницу логина.
- `login_user(form_data)`:
  - поиск пользователя по логину;
  - проверка пароля `bcrypt.checkpw(...)`;
  - установка данных в `session` (`user`, `userId`, `userMail`);
  - генерация cookie `AuthToken` и редирект на главную.

В `routes.py` используется декоратор `@login_required`, который:

- проверяет наличие записи в `session`;
- сверяет содержимое cookie и логина;
- при отсутствии авторизации перенаправляет пользователя на страницу регистрации/логина.

---


## REST-API

Поверх функций `dbservice.py` реализованы JSON-endpoint’ы:

- `GET /api/contactrequest` — список всех заявок.
- `GET /api/contactrequest/<id>` — заявка по id.
- `GET /api/contactrequest/author/<firstname>` — заявки по имени.
- `POST /api/contactrequest` — создание заявки (ожидается JSON с полями формы).
- `PUT /api/contactrequest/<id>` — обновление email по id.
- `DELETE /api/contactrequest/<id>` — удаление заявки.

Ответы возвращаются в JSON с осмысленными HTTP-кодами (200/201/400/404 и т.д.). Endpoint’ы удобно тестировать через Postman/Insomnia.


---


## Эволюция по лабораторным

1. **ЛР1 — статический HTML+CSS**  
   Макет сайта, структура страниц, общая сетка и стили.

2. **ЛР2 — JavaScript и jQuery**  
   Подсветка меню, анимации блоков новостей, интерактивное поведение элементов интерфейса.

3. **ЛР3 — переход на Flask и шаблоны**  
   Разбиение страниц на шаблоны, рендеринг на стороне сервера, формирование меню и контента из Python-кода.

4. **ЛР4 — БД и REST-API**  
   Подключение SQLite, таблица заявок, CRUD-операции, REST-endpoint’ы, тестирование через Postman/Insomnia.

5. **ЛР5 — авторизация и личный кабинет**  
   Регистрация, логин, хеш-пароли, сессии Flask, cookie `AuthToken`, ограничение доступа к форме заказа и личный кабинет с заявками текущего пользователя.

## Стек и инструменты

- **Backend:** Python 3, Flask, Flask-SQLAlchemy, Jinja2, SQLite, bcrypt.
- **Frontend:** HTML5, CSS3, JavaScript, jQuery.
- **Прочее:** Postman/Insomnia для тестирования REST-API.


## Запуск

```bash
python -m venv .venv
# активация виртуального окружения
# Windows: .venv\Scripts\activate
# Linux/macOS: source .venv/bin/activate

pip install -r requirements.txt
python main.py


