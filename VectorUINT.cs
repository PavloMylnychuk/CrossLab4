using System;

internal class VectorUInt
{
    protected uint[] IntArray;
    protected uint size;
    protected int codeError;
    protected static uint num_vec;

    // Конструктори
    public VectorUInt()
    {
        IntArray = new uint[1];
        size = 1;
        num_vec++;
    }

    public VectorUInt(uint size)
    {
        IntArray = new uint[size];
        this.size = size;
        num_vec++;
    }

    public VectorUInt(uint size, uint initValue)
    {
        IntArray = new uint[size];
        this.size = size;
        num_vec++;
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = initValue;
        }
    }

    // Деструктор
    ~VectorUInt()
    {
        Console.WriteLine("Об'єкт класу VectorUInt знищений.");
    }

    // Методи
    public void Input()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Введіть елемент {i + 1}: ");
            IntArray[i] = uint.Parse(Console.ReadLine());
        }
    }

    public void Output()
    {
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Елемент {i + 1}: {IntArray[i]}");
        }
    }

    public void SetValue(uint value)
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
    public uint this[int index]
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
    public static VectorUInt operator ++(VectorUInt v)
    {
        for (int i = 0; i < v.size; i++)
        {
            v.IntArray[i]++;
        }
        return v;
    }

    public static VectorUInt operator --(VectorUInt v)
    {
        for (int i = 0; i < v.size; i++)
        {
            v.IntArray[i]--;
        }
        return v;
    }

    public static bool operator true(VectorUInt v)
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

    public static bool operator false(VectorUInt v)
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

    public static bool operator !(VectorUInt v)
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

    public static VectorUInt operator +(VectorUInt v1, VectorUInt v2)
    {
        uint maxSize = Math.Max(v1.size, v2.size);
        VectorUInt result = new VectorUInt(maxSize);
        for (int i = 0; i < maxSize; i++)
        {
            result[i] = (i < v1.size ? v1[i] : 0) + (i < v2.size ? v2[i] : 0);
        }
        return result;
    }

    public static VectorUInt operator +(VectorUInt v, uint scalar)
    {
        VectorUInt result = new VectorUInt(v.size);
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
        VectorUInt v1 = new VectorUInt(3, 5);
        VectorUInt v2 = new VectorUInt(3, 10);
        VectorUInt sum = v1 + v2;

        Console.WriteLine("Вектор 1:");
        v1.Output();

        Console.WriteLine("\nВектор 2:");
        v2.Output();

        Console.WriteLine("\nСума векторів:");
        sum.Output();

        Console.WriteLine($"\nКількість створених векторів: {VectorUInt.NumVec()}");
    }
}
