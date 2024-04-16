using System;

public class DecimalMatrix
{
    protected decimal[,] DCArray;
    protected uint n, m;
    protected int codeError;
    protected static int num_mf;

    public DecimalMatrix()
    {
        n = 1;
        m = 1;
        DCArray = new decimal[n, m];
        codeError = 0;
        num_mf++;
    }

    public DecimalMatrix(int sizeN, int sizeM)
    {
        n = (uint)sizeN;
        m = (uint)sizeM;
        DCArray = new decimal[n, m];
        codeError = 0;
        num_mf++;
    }

    public DecimalMatrix(int sizeN, int sizeM, decimal initValue)
    {
        n = (uint)sizeN;
        m = (uint)sizeM;
        DCArray = new decimal[n, m];
        codeError = 0;
        num_mf++;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                DCArray[i, j] = initValue;
            }
        }
    }

    ~DecimalMatrix()
    {
        Console.WriteLine("Об'єкт класу DecimalMatrix видалено");
    }

    public void InputMatrix()
    {
        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"[{i},{j}]: ");
                DCArray[i, j] = decimal.Parse(Console.ReadLine());
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
                Console.Write($"{DCArray[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    public void AssignValue(decimal value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                DCArray[i, j] = value;
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

    public decimal this[int i, int j]
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
                return DCArray[i, j];
            }
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                DCArray[i, j] = value;
            }
        }
    }

    public decimal this[int k]
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
                return DCArray[i, j];
            }
        }
        set
        {
            if (k >= 0 && k < n * m)
            {
                int i = k / (int)m;
                int j = k % (int)m;
                DCArray[i, j] = value;
            }
        }
    }

    // Оператори перевантаження

    public static DecimalMatrix operator ++(DecimalMatrix matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.DCArray[i, j]++;
            }
        }
        return matrix;
    }

    public static DecimalMatrix operator --(DecimalMatrix matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.DCArray[i, j]--;
            }
        }
        return matrix;
    }

    public static bool operator true(DecimalMatrix matrix)
    {
        if (matrix.n != 0 && matrix.m != 0)
        {
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    if (matrix.DCArray[i, j] == 0)
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

    public static bool operator false(DecimalMatrix matrix)
    {
        return !(matrix);
    }

    public static bool operator !(DecimalMatrix matrix)
    {
        return matrix.n == 0 || matrix.m == 0;
    }

    public static DecimalMatrix operator +(DecimalMatrix matrix1, DecimalMatrix matrix2)
    {
        int n = Math.Max((int)matrix1.n, (int)matrix2.n);
        int m = Math.Max((int)matrix1.m, (int)matrix2.m);
        DecimalMatrix result = new DecimalMatrix(n, m);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                decimal value1 = (i < (int)matrix1.n && j < (int)matrix1.m) ? matrix1.DCArray[i, j] : 0;
                decimal value2 = (i < (int)matrix2.n && j < (int)matrix2.m) ? matrix2.DCArray[i, j] : 0;
                result.DCArray[i, j] = value1 + value2;
            }
        }

        return result;
    }

    // Перевантаження інших операторів аналогічно
}
