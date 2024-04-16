using System;

public class MatrixLong
{
    protected long[,] LongArray;
    protected uint n, m;
    protected int codeError;
    protected static int num_m;

    public MatrixLong()
    {
        n = 1;
        m = 1;
        LongArray = new long[n, m];
        codeError = 0;
        num_m++;
    }

    public MatrixLong(int sizeN, int sizeM)
    {
        n = (uint)sizeN;
        m = (uint)sizeM;
        LongArray = new long[n, m];
        codeError = 0;
        num_m++;
    }

    public MatrixLong(int sizeN, int sizeM, long initValue)
    {
        n = (uint)sizeN;
        m = (uint)sizeM;
        LongArray = new long[n, m];
        codeError = 0;
        num_m++;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                LongArray[i, j] = initValue;
            }
        }
    }

    ~MatrixLong()
    {
        Console.WriteLine("Об'єкт класу MatrixLong видалено");
    }

    public void InputMatrix()
    {
        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"[{i},{j}]: ");
                LongArray[i, j] = long.Parse(Console.ReadLine());
            }
        }
    }

    public void OutputMatrix()
    {
        Console.WriteLine("Матриця:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{LongArray[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    public void AssignValue(long value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                LongArray[i, j] = value;
            }
        }
    }

    public static int GetNumMatrices()
    {
        return num_m;
    }

    public int Rows
    {
        get { return (int)n; }
    }

    public int Columns
    {
        get { return (int)m; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    public long this[int i, int j]
    {
        get
        {
            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = -1;
                return 0;
            }
            else
            {
                codeError = 0;
                return LongArray[i, j];
            }
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                LongArray[i, j] = value;
            }
        }
    }

    public long this[int k]
    {
        get
        {
            if (k < 0 || k >= n * m)
            {
                codeError = -1;
                return 0;
            }
            else
            {
                codeError = 0;
                int i = k / (int)m;
                int j = k % (int)m;
                return LongArray[i, j];
            }
        }
        set
        {
            if (k >= 0 && k < n * m)
            {
                int i = k / (int)m;
                int j = k % (int)m;
                LongArray[i, j] = value;
            }
        }
    }

    // Оператори перевантаження

    public static MatrixLong operator ++(MatrixLong matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.LongArray[i, j]++;
            }
        }
        return matrix;
    }

    public static MatrixLong operator --(MatrixLong matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.LongArray[i, j]--;
            }
        }
        return matrix;
    }

    public static bool operator true(MatrixLong matrix)
    {
        if (matrix.n != 0 && matrix.m != 0)
        {
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    if (matrix.LongArray[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool operator false(MatrixLong matrix)
    {
        return !(matrix);
    }

    public static bool operator !(MatrixLong matrix)
    {
        return matrix.n == 0 || matrix.m == 0;
    }

    public static MatrixLong operator +(MatrixLong matrix1, MatrixLong matrix2)
    {
        int n = Math.Max((int)matrix1.n, (int)matrix2.n);
        int m = Math.Max((int)matrix1.m, (int)matrix2.m);
        MatrixLong result = new MatrixLong(n, m);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

    // Перевантаження інших операторів аналогічно
}
