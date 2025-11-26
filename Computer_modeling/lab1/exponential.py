import numpy as np
from scipy import stats
from prettytable import PrettyTable
import random
from matplotlib import pyplot as plt


def union_frequency(arr):
    while min([row[2] for row in arr]) <= 5:
        for i in range(len(arr) - 1, -1, -1):
            if arr[i][2] <= 5 and i == 0:
                arr[1][1] = f"{arr[0][1].split(' / ')[0]:.2f} / {arr[1][1].split(' / ')[1]:.2f}"
                arr[1][2] = arr[0][2] + arr[1][2]
                arr[1][3] = arr[0][3] + arr[1][3]
                arr[1][4] = arr[1][2] - arr[1][3]
                arr[1][5] = arr[1][4] ** 2
                arr[1][6] = arr[1][5] / arr[1][3]
                arr = arr[1:]
            elif arr[i][2] <= 5:
                arr[i - 1][1] = f"{arr[i-1][1].split(' / ')[0]} / {arr[i][1].split(' / ')[1]}"
                arr[i - 1][2] = arr[i - 1][2] + arr[i][2]
                arr[i - 1][3] = arr[i - 1][3] + arr[i][3]
                arr[i - 1][4] = arr[i - 1][2] - arr[i - 1][3]
                arr[i - 1][5] = arr[i - 1][4] ** 2
                arr[i - 1][6] = arr[i - 1][5] / arr[i - 1][3]
                arr = arr[:i] + arr[i + 1:]
    return arr


exponential_lambda = 0.6  # Лямбда для Показательного закона
significance_level = 0.05  # Уровень значимости
numb_of_experiments = 50000  # Число экспериментов


array = []
for i in range(numb_of_experiments):
    array.append(-np.log(1 - random.random()) / exponential_lambda)
print("Сгенерированное распределение(отсортированное):\n", sorted(array))


Xmin = np.floor(min(array))
Xmax = np.ceil(max(array))
k = int(1 + np.log2(numb_of_experiments))             # Вычисляем количество интервалов
h = round((Xmax - Xmin) / k, 2)                       # Вычисляем шаг интервалов
print("Количество интервалов: ", k)
print("Длина шага: ", h)


print_table = PrettyTable([                           # Задали таблицу для отображения
    "№ Интервала",
    "Интервал",
    "Частота",
    "Середина интервала"])

matrix = []
for i in range(k):
    # В первый столбец записываем номер интервала
    row = [i + 1]
    # Во второй столбец - интервал
    left = round(Xmin + abs(h * i), 2)
    right = round(Xmin + abs(h * (i + 1)), 2)
    row.append(f"{left:.2f} / {right:.2f}")
    # В третий столбец вписываем количество чисел, попавших в интервал
    count = len([x for x in array if left <= x < right])
    if (i == k - 1) and (Xmax == right):
        count += array.count(right)
    row.append(count)
    # В четвертый столбец вписываем середину интервала
    row.append(round((right + left) / 2, 2))

    matrix.append(row)

print_table.add_rows(matrix)
print(print_table)

# Находим оценку параметра lambda
print("Заданный параметр лямбда: ", exponential_lambda)
estimation_lambda = 1 / (sum([i[2] * i[3] for i in matrix]) / numb_of_experiments)
print("Оценка параметра: ", estimation_lambda)


theor_frequency = [numb_of_experiments *
                   (np.exp(-estimation_lambda * h * i) - np.exp(-estimation_lambda * h * (i + 1))) for i in range(k)]
print("Теоретические частоты:", theor_frequency)


#Подготавливаем таблицу для проверки распределения по критерию Пирсона
print_table = PrettyTable([                 # Задали таблицу для отображения
    "№ Интервала",                          #0
    "Интервал",                             #1
    "Частота ni",                           #2
    "Теоретическая частота n'i",            #3
    "ni - n'i",                             #4
    "(ni - n'i)^2",                         #5
    "Xu наблюдаемое"])                      #6

matrix = [i[:3] for i in matrix]               # Удаляем из матрицы столбец с серединами интервалов

for i in range(len(matrix)):                   # Добавляем в матрицу теор. частоты и вычисления
    matrix[i].append(theor_frequency[i])
    matrix[i].append(matrix[i][2] - matrix[i][3])
    matrix[i].append(matrix[i][4] ** 2)
    matrix[i].append(matrix[i][5] / matrix[i][3])

matrix = union_frequency(matrix)                # Объединяем малочисленные частоты


print("\n\nТаблица после объединения малочисленных событий:")
print_table.add_rows(matrix)
print(print_table)

X_nab = sum([row[6] for row in matrix])
X_kr = stats.chi2.ppf(1-significance_level, len(matrix) - 2)
print("Хи критическое : ", X_kr)
print("Хи наблюдаемое : ", X_nab)

if X_nab < X_kr:
    print("Т.к. Хи критическое > Хи наблюдаемого, принимаем гипотезу")
else:
    print("Т.к. Хи критическое < Хи наблюдаемого, отвергаем гипотезу")

plt.hist(array, density=True, edgecolor='black')
plt.show()
