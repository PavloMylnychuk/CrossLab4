using System;

internal class VectorInt
{
    protected int[] IntArray;
    protected uint size;
    protected int codeError;
    protected static uint num_vec;

    // Конструктори
    public VectorInt()
    {
        IntArray = new int[1];
        size = 1;
        num_vec++;
    }

    public VectorInt(uint size)
    {
        IntArray = new int[size];
        this.size = size;
        num_vec++;
    }

    public VectorInt(uint size, int initValue)
    {
        IntArray = new int[size];
        this.size = size;
        num_vec++;
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = initValue;
        }
    }

    // Деструктор
    ~VectorInt()
    {
        Console.WriteLine("Об'єкт класу VectorInt знищений.");
    }

    // Методи
    public void Input()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Введіть елемент {i + 1}: ");
            IntArray[i] = int.Parse(Console.ReadLine());
        }
    }

    public void Output()
    {
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Елемент {i + 1}: {IntArray[i]}");
        }
    }

    public void SetValue(int value)
    {
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = value;
        }
    }

    public static uint NumVec()
    {
        return num_vec;
    }

    // Властивості
    public uint Size => size;

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public int this[int index]
    {
        get
        {
            if (index >= 0 && index < size)
            {
                return IntArray[index];
            }
            else
            {
                codeError = -1;
                return 0;
            }
        }
        set
        {
            if (index >= 0 && index < size)
            {
                IntArray[index] = value;
            }
            else
            {
                codeError = -1;
            }
        }
    }

    // Перевантаження операторів
    public static VectorInt operator ++(VectorInt v)
    {
        for (int i = 0; i < v.size; i++)
        {
            v.IntArray[i]++;
        }
        return v;
    }

    public static VectorInt operator --(VectorInt v)
    {
        for (int i = 0; i < v.size; i++)
        {
            v.IntArray[i]--;
        }
        return v;
    }

    public static bool operator true(VectorInt v)
    {
        for (int i = 0; i < v.size; i++)
        {
            if (v.IntArray[i] == 0)
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator false(VectorInt v)
    {
        for (int i = 0; i < v.size; i++)
        {
            if (v.IntArray[i] != 0)
            {
                return true;
            }
        }
        return false;
    }

    public static bool operator !(VectorInt v)
    {
        for (int i = 0; i < v.size; i++)
        {
            if (v.IntArray[i] == 0)
            {
                return true;
            }
        }
        return false;
    }

    public static VectorInt operator +(VectorInt v1, VectorInt v2)
    {
        uint maxSize = Math.Max(v1.size, v2.size);
        VectorInt result = new VectorInt(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            result[i] = (i < v1.size ? v1[i] : 0) + (i < v2.size ? v2[i] : 0);
        }
        return result;
    }

    public static VectorInt operator +(VectorInt v, int scalar)
    {
        VectorInt result = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
        {
            result[i] = v[i] + scalar;
        }
        return result;
    }

    // Додаткові перевантаження та інші оператори можна додати за потреби

    // Тестування
    public static void Main(string[] args)
    {
        VectorInt v1 = new VectorInt(3, 5);
        VectorInt v2 = new VectorInt(3, 10);
        VectorInt sum = v1 + v2;

        Console.WriteLine("Вектор 1:");
        v1.Output();

        Console.WriteLine("\nВектор 2:");
        v2.Output();

        Console.WriteLine("\nСума векторів:");
        sum.Output();

        Console.WriteLine($"\nКількість створених векторів: {VectorInt.NumVec()}");
    }
}
