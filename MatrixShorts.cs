using System;

public class MatrixShort
{
    protected short[,] ShortArray;
    protected int n, m;
    protected int codeError;
    protected static int num_m;

    public MatrixShort()
    {
        n = 1;
        m = 1;
        ShortArray = new short[n, m];
        codeError = 0;
        num_m++;
    }

    public MatrixShort(int sizeN, int sizeM)
    {
        n = sizeN;
        m = sizeM;
        ShortArray = new short[n, m];
        codeError = 0;
        num_m++;
    }

    public MatrixShort(int sizeN, int sizeM, short initValue)
    {
        n = sizeN;
        m = sizeM;
        ShortArray = new short[n, m];
        codeError = 0;
        num_m++;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ShortArray[i, j] = initValue;
            }
        }
    }

    ~MatrixShort()
    {
        Console.WriteLine("Об'єкт класу MatrixShort видалено");
    }

    public void InputMatrix()
    {
        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"[{i},{j}]: ");
                ShortArray[i, j] = short.Parse(Console.ReadLine());
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
                Console.Write($"{ShortArray[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    public void AssignValue(short value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ShortArray[i, j] = value;
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

    public short this[int i, int j]
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
                return ShortArray[i, j];
            }
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                ShortArray[i, j] = value;
            }
        }
    }

    public short this[int k]
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
                return ShortArray[i, j];
            }
        }
        set
        {
            if (k >= 0 && k < n * m)
            {
                int i = k / m;
                int j = k % m;
                ShortArray[i, j] = value;
            }
        }
    }

    // Оператори перевантаження

    public static MatrixShort operator ++(MatrixShort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ShortArray[i, j]++;
            }
        }
        return matrix;
    }

    public static MatrixShort operator --(MatrixShort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ShortArray[i, j]--;
            }
        }
        return matrix;
    }

    public static bool operator true(MatrixShort matrix)
    {
        if (matrix.n != 0 && matrix.m != 0)
        {
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    if (matrix.ShortArray[i, j] == 0)
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

    public static bool operator false(MatrixShort matrix)
    {
        return !(matrix);
    }

    public static bool operator !(MatrixShort matrix)
    {
        return matrix.n == 0 || matrix.m == 0;
    }

    public static MatrixShort operator +(MatrixShort matrix1, MatrixShort matrix2)
    {
        int n = Math.Max(matrix1.n, matrix2.n);
        int m = Math.Max(matrix1.m, matrix2.m);
        MatrixShort result = new MatrixShort(n, m);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                result[i, j] = (short)(matrix1[i, j] + matrix2[i, j]);
            }
        }

        return result;
    }

    public static MatrixShort operator +(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);

        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result[i, j] = (short)(matrix[i, j] + scalar);
            }
        }

        return result;
    }

    // Перевантаження інших операторів аналогічно
}
