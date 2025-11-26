# Вариант 20: a = 20.0, b = 0.5, c = 3.81, d = 0.30
# Вариант 1:  a = 1.0, b = -1.4, c = 0.01, d = 0.11
# Функция: ax +by + e^(cx**2 + dy**2)
import math
import numpy as np
from prettytable import PrettyTable

# Вариант 20:
A, B, C, D = 20.0, 0.5, 3.81, 0.30
# Вариант 1:
#A, B, C, D = 1.0, -1.4, 0.01, 0.1

EPSILON = 0.0001
alpha = 1


# Класс для нашей точки
class Point:
    def __init__(self, x: float = 0.0, y: float = 0.0):
        self.x = x
        self.y = y


# Метод вычисления функции
def f(point: Point):
    return A * point.x + B * point.y + np.exp(C * point.x ** 2 + D * point.y ** 2)


# Производная по X
def derivative_X(point: Point):
    return A + 2 * C * point.x * np.exp(C * point.x ** 2 + D * point.y ** 2)


# Производная по Y
def derivative_Y(point: Point):
    return B + 2 * D * point.y * np.exp(C * point.x ** 2 + D * point.y ** 2)


# Вычисление градиента в точке
def gradient(point: Point):
    return Point(derivative_X(point), derivative_Y(point))


# Вычисление длины градиента
def gradient_Length(grad: Point):
    return math.sqrt(grad.x ** 2 + grad.y ** 2)


# Обновление точки
def next_Point(point: Point):
    return Point(point.x - alpha * derivative_X(point), point.y - alpha * derivative_Y(point))


# Задаем начальную точку и считаем ее градиент
p = Point(0, 0)
grad = gradient(p)

result = []
#Алгоритм минимизации(Метод градиентного спуска)
while gradient_Length(grad) >= EPSILON:
    if f(next_Point(p)) >= f(p):
        alpha = alpha / 2
        grad = gradient(p)
    else:
        result.append([p.x, p.y, f(p), derivative_X(p), derivative_Y(p), alpha, gradient_Length(p)])
        p = next_Point(p)
        grad = gradient(p)

table = PrettyTable(['x', 'y', 'F(x, y)', 'dF / dX', 'dF / dY', 'aplha', 'gradient_Length'])
table.add_rows(result)
print(table)
print('x =', p.x, 'y =', p.y)
print('f(x,y) =', f(p))
