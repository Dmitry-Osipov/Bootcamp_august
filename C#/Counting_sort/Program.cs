// сортировка подсчётом
int[] array = {0, 2, 3, 2, 1, 5, 9, 1, 1, 2, 1, 2, 7, 9, 8, 2, 1};
int[] mostArray = {0, 1, 5, 2, 10, 20, 1, 4, 2, 6, 20, -10, -5, -5, 2, -1, -9, 4};

CountingSort(array);
Console.WriteLine(string.Join(", ", array));

CountingSortExtended(mostArray);
Console.WriteLine(string.Join(", ", mostArray));

void CountingSort (int[] inputArray) // этот метод будет работать только с неотрицательными цифрами
{
    int[] counters = new int [10]; // массив повторений

    for (int i = 0; i < inputArray.Length; i += 1)
    {
        counters[inputArray[i]] += 1; // ниже раскрытие данной строки подробнее
        // int ourNumber = inputArray [i];
        // counters[ourNumber] += 1;
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i += 1)
    {
        for (int j = 0; j < counters[i]; j += 1)
        {
            inputArray[index] = i;
            index += 1;
        }
    }
}

void CountingSortExtended (int[] inputArray) // позволит работать со всеми числами
{
    int max = inputArray.Max();
    int min = inputArray.Min();
    int offset = -min;

    int[] counters = new int[max + offset + 1];

    for (int i = 0; i < inputArray.Length; i += 1)
    {
        counters[inputArray[i] + offset] += 1;

    }

    int index = 0;
    for (int i = 0; i < counters.Length; i += 1)
    {
        for (int j = 0; j < counters[i]; j += 1)
        {
            inputArray[index] = i - offset;
            index += 1;
        }
    }
}
