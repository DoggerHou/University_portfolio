import numpy as np
from prettytable import PrettyTable


#Вычисляем значение функции
def f(x):
    return np.log(x)


#Тело программы
a, b = 1, 2                             # Левая и правая границы
n = 1                                   # Количество интервалов разбиений
table = PrettyTable(['n', 'Jh'])        # Формируем удобную таблицу для вывода результатов
while n <= 20000000:
    h = (b - a) / n                     # Находим длину интервала
    J = 0.0                             # Значение интеграла
    x = [a + h * i for i in range(0, n+1)]
    for i in range(1, n):
        J += h * f(x[i])
    table.add_row([n, J])
    n *= 2

table.align = 'l'                       # Указываем выравнивание по левому краю
print(table)                            # Выводим таблицу
