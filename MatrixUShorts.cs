using System;

public class MatrixUshort
{
    protected ushort[,] ShortIntArray;
    protected int n, m;
    protected int codeError;
    protected static int num_m;

    public MatrixUshort()
    {
        n = 1;
        m = 1;
        ShortIntArray = new ushort[n, m];
        codeError = 0;
        num_m++;
    }

    public MatrixUshort(int sizeN, int sizeM)
    {
        n = sizeN;
        m = sizeM;
        ShortIntArray = new ushort[n, m];
        codeError = 0;
        num_m++;
    }

    public MatrixUshort(int sizeN, int sizeM, ushort initValue)
    {
        n = sizeN;
        m = sizeM;
        ShortIntArray = new ushort[n, m];
        codeError = 0;
        num_m++;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ShortIntArray[i, j] = initValue;
            }
        }
    }

    ~MatrixUshort()
    {
        Console.WriteLine("Об'єкт класу MatrixUshort видалено");
    }

    public void InputMatrix()
    {
        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"[{i},{j}]: ");
                ShortIntArray[i, j] = ushort.Parse(Console.ReadLine());
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
                Console.Write($"{ShortIntArray[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    public void AssignValue(ushort value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ShortIntArray[i, j] = value;
            }
        }
    }

    public static int GetNumMatrices()
    {
        return num_m;
    }

    public int Rows
    {
        get { return n; }
    }

    public int Columns
    {
        get { return m; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    public ushort this[int i, int j]
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
                return ShortIntArray[i, j];
            }
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                ShortIntArray[i, j] = value;
            }
        }
    }

    public ushort this[int k]
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
                int i = k / m;
                int j = k % m;
                return ShortIntArray[i, j];
            }
        }
        set
        {
            if (k >= 0 && k < n * m)
            {
                int i = k / m;
                int j = k % m;
                ShortIntArray[i, j] = value;
            }
        }
    }

    // Оператори перевантаження

    public static MatrixUshort operator ++(MatrixUshort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ShortIntArray[i, j]++;
            }
        }
        return matrix;
    }

    public static MatrixUshort operator --(MatrixUshort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ShortIntArray[i, j]--;
            }
        }
        return matrix;
    }

    public static bool operator true(MatrixUshort matrix)
    {
        if (matrix.n != 0 && matrix.m != 0)
        {
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    if (matrix.ShortIntArray[i, j] == 0)
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

    public static bool operator false(MatrixUshort matrix)
    {
        return !(matrix);
    }

    public static bool operator !(MatrixUshort matrix)
    {
        return matrix.n == 0 || matrix.m == 0;
    }

    public static MatrixUshort operator +(MatrixUshort matrix1, MatrixUshort matrix2)
    {
        int n = Math.Max(matrix1.n, matrix2.n);
        int m = Math.Max(matrix1.m, matrix2.m);
        MatrixUshort result = new MatrixUshort(n, m);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                result[i, j] = (ushort)(matrix1[i, j] + matrix2[i, j]);
            }
        }

        return result;
    }

    public static MatrixUshort operator +(MatrixUshort matrix, ushort scalar)
    {
        MatrixUshort result = new MatrixUshort(matrix.n, matrix.m);

        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result[i, j] = (ushort)(matrix[i, j] + scalar);
            }
        }

        return result;
    }

    // Перевантаження інших операторів аналогічно
}
