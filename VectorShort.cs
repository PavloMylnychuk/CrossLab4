using System;

internal class VectorShort
{
    protected short[] ShortArray;
    protected uint n;
    protected uint codeError;
    protected static uint num_v;

    // Конструктори
    public VectorShort()
    {
        ShortArray = new short[1];
        n = 1;
        num_v++;
    }

    public VectorShort(uint size)
    {
        ShortArray = new short[size];
        n = size;
        num_v++;
    }

    public VectorShort(uint size, short initValue)
    {
        ShortArray = new short[size];
        n = size;
        num_v++;
        for (int i = 0; i < size; i++)
        {
            ShortArray[i] = initValue;
        }
    }

    // Деструктор
    ~VectorShort()
    {
        Console.WriteLine("Об'єкт класу VectorShort знищений.");
    }

    // Методи
    public void Input()
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введіть елемент {i + 1}: ");
            ShortArray[i] = short.Parse(Console.ReadLine());
        }
    }

    public void Output()
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Елемент {i + 1}: {ShortArray[i]}");
        }
    }

    public void SetValue(short value)
    {
        for (int i = 0; i < n; i++)
        {
            ShortArray[i] = value;
        }
    }

    public static uint NumV()
    {
        return num_v;
    }

    // Властивості
    public uint Size => n;

    public uint CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public short this[int index]
    {
        get
        {
            if (index >= 0 && index < n)
            {
                return ShortArray[index];
            }
            else
            {
                codeError = -10;
                return 0;
            }
        }
        set
        {
            if (index >= 0 && index < n)
            {
                ShortArray[index] = value;
            }
            else
            {
                codeError = -10;
            }
        }
    }

    // Перевантаження операторів
    public static VectorShort operator ++(VectorShort v)
    {
        for (int i = 0; i < v.n; i++)
        {
            v.ShortArray[i]++;
        }
        return v;
    }

    public static VectorShort operator --(VectorShort v)
    {
        for (int i = 0; i < v.n; i++)
        {
            v.ShortArray[i]--;
        }
        return v;
    }

    public static bool operator true(VectorShort v)
    {
        for (int i = 0; i < v.n; i++)
        {
            if (v.ShortArray[i] == 0)
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator false(VectorShort v)
    {
        for (int i = 0; i < v.n; i++)
        {
            if (v.ShortArray[i] != 0)
            {
                return true;
            }
        }
        return false;
    }

    public static bool operator !(VectorShort v)
    {
        for (int i = 0; i < v.n; i++)
        {
            if (v.ShortArray[i] == 0)
            {
                return true;
            }
        }
        return false;
    }

    public static VectorShort operator +(VectorShort v1, VectorShort v2)
    {
        uint maxSize = Math.Max(v1.n, v2.n);
        VectorShort result = new VectorShort(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            result[i] = (i < v1.n ? v1[i] : (short)0) + (i < v2.n ? v2[i] : (short)0);
        }
        return result;
    }

    public static VectorShort operator +(VectorShort v, short scalar)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
        {
            result[i] = (short)(v[i] + scalar);
        }
        return result;
    }

    // Додаткові перевантаження та інші оператори можна додати за потреби

    // Тестування
    public static void Main(string[] args)
    {
        VectorShort v1 = new VectorShort(3, 5);
        VectorShort v2 = new VectorShort(3, 10);
        VectorShort sum = v1 + v2;

        Console.WriteLine("Вектор 1:");
        v1.Output();

        Console.WriteLine("\nВектор 2:");
        v2.Output();

        Console.WriteLine("\nСума векторів:");
        sum.Output();

        Console.WriteLine($"\nКількість створених векторів: {VectorShort.NumV()}");
    }
}
