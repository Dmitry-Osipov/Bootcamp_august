const int THREADS_NUMBER = 4; // Число потоков
const int size = 100000000; // Размер массива


Random rand = new Random();
int[] resSerial = new int [size].Select(r => rand.Next(0, 5)).ToArray();
int[] resParallel = new int [size];

CountingSortExtended(resSerial);

Array.Copy(resSerial, resParallel, size);
PrepareParallelCountingSort(resParallel);
Console.WriteLine(EqualityMatrix(resParallel, resSerial));


void PrepareParallelCountingSort (int[] inputArray)
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int offset = -min;
    int[] counters = new int [max + offset + 1];

    int eachThreadCalc = size / THREADS_NUMBER;
    var threadsParallel = new List<Thread>();

    for (int i = 0; i < THREADS_NUMBER; i += 1)
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i +  1) * eachThreadCalc;

        if (i == THREADS_NUMBER - 1) endPos = size;

        threadsParallel.Add(new Thread(() => CountingSortParallel(inputArray, counters, offset, startPos, endPos)));
        threadsParallel[i].Start();
    }

    foreach (var thread in threadsParallel)
    {
        thread.Join();
    }
}

void CountingSortParallel (int[] inputArray, int[] counters, int offset, int startPos, int endPos)
{
    for (int i = startPos; i < endPos; i += 1)
    {
        counters[inputArray[i] + offset] += 1;
    }
}

void CountingSortExtended (int[] inputArray)
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

bool EqualityMatrix(int[] fmatrix, int[] smatrix)
{
    bool res = true;

    for (int i = 0; i < size; i++)
    {
        res = res && (fmatrix[i] == smatrix[i]);
    }

    return res;
}
