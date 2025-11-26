from scipy import stats
from prettytable import PrettyTable
import random
import math
from matplotlib import pyplot as plt


significance_level = 0.05       # Уровень значимости
a = 0                           # Нижняя граница выборки
b = 100                         # Верхняя граница выборки
numb_of_experiments = 1000      # Число экспериментов

#Генерируем нашу случайную выборку:
array = [a + (b - a) * random.random() for i in range(numb_of_experiments)]
print("Случайная выборка: \n", *array)

Xmin = math.floor(min(array))
Xmax = math.ceil(max(array))
k = math.ceil(1 + math.log2(numb_of_experiments))           # Вычисляем количество интервалов
h = round((Xmax - Xmin) / k, 3)                             # Вычисляем шаг интервалов
print("Количество интервалов: ", k)
print("Длина шага: ", h)


print_table = PrettyTable([                                 # Задали таблицу для отображения
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

# Находим выборочное среднее
vib_sred = sum([i[2] * i[3] for i in matrix]) / numb_of_experiments
print("Среднее выборочное: ", vib_sred)
# Находим выборочное среднеквадратическое отклонение
S = sum([i[2] * (i[3] - vib_sred) ** 2 for i in matrix]) / numb_of_experiments
print("Выборочная средняя дисперсия S^2: ", S)
print("Выборочное среднее квадратическое отклонение: ", math.sqrt(S))
# Находим оценку верхней и нижней границы
estimation_A = vib_sred - math.sqrt(3 * S)
estimation_B = vib_sred + math.sqrt(3 * S)
print("\n\nОценка нижней границы a: ", estimation_A)
print("Оценка верхней границы b: ", estimation_B)

# Находим теоретические частоты
theor_frequency = [numb_of_experiments *
                   (1 / (estimation_B - estimation_A)) *
                   (float(matrix[0][1].split(' / ')[1]) - estimation_A)]

for i in range(1, k-1):
    theor_frequency.append(numb_of_experiments *
                           (1 / (estimation_B - estimation_A)) *
                           (float(matrix[i][1].split(' / ')[1]) - float(matrix[i][1].split(' / ')[0])))

theor_frequency.append(numb_of_experiments * (1 / (estimation_B - estimation_A)) *
                       (estimation_B - float(matrix[-1][1].split(' / ')[0])))
print("Теоретические частоты:", *theor_frequency)

#Добавляем в нашу матрицу теор. частоты и промежуточные вычисления + Хи наблюдаемое
for i in range(len(matrix)):
    matrix[i].append(theor_frequency[i])                    # Добавили теоретические частоты
    matrix[i].append(matrix[i][2] - matrix[i][4])           # Добавили разницу реальных и набл. частот
    matrix[i].append(matrix[i][5] ** 2)                     # Возвели в квадрат разницу частот
    matrix[i].append((matrix[i][6] / matrix[i][4]))         # Посчитали Хи квадрат для интервала

print_table = PrettyTable([                                 # Задали таблицу для отображения
    "№ Интервала",
    "Интервал",
    "Частота",
    "Середина интервала",
    "Теоретические частоты",
    "ni - n'i",
    "(ni - n'i)^2",
    "Xu наблюдаемое"])

# Выводидим нашу таблицу
print_table.add_rows(matrix)
print(print_table)

#Считаем Хи наблюдаемое
X_nab = sum([row[7] for row in matrix])
X_kr = stats.chi2.ppf(1-significance_level, len(matrix) - 3)
print("Хи критическое : ", X_kr)
print("Хи наблюдаемое : ", X_nab)

if X_nab < X_kr:
    print("Т.к. Хи критическое > Хи наблюдаемого, принимаем гипотезу")
else:
    print("Т.к. Хи критическое < Хи наблюдаемого, отвергаем гипотезу")

plt.hist(array, density=True, edgecolor='black')
plt.show()
