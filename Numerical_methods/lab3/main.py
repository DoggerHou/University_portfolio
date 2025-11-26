import numpy as np
from prettytable import PrettyTable


def f1(x: float):
    return 6 * np.power(x, 5)


def f2(x: float):
    return np.power(x, 1.0 / 30) * np.sqrt(1 + x * x)


def numIntegral(a: float, b: float, exactIntegral: float, c: float, n: int, func):
    if n == 0:
        h = np.inf
    else:
        h = (b - a) / n

    x = [a + i * h for i in range(0, n + 1)]

    sum1 = 0
    for i in range(1, n):
        sum1 += func(x[i])

    sum2 = 0
    for i in range(0, n):
        sum2 += func(x[i] + h / 2)

    return (h / 6) * (func(a) + func(b) + 2 * sum1 + 4 * sum2)


#ResultRow = {'n': 0, 'integral': 0.0, 'deltaK': 0.0, 'deltaRunge': 0.0, 'deltaExact': 0.0, 'deltaTheory': 0.0}


def Process(a: float, b: float, exactIntegral: float, c: float, e: float, func):
    result = []
    runge = -1.0
    k_CONSTANT = 4

    n = 1
    while abs(runge) > e:
        integral = numIntegral(a, b, exactIntegral, c, n, func)
        integralH2 = numIntegral(a, b, exactIntegral, c, n * 2, func)
        integralH4 = numIntegral(a, b, exactIntegral, c, n * 4, func)
        integralDiv2 = numIntegral(a, b, exactIntegral, c, n // 2, func)
        runge = (integral - integralDiv2) / (np.power(2, k_CONSTANT) - 1)

        row = {'n': n, 'integral': integral, 'deltaRunge': runge,
               'deltaK': (integralH2 - integral) / (integralH4 - integralH2),'deltaExact': None, 'deltaTheory': None}

        if exactIntegral:
            row['deltaExact'] = abs(exactIntegral - integral)

        if c:
            h_CONSTANT = (b - a) / n
            row['deltaTheory'] = abs(c * np.power(h_CONSTANT, k_CONSTANT))
        result.append(row)

        n *= 2
    return result


def PrintTable(tst: list):
    td = ["n", "integral", "deltaRunge", "deltaK"]
    if len(tst):
        if tst[-1]['deltaExact'] != None:
            td.append("deltaExact")
        if tst[-1]['deltaTheory'] != None:
            td.append("deltaTheory")
    table = PrettyTable(td)
    for i in tst:
        if i['deltaExact'] == None:
            i.pop('deltaExact')
        if i['deltaTheory'] == None:
            i.pop('deltaTheory')
        table.add_row(i.values())
    print(table)


e_CONST = 1e-7
tst = Process(0, 1, 1, 720.0 / 2880, 1e-14, f1)
PrintTable(tst)
integralTest = tst[-1]['integral']
print("Значение интеграла 6x^5 на отрезке [0, 1]  =", integralTest, '\n\n')

task1 = Process(0, 1.5, 0, 0, e_CONST, f2)
PrintTable(task1)
integralTest = task1[-1]['integral']
print("Значение интеграла x^(1/30) * sqrt(1+x^2) на отрезке [0, 1.5] =", integralTest, '\n\n')

task2 = Process(0.001, 1.5, 0, 0, e_CONST, f2)
PrintTable(task2)
integralTest = task2[-1]['integral']
print("Значение интеграла x^(1/30) * sqrt(1+x^2) на отрезке [0.001, 1.5] =", integralTest)
