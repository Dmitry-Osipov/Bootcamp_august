// Сортировка выбором

/*
считаем, что нулевой элемент массива является минимальным. Далее переставляем, если последующий элемент
является минимальным, если нет, то переходим к следующему
2 7 0 3 -5 12 8
-5 7 0 3 2 12 8
-5 0 7 3 2 12 8
-5 0 3 7 2 12 8
-5 0 2 3 7 12 8
-5 0 2 3 7 12 8
-5 0 2 3 7 8 12
*/

/*
char f() // -> функиця (возвращает)
{
    return '1';
}

void v() // -> процедура (не возвращает, но выполняет какой-то код внутри)
{
    Console.Write("hello");
}
*/

void InputArray(int[] array)
{
    for (int i = 0; i < array.Length; i += 1)
    {
        array[i] = new Random().Next(-10, 11);
    }
}

int[] SelectionSort(int[] array)
{
    for (int i = 0; i < array.Length; i += 1)
    {
        int min = i;
        for (int j = i + 1; j < array.Length; j += 1)
        {
            if (array[j] < array[min])
            {
                min = j;
            }
        }
        int temp = array[min];
        array[min] = array[i];
        array[i] = temp;
    }
    return array;
}

Console.Write("Введите кол-во элементов массива: ");
int n = int.Parse(Console.ReadLine()!);
int[] array = new int[n];
InputArray(array);
Console.WriteLine($"Исходный массив: [{string.Join(", ", array)}]");
Console.WriteLine($"Исходный массив: [{string.Join(", ", SelectionSort(array))}]");
