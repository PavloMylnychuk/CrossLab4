using System;

public class FloatMatrix
{
    protected float[,] FMArray;
    protected uint n, m;
    protected int codeError;
    protected static int num_mf;

    public FloatMatrix()
    {
        n = 1;
        m = 1;
        FMArray = new float[n, m];
        codeError = 0;
        num_mf++;
    }

    public FloatMatrix(int sizeN, int sizeM)
    {
        n = (uint)sizeN;
        m = (uint)sizeM;
        FMArray = new float[n, m];
        codeError = 0;
        num_mf++;
    }

    public FloatMatrix(int sizeN, int sizeM, float initValue)
    {
        n = (uint)sizeN;
        m = (uint)sizeM;
        FMArray = new float[n, m];
        codeError = 0;
        num_mf++;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                FMArray[i, j] = initValue;
            }
        }
    }

    ~FloatMatrix()
    {
        Console.WriteLine("Об'єкт класу FloatMatrix видалено");
    }

    public void InputMatrix()
    {
        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"[{i},{j}]: ");
                FMArray[i, j] = float.Parse(Console.ReadLine());
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
                Console.Write($"{FMArray[i, j]}\t");
            }
            Console.WriteLine();
        }
    }

    public void AssignValue(float value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                FMArray[i, j] = value;
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

    public float this[int i, int j]
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
                return FMArray[i, j];
            }
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                FMArray[i, j] = value;
            }
        }
    }

    public float this[int k]
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
                return FMArray[i, j];
            }
        }
        set
        {
            if (k >= 0 && k < n * m)
            {
                int i = k / (int)m;
                int j = k % (int)m;
                FMArray[i, j] = value;
            }
        }
    }

    // Оператори перевантаження

    public static FloatMatrix operator ++(FloatMatrix matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.FMArray[i, j]++;
            }
        }
        return matrix;
    }

    public static FloatMatrix operator --(FloatMatrix matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.FMArray[i, j]--;
            }
        }
        return matrix;
    }

    public static bool operator true(FloatMatrix matrix)
    {
        if (matrix.n != 0 && matrix.m != 0)
        {
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    if (matrix.FMArray[i, j] == 0)
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

    public static bool operator false(FloatMatrix matrix)
    {
        return !(matrix);
    }

    public static bool operator !(FloatMatrix matrix)
    {
        return matrix.n == 0 || matrix.m == 0;
    }

    public static FloatMatrix operator +(FloatMatrix matrix1, FloatMatrix matrix2)
    {
        int n = Math.Max((int)matrix1.n, (int)matrix2.n);
        int m = Math.Max((int)matrix1.m, (int)matrix2.m);
        FloatMatrix result = new FloatMatrix(n, m);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                float value1 = (i < (int)matrix1.n && j < (int)matrix1.m) ? matrix1.FMArray[i, j] : 0;
                float value2 = (i < (int)matrix2.n && j < (int)matrix2.m) ? matrix2.FMArray[i, j] : 0;
                result.FMArray[i, j] = value1 + value2;
            }
        }

        return result;
    }

    // Перевантаження інших операторів аналогічно
}
