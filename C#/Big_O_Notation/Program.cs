int[] firstArray = new int[5];
for (int i = 0; i < firstArray.Length; i+= 1)
{
    Console.Write("Enter digit: ");
    firstArray[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("[" + string.Join(", ", firstArray) + "]"); // для красивого вывода
// за сколько операций получится узнать конкретное значение в массиве по индексу?
Console.WriteLine(firstArray[3]); // Сложность алгоритма O(1) - чтобы узнать конечный результат, мы затратили 1 дейтсвие

// -----------------------------------------------------------------

// [4, 5, 3, 1, 2]
// за сколько операций получится узнать сумму всех элементов?
int n = 5;
int[] secondArray = new int[n];
for (int i = 0; i < secondArray.Length; i+= 1)
{
    Console.Write("Enter digit: ");
    secondArray[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine(secondArray.Sum()); // Сложность алгоритма O(n) - 5 действий (по кол-ву действий для данных в массиве)

// -----------------------------------------------------------------

// [2, 3, 4, 1, 5] -> [1, 2, 3, 4, 5]
// быстрая сортировка работает за O(n * log(n))

// -----------------------------------------------------------------
// Требуется составить таблицу умножения полями n на n (значение n задаёт пользователь)
Console.Write("Enter number: ");
int N = Convert.ToInt32(Console.ReadLine());
for (int i = 1; i <= N; i += 1)
{
    for (int j = 1; j <= N; j += 1)
    {
        Console.Write($"{i * j} ");
    }
    Console.WriteLine();
}
// O(n^2)

// Можно сократить время работы программы, используя матрицу
int[,] matrix = new int[N, N];
for (int i = 0; i < N; i += 1)
{
    for (int j = i; j < N; j += 1)
    {
            matrix[i, j] = (i + 1) * (j + 1); 
            matrix[j, i] = (i + 1) * (j + 1);
    }
    Console.WriteLine();
}

for (int i = 0; i < N; i += 1)
{
    for (int j = 0; j < N; j += 1)
    {
        Console.Write(matrix[i, j]);
        Console.Write(" ");
    }
    Console.WriteLine();
}
// O(n^2 / 2)