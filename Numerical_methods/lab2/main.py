# Краевые условия S3''(a)=f''(a), S3''(b)=f''(b)
# Вычисление значение функции

import numpy as np
from prettytable import PrettyTable


# Вычисление значение функции
def f(x: float):
    return np.sin(x)


# Вычисление значение второй производной функции
def f_derivative_2(x: float):
    return -np.sin(x)


# Функция кубического сплайна
def cube_spline(x: float, i: int, h: float, M: list, X: list):
    return M[i - 1] * (pow(X[i] - x, 3) - h * h * (X[i] - x)) / (6 * h) \
           + M[i] * (pow(x - X[i - 1], 3) - h * h * (x - X[i - 1])) / (6 * h) \
           + f(X[i - 1]) * (X[i] - x) / h \
           + f(X[i]) * (x - X[i - 1]) / h


def TMA(f0: float, fn: float, h: float, n: int, X: list):
    ai, bi, ci = 2 * h / 3, h / 6, h / 6
    a0, b0, an, cn = 1, 0, 1, 0

    d = [0.0 for i in range(0, n + 1)]
    d[0] = f_derivative_2(f0)
    d[n] = f_derivative_2(fn)

    for i in range(1, n):
        d[i] = (f(X[i + 1]) - f(X[i])) / h - (f(X[i]) - f(X[i - 1])) / h

    l = [0.0 for i in range(0, n + 1)]
    u = [0.0 for i in range(0, n + 1)]
    l[0], u[0] = -b0 / a0, d[0] / a0

    for i in range(1, n):
        l[i] = -bi / (ai + ci * l[i - 1])
        u[i] = (d[i] - ci * u[i - 1]) / (ai + ci * l[i - 1])

    l[n] = -bi / (an + cn * l[n - 1])
    u[n] = (d[n] - cn * u[n - 1]) / (an + cn * l[n - 1])

    M = [0.0 for i in range(0, n + 1)]
    M[n] = u[n]

    for i in range(n - 1, -1, -1):
        M[i] = l[i] * M[i + 1] + u[i]
    return M


a, b, prevMax = 0.0, np.pi, 0.0
result = []

n = 5
while n <= 10240:
    h = (b - a) / n
    X = [a]

    for i in range(1, n):
        X.append(a + i * h)

    X.append(b)
    M = TMA(a, b, h, n, X)
    deltaMax, ocenka = 0.0, 0.0

    for i in range(1, n):
        s3 = cube_spline(X[i - 1] + h / 2, i, h, M, X)
        ocenka = abs(s3 - f(X[i - 1] + h / 2))
        deltaMax = max(deltaMax, ocenka)

    entry = [n, deltaMax, prevMax / pow(2, 4), prevMax / deltaMax]
    result.append(entry)
    prevMax = deltaMax

    n *= 2

td = ["n", "deltaMax", "deltaOc", "K"]
table = PrettyTable(td)
table.add_rows(result)
print(table)
