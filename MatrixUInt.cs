using System;

public class MatrixUint
{
    protected uint[,] UintArray;
    protected int n, m;
    protected int codeError;
    protected static int num_m;

    public MatrixUint()
    {
        n = 1;
        m = 1;
        UintArray = new uint[n, m];
        codeError = 0;
        num_m++;
    }

    public MatrixUint(int sizeN, int sizeM)
    {
        n = sizeN;
        m = sizeM;
        UintArray = new uint[n, m];
        codeError = 0;
        num_m++;
    }

    public MatrixUint(int sizeN, int sizeM, uint initValue)
    {
        n = sizeN;
        m = sizeM;
        UintArray = new uint[n, m];
        codeError = 0;
        num_m++;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                UintArray[i, j] = initValue;
            }
        }
    }

    ~MatrixUint()
    {
        Console.WriteLine("Об'єкт класу MatrixUint видалено");
    }

    public void InputMatrix()
    {
        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"[{i},{j}]: ");
                UintArray[i, j] = uint.Parse(Console.ReadLine());
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
                Console.Write($"{UintArray[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    public void AssignValue(uint value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                UintArray[i, j] = value;
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

    public uint this[int i, int j]
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
                return UintArray[i, j];
            }
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                UintArray[i, j] = value;
            }
        }
    }

    public uint this[int k]
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
                return UintArray[i, j];
            }
        }
        set
        {
            if (k >= 0 && k < n * m)
            {
                int i = k / m;
                int j = k % m;
                UintArray[i, j] = value;
            }
        }
    }

    // Оператори перевантаження

    public static MatrixUint operator ++(MatrixUint matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.UintArray[i, j]++;
            }
        }
        return matrix;
    }

    public static MatrixUint operator --(MatrixUint matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.UintArray[i, j]--;
            }
        }
        return matrix;
    }

    public static bool operator true(MatrixUint matrix)
    {
        if (matrix.n != 0 && matrix.m != 0)
        {
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    if (matrix.UintArray[i, j] == 0)
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

    public static bool operator false(MatrixUint matrix)
    {
        return !(matrix);
    }

    public static bool operator !(MatrixUint matrix)
    {
        return matrix.n == 0 || matrix.m == 0;
    }

    public static MatrixUint operator +(MatrixUint matrix1, MatrixUint matrix2)
    {
        int n = Math.Max(matrix1.n, matrix2.n);
        int m = Math.Max(matrix1.m, matrix2.m);
        MatrixUint result = new MatrixUint(n, m);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

    public static MatrixUint operator +(MatrixUint matrix, uint scalar)
    {
        MatrixUint result = new MatrixUint(matrix.n, matrix.m);

        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result[i, j] = matrix[i, j] + scalar;
            }
        }

        return result;
    }

    // Перевантаження інших операторів аналогічно
}
