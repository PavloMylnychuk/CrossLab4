using System;

public class MatrixByte
{
    protected byte[,] ByteArray;
    protected uint n, m;
    protected int codeError;
    protected static int num_vec;

    public MatrixByte()
    {
        n = 1;
        m = 1;
        ByteArray = new byte[n, m];
        codeError = 0;
        num_vec++;
    }

    public MatrixByte(int sizeN, int sizeM)
    {
        n = (uint)sizeN;
        m = (uint)sizeM;
        ByteArray = new byte[n, m];
        codeError = 0;
        num_vec++;
    }

    public MatrixByte(int sizeN, int sizeM, byte initValue)
    {
        n = (uint)sizeN;
        m = (uint)sizeM;
        ByteArray = new byte[n, m];
        codeError = 0;
        num_vec++;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ByteArray[i, j] = initValue;
            }
        }
    }

    ~MatrixByte()
    {
        Console.WriteLine("Об'єкт класу MatrixByte видалено");
    }

    public void InputMatrix()
    {
        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"[{i},{j}]: ");
                ByteArray[i, j] = byte.Parse(Console.ReadLine());
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
                Console.Write($"{ByteArray[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    public void AssignValue(byte value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ByteArray[i, j] = value;
            }
        }
    }

    public static int GetNumMatrices()
    {
        return num_vec;
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

    public byte this[int i, int j]
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
                return ByteArray[i, j];
            }
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                ByteArray[i, j] = value;
            }
        }
    }

    public byte this[int k]
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
                return ByteArray[i, j];
            }
        }
        set
        {
            if (k >= 0 && k < n * m)
            {
                int i = k / (int)m;
                int j = k % (int)m;
                ByteArray[i, j] = value;
            }
        }
    }

    // Оператори перевантаження

    public static MatrixByte operator ++(MatrixByte matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ByteArray[i, j]++;
            }
        }
        return matrix;
    }

    public static MatrixByte operator --(MatrixByte matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ByteArray[i, j]--;
            }
        }
        return matrix;
    }

    public static bool operator true(MatrixByte matrix)
    {
        if (matrix.n != 0 && matrix.m != 0)
        {
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    if (matrix.ByteArray[i, j] == 0)
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

    public static bool operator false(MatrixByte matrix)
    {
        return !(matrix);
    }

    public static bool operator !(MatrixByte matrix)
    {
        return matrix.n == 0 || matrix.m == 0;
    }

    // Перевантаження інших операторів аналогічно
}
