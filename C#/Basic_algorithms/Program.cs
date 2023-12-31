﻿/*
1. Константные алгоритмы (сумма чисел от 1 до N) - O(1)
2. Линейные алгоритмы (сумма чисел от 1 до N) - O(n)
3. Квадратичные алгоритмы (сортировка пузырьком, выбором, ставками) - O(n^2)
4. Логарифмические алгоритмы (бинарный поиск) - O(log(n))
5. Линейно-логарифмические алгоритмы - O(n * log(n))
6. Кубические алгоритмы (заполнение трёхмерного массива) - O(n^3)

Сложность алгоритма - это кол-во действий, которое необходимо выполнить для получения конечного результата
*/

// 1. Константные алгоритмы: O {- сколько дейтсвий выполняет на алгоритм, чтобы получить результат} (1) - {одно действие} 
using System;

Console.Clear();
Console.Write("Введите число: ");
int n = int.Parse(Console.ReadLine()!);
Console.WriteLine($"Результат {(1+ n) / 2.0 * n}");

//2. Линейные алгоритмы - O(n):
int result = 0;
for (int i = 1; i <= n; i += 1)
{
    result += i;
}
Console.WriteLine($"Результат: {result}");

//3. Квадратичные алгоритмы - O(n^2):
// [4, 21, -3, 56, 78, 5]
// 4 < 21
// 21 < -3 !!!! -3 < 21
// [4, -3, 21, 56, 78, 5]
// 21 < 56
// 56 < 78
// 78 < 5 !!!! 5 < 78
// [4, -3, 21, 56, 5, 78]
// 4 < -3 !!!! -3 < 4
// [-3, 4, 21, 56, 5, 78]
// -3 < 4
// 4 < 21
// 21 < 56
// 56 < 5 !!!! 5 < 56
// [-3, 4, 21, 5, 56, 5, 78]
// ...
// 21 < 5 !!!! 5 < 21
// [-3, 4, 5, 21, 56, 78]

// 4. Логарифмические алгоритмы (Olog(n)):
// Загадали число 67
// -> 1 - наименьшее кол-во попыток
// -> 100 - наибольшее кол-во попыток
// от 1 до 100
// >50? - да - новый диапозон от 50 до 100
// >75? - нет - новый диапозон от 50 до 75
// >62? - да - новый диапозон от 62 до 75
// >68? - нет - новый диапозон от 62 до 68
// >65? - да - новый лиапозон от 65 до 68
// >66? - да - новый диаозон от 66 до 68
// >67? - нет - конечный ответ, ибо больше 66, но не больше 67
// итого 7 попыток
// O(log(n)) -> O(log(100)) -> 7 

// 5. Линейно-логарифмические алгоритмы - O(n * log(n))
// [4, 21, -3, 56, 78, 5]
// Опорный элемент = 4
// [-3] + [4] + [21, 56, 78, 5]
// [21, 56, 78, 5]
// Опорный элемент = 21
// [5] + [21] + [56, 78]
// [-3] + [4] + [5] + [21]
// [56, 78]
// Опорный элемент = 56 
// [] + [56] + [78]
// [-3] + [4] + [5] + [21] + [56] + [78]

// 6. Кубические алгоритмы (заполнение трёхмерного массива) - O(n^3)
