using System;

public class MatrixUlong
{
    protected ulong[,] ULArray;
    protected uint n, m;
    protected int codeError;
    protected static int num_m;

    public MatrixUlong()
    {
        n = 1;
        m = 1;
        ULArray = new ulong[n, m];
        codeError = 0;
        num_m++;
    }

    public MatrixUlong(int sizeN, int sizeM)
    {
        n = (uint)sizeN;
        m = (uint)sizeM;
        ULArray = new ulong[n, m];
        codeError = 0;
        num_m++;
    }

    public MatrixUlong(int sizeN, int sizeM, ulong initValue)
    {
        n = (uint)sizeN;
        m = (uint)sizeM;
        ULArray = new ulong[n, m];
        codeError = 0;
        num_m++;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ULArray[i, j] = initValue;
            }
        }
    }

    ~MatrixUlong()
    {
        Console.WriteLine("Об'єкт класу MatrixUlong видалено");
    }

    public void InputMatrix()
    {
        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"[{i},{j}]: ");
                ULArray[i, j] = ulong.Parse(Console.ReadLine());
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
                Console.Write($"{ULArray[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    public void AssignValue(ulong value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ULArray[i, j] = value;
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

    public ulong this[int i, int j]
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
                return ULArray[i, j];
            }
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                ULArray[i, j] = value;
            }
        }
    }

    public ulong this[int k]
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
                return ULArray[i, j];
            }
        }
        set
        {
            if (k >= 0 && k < n * m)
            {
                int i = k / (int)m;
                int j = k % (int)m;
                ULArray[i, j] = value;
            }
        }
    }

    // Оператори перевантаження

    public static MatrixUlong operator ++(MatrixUlong matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ULArray[i, j]++;
            }
        }
        return matrix;
    }

    public static MatrixUlong operator --(MatrixUlong matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ULArray[i, j]--;
            }
        }
        return matrix;
    }

    public static bool operator true(MatrixUlong matrix)
    {
        if (matrix.n != 0 && matrix.m != 0)
        {
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    if (matrix.ULArray[i, j] == 0)
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

    public static bool operator false(MatrixUlong matrix)
    {
        return !(matrix);
    }

    public static bool operator !(MatrixUlong matrix)
    {
        return matrix.n == 0 || matrix.m == 0;
    }

    public static MatrixUlong operator +(MatrixUlong matrix1, MatrixUlong matrix2)
    {
        int n = Math.Max((int)matrix1.n, (int)matrix2.n);
        int m = Math.Max((int)matrix1.m, (int)matrix2.m);
        MatrixUlong result = new MatrixUlong(n, m);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ulong value1 = (i < (int)matrix1.n && j < (int)matrix1.m) ? matrix1.ULArray[i, j] : 0;
                ulong value2 = (i < (int)matrix2.n && j < (int)matrix2.m) ? matrix2.ULArray[i, j] : 0;
                result.ULArray[i, j] = value1 + value2;
            }
        }

        return result;
    }

    // Перевантаження інших операторів аналогічно
}
