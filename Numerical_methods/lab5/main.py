import numpy as np
from prettytable import PrettyTable


def P(x: float):
    return 1.0 / (x**2 - 1.0)


def Q(x: float):
    return 1.0 / np.power(1.0 - x**2, 0.5)


def F(x: float):
    return 1.0 * (-np.sin(x) + P(x) * np.cos(x) + Q(x) * np.sin(x))


def Process(X: list, n: int, h: float):
    c1, c2, d1, d2 = 1, 1, 1, 1
    y0, y1, yn, yn1 = np.sin(X[0]), np.sin(X[1]), np.sin(X[n]), np.sin(X[n - 1])

    c = c1 * y0 + c2 * (y1 - y0) / h
    d = d1 * yn + d2 * (yn - yn1) / h

    alpha, beta, gamma, phi = [0], [c1 * 1.0 * h - c2], [c2 * 1.0], [h * c * 1.0]

    for i in range(1, n):
        alpha.append(1 * 1.0 - (P(X[i]) * h / 2))
        beta.append(-2 * 1.0 + Q(X[i]) * (h * h))
        gamma.append(1 * 1.0 + (P(X[i]) * h / 2))
        phi.append(h * h * F(X[i]))

    alpha.append(-d2)
    beta.append(h * d1 + d2)
    phi.append(h * d)
    gamma.append(0)

    l = [-gamma[0] / beta[0]]
    u = [phi[0] / beta[0]]

    for i in range(1, n+1):
        l.append(-gamma[i] / (beta[i] + alpha[i] * l[i - 1]))
        u.append((phi[i] - alpha[i] * u[i - 1]) / (beta[i] + alpha[i] * l[i - 1]))

    Y = [0 for i in range(0, n+1)]
    Y[n] = u[n]

    for i in range(n-1, -1, -1):
        Y[i] = l[i] * Y[i + 1] + u[i]

    return Y


a, b = 0.0, np.pi / 4.0
result = []
n = 2
while np.log2(n) < 20:
    h = (b * 1.0 - a * 1.0) / (n * 1.0)
    X = [a]

    for i in range(1, n):
        X.append(a + i * h)
    X.append(b)

    Y = Process(X, n, h)
    my_y = Y[i]
    deltaA = abs(np.sin(X[0]) - Y[0])
    deltaN2 = abs(np.sin(X[n // 2]) - Y[n // 2])
    deltaB = abs(np.sin(X[n]) - Y[n])

    result.append([n, my_y, deltaA, deltaN2, deltaB])

    n *= 2

td = ["n", "Y", "delta sin(0)", "delta sin(Pi/8)", "delta sin(Pi/4)"]
table = PrettyTable(td)
table.add_rows(result)
print(table)