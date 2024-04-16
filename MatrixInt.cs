using System;

public class MatrixInt
{
    protected int[,] IntArray;
    protected int n, m;
    protected int codeError;
    protected static int num_mat;

    public MatrixInt()
    {
        n = 1;
        m = 1;
        IntArray = new int[n, m];
        codeError = 0;
        num_mat++;
    }

    public MatrixInt(int sizeN, int sizeM)
    {
        n = sizeN;
        m = sizeM;
        IntArray = new int[n, m];
        codeError = 0;
        num_mat++;
    }

    public MatrixInt(int sizeN, int sizeM, int initValue)
    {
        n = sizeN;
        m = sizeM;
        IntArray = new int[n, m];
        codeError = 0;
        num_mat++;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                IntArray[i, j] = initValue;
            }
        }
    }

    ~MatrixInt()
    {
        Console.WriteLine("Об'єкт класу MatrixInt видалено");
    }

    public void InputMatrix()
    {
        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"[{i},{j}]: ");
                IntArray[i, j] = int.Parse(Console.ReadLine());
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
                Console.Write($"{IntArray[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    public void AssignValue(int value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                IntArray[i, j] = value;
            }
        }
    }

    public static int GetNumMatrices()
    {
        return num_mat;
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

    public int this[int i, int j]
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
                return IntArray[i, j];
            }
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                IntArray[i, j] = value;
            }
        }
    }

    public int this[int k]
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
                return IntArray[i, j];
            }
        }
        set
        {
            if (k >= 0 && k < n * m)
            {
                int i = k / m;
                int j = k % m;
                IntArray[i, j] = value;
            }
        }
    }

    // Оператори перевантаження

    public static MatrixInt operator ++(MatrixInt matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.IntArray[i, j]++;
            }
        }
        return matrix;
    }

    public static MatrixInt operator --(MatrixInt matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.IntArray[i, j]--;
            }
        }
        return matrix;
    }

    public static bool operator true(MatrixInt matrix)
    {
        if (matrix.n != 0 && matrix.m != 0)
        {
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    if (matrix.IntArray[i, j] == 0)
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

    public static bool operator false(MatrixInt matrix)
    {
        return !(matrix);
    }

    public static bool operator !(MatrixInt matrix)
    {
        return matrix.n == 0 || matrix.m == 0;
    }

    public static MatrixInt operator +(MatrixInt matrix1, MatrixInt matrix2)
    {
        int n = Math.Max(matrix1.n, matrix2.n);
        int m = Math.Max(matrix1.m, matrix2.m);
        MatrixInt result = new MatrixInt(n, m);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

    public static MatrixInt operator +(MatrixInt matrix, int scalar)
    {
        MatrixInt result = new MatrixInt(matrix.n, matrix.m);

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
