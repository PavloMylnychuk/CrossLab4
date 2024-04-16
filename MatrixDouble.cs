using System;

public class MatrixDouble
{
    protected double[,] DArray;
    protected uint n, m;
    protected int codeError;
    protected static int num_mf;

    public MatrixDouble()
    {
        n = 1;
        m = 1;
        DArray = new double[n, m];
        codeError = 0;
        num_mf++;
    }

    public MatrixDouble(int sizeN, int sizeM)
    {
        n = (uint)sizeN;
        m = (uint)sizeM;
        DArray = new double[n, m];
        codeError = 0;
        num_mf++;
    }

    public MatrixDouble(int sizeN, int sizeM, double initValue)
    {
        n = (uint)sizeN;
        m = (uint)sizeM;
        DArray = new double[n, m];
        codeError = 0;
        num_mf++;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                DArray[i, j] = initValue;
            }
        }
    }

    ~MatrixDouble()
    {
        Console.WriteLine("Об'єкт класу MatrixDouble видалено");
    }

    public void InputMatrix()
    {
        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"[{i},{j}]: ");
                DArray[i, j] = double.Parse(Console.ReadLine());
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
                Console.Write($"{DArray[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    public void AssignValue(double value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                DArray[i, j] = value;
            }
        }
    }

    public static int GetNumMatrices()
    {
        return num_mf;
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

    public double this[int i, int j]
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
                return DArray[i, j];
            }
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                DArray[i, j] = value;
            }
        }
    }

    public double this[int k]
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
                return DArray[i, j];
            }
        }
        set
        {
            if (k >= 0 && k < n * m)
            {
                int i = k / (int)m;
                int j = k % (int)m;
                DArray[i, j] = value;
            }
        }
    }

    // Оператори перевантаження

    public static MatrixDouble operator ++(MatrixDouble matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.DArray[i, j]++;
            }
        }
        return matrix;
    }

    public static MatrixDouble operator --(MatrixDouble matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.DArray[i, j]--;
            }
        }
        return matrix;
    }

    public static bool operator true(MatrixDouble matrix)
    {
        if (matrix.n != 0 && matrix.m != 0)
        {
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    if (matrix.DArray[i, j] == 0)
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

    public static bool operator false(MatrixDouble matrix)
    {
        return !(matrix);
    }

    public static bool operator !(MatrixDouble matrix)
    {
        return matrix.n == 0 || matrix.m == 0;
    }

    // Перевантаження інших операторів аналогічно
}
