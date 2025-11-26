from prettytable import PrettyTable
import numpy as np

# Константы
a, q = 1.1, 2


# Частичная сумма ряда
def Z(n: int):
    sum = 0
    for i in range(1, n+1):
        sum += np.power(i, (-1.0) * a)
    return sum


# Правило Ричардсона
def Extrapolation(z, n: int, k: float):
    zn = z(n)
    return zn + (zn - z(n // q)) / (np.power(q, k) - 1)


# Повторая экстраполяция
def Extrapolation_2(z, n: int):
    first = lambda n: Extrapolation(z, n, a - 1)
    return Extrapolation(first, n, a)



zExact_CONST = 10.5844484649508098
everything = []
n = 2
while n <= 65536:
    stp = {}
    delta = (Extrapolation(Z, n, a - 1) - zExact_CONST) / (Z(n) - zExact_CONST)
    delta2 = (Extrapolation_2(Z, n) - zExact_CONST) / (Extrapolation(Z, n, a - 1) - zExact_CONST)
    stp['n'] = n
    #stp['Zn'] = Z(n)
    #stp['Extrapol(1)'] = Extrapolation(Z, n, a - 1)
    stp['Zn - zExact'] = Z(n) - zExact_CONST
    stp['Zn - Extrapol(1)'] = Z(n) - Extrapolation(Z, n, a - 1)
    stp['Extrapol(1) - zExact'] = Extrapolation(Z, n, a - 1) - zExact_CONST
    stp['delta(1)'] = delta
    #stp['Extrapol(2)'] = Extrapolation_2(Z, n)
    stp['Extrapol(2) - zExact'] = (Extrapolation_2(Z, n) - zExact_CONST) * (n > 2)
    stp['delta(2)'] = delta2 * (n > 2)

    everything.append(stp)

    n *= 2

#Вывод таблицы
table = PrettyTable(everything[-1].keys())
for i in everything:
    table.add_row(i.values())
print(table)