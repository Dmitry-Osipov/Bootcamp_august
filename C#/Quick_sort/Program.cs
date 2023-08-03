// Работа алгоритма:
// худшее время - O(n^2)
// среднее время - O(n * log(n))
// лучшее время - O(n)

int[] QuickSort (int[] array)
{
    if (array.Length <= 1) return array;
    else
    {
        int pivot = array[0];
        int[] leftArray = array.Skip(1).Where(x => x < pivot).ToArray();
        int[] rightArray = array.Skip(1).Where(x => x >= pivot).ToArray();
        return QuickSort(leftArray).Concat(new int[] { pivot }).Concat(QuickSort(rightArray)).ToArray();
    }
}

int[] testArray = {1, 6, 0, -3, 2, 1, 9, 5, -6};
int[] sortedArray = QuickSort(testArray);

foreach (var item in sortedArray)
{
    Console.Write($"{item} ");
}