const int MATRIX_SIZE = 1000; // размер матрицы
const int THREADS_NUMBER = 10; // указываем кол-во потоков

int[,] serialMulRes = new int [MATRIX_SIZE, MATRIX_SIZE]; // результат выполнения умножения матриц в однопотоке
int[,] tredMulRes = new int [MATRIX_SIZE, MATRIX_SIZE]; // результат параллельного умножения матриц 

int[,] firstMatrix = MatrixGenerator(MATRIX_SIZE, MATRIX_SIZE);
int[,] secondMatrix = MatrixGenerator(MATRIX_SIZE, MATRIX_SIZE);

SerialMatrixMul(firstMatrix, secondMatrix);
PrepareParallelMatrixMul(firstMatrix, secondMatrix);
Console.WriteLine(EqualityMatrix(serialMulRes, tredMulRes));


int[,] MatrixGenerator (int rows, int columns)
{
    Random _rand = new Random();
    int[,] res = new int [rows, columns];
    for (int i = 0; i < res.GetLength(0); i += 1)
    {
        for (int j = 0; j < res.GetLength(1); j += 1)
        {
            res[i,j] = _rand.Next(-100, 101);
        }
    }
    return res;
}


void SerialMatrixMul(int[,] array1, int[,] array2)
{
    if (array1.GetLength(1) != array2.GetLength(0)) throw new Exception("Нельзя умножать такие матрицы");
    for (int i = 0; i < array1.GetLength(0); i += 1)
    {
        for (int j = 0; j < array2.GetLength(1); j += 1)
        {
             for (int k = 0; k < array2.GetLength(0); k += 1)
             {
                serialMulRes[i,j] += array1[i,k] * array2[k,j];
             }
        }
    }
}


void PrepareParallelMatrixMul(int[,] array1, int[,] array2)
{
    if (array1.GetLength(1) != array2.GetLength(0)) throw new Exception("Нельзя умножать такие матрицы");
    int eachThreadCalc = MATRIX_SIZE / THREADS_NUMBER;
    var threadsList = new List<Thread>();
    for (int i = 0; i < THREADS_NUMBER; i += 1)
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;
        // если последний поток:
        if (i == THREADS_NUMBER - 1) endPos = MATRIX_SIZE;
        threadsList.Add(new Thread(() => ParallelMatrixMul(array1, array2, startPos, endPos)));
        threadsList[i].Start();
    }
    for (int i = 0; i < THREADS_NUMBER; i += 1)
    {
        threadsList[i].Join();
    }
}


void ParallelMatrixMul(int[,] array1, int[,] array2, int startPos, int endPos)
{
    for (int i = startPos; i < endPos; i += 1)
    {
        for (int j = 0; j < array2.GetLength(1); j += 1)
        {
             for (int k = 0; k < array2.GetLength(0); k += 1)
             {
                tredMulRes[i,j] += array1[i,k] * array2[k,j];
             }
        }
    }
}

bool EqualityMatrix(int[,] array1, int[,] array2)
{
    bool res = true;
    for (int i = 0; i < firstMatrix.GetLength(0); i += 1)
    {
        for (int j = 0; j < secondMatrix.GetLength(1); j += 1)
        {
            res = res && (array1[i,j] == array2[i,j]);
        }
    }
    return res;
}

