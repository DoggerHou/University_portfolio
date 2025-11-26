import math
import random
import scipy

# Вычислить значение функции
def f(x):
    return 3*x**2 + 6*x - 4


# Сгенерировать число по равномерному закону
def uniform(a, b):
    return a + (b-a) * random.random()


a = 0
b = 10
n = 1000000
alpha = 0.95                                #Доверительная вероятность
i_exact = 1260
print("\t\t\t\t\t\tМЕТОД МОНТЕ-КАРЛО")


array = [[0, 0] for i in range(n)]
for i in range(n):
    x = uniform(a, b)
    array[i][0] = x
    array[i][1] = f(x)
    if i < 100:
        print(f"{i + 1} Испытание: x = {array[i][0]},   f(x) = {array[i][1]}")

i_estimation = (b - a) * sum([i[1] for i in array]) / n
print("\n\nОценочное значение интеграла:", i_estimation)
print("Точное значение интеграла:", i_exact)
i_error = abs(i_exact - i_estimation)
print("Погрешность:", i_error)


z = scipy.stats.t.ppf((1 + alpha) / 2, n-1)
print("\n\nt критерий Стьюдента:", z)
S_vib = 0
for i in range(n):
    S_vib += (array[i][0] - i_estimation) ** 2 / (n-1)
print("Выборочная дисперсия:", S_vib)
S_sred = math.sqrt(S_vib)
print("Среднеквадратическое отклонение:", S_sred)
print(f"Доверительный интервал: [{i_estimation - z * S_sred/math.sqrt(n)};{i_estimation + z * S_sred/math.sqrt(n)}]")

if i_estimation - z * S_sred/math.sqrt(n) <= i_estimation <= i_estimation + z * S_sred/math.sqrt(n):
    print("C вероятностью 95% оценка попала в доверительный интервал")
else:
    print("Оценка попала в доверительный интервал")