using System;

internal class VectorLong
{
    protected long[] IntArray;
    protected uint size;
    protected int codeError;
    protected static uint num_vl;

    // Конструктори
    public VectorLong()
    {
        IntArray = new long[1];
        size = 1;
        num_vl++;
    }

    public VectorLong(uint size)
    {
        IntArray = new long[size];
        this.size = size;
        num_vl++;
    }

    public VectorLong(uint size, long initValue)
    {
        IntArray = new long[size];
        this.size = size;
        num_vl++;
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = initValue;
        }
    }

    // Деструктор
    ~VectorLong()
    {
        Console.WriteLine("Об'єкт класу VectorLong знищений.");
    }

    // Методи
    public void Input()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Введіть елемент {i + 1}: ");
            IntArray[i] = long.Parse(Console.ReadLine());
        }
    }

    public void Output()
    {
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Елемент {i + 1}: {IntArray[i]}");
        }
    }

    public void SetValue(long value)
    {
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = value;
        }
    }

    public static uint NumVl()
    {
        return num_vl;
    }

    // Властивості
    public uint Size => size;

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public long this[int index]
    {
        get
        {
            if (index >= 0 && index < size)
            {
                return IntArray[index];
            }
            else
            {
                codeError = 1;
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
                codeError = 1;
            }
        }
    }

    // Перевантаження операторів
    public static VectorLong operator ++(VectorLong v)
    {
        for (int i = 0; i < v.size; i++)
        {
            v.IntArray[i]++;
        }
        return v;
    }

    public static VectorLong operator --(VectorLong v)
    {
        for (int i = 0; i < v.size; i++)
        {
            v.IntArray[i]--;
        }
        return v;
    }

    public static bool operator true(VectorLong v)
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

    public static bool operator false(VectorLong v)
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

    public static bool operator !(VectorLong v)
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

    // Додаткові перевантаження та інші оператори можна додати за потреби

    // Тестування
    public static void Main(string[] args)
    {
        VectorLong v1 = new VectorLong(3, 5);
        VectorLong v2 = new VectorLong(3, 10);
        VectorLong sum = v1 + v2;

        Console.WriteLine("Вектор 1:");
        v1.Output();

        Console.WriteLine("\nВектор 2:");
        v2.Output();

        Console.WriteLine("\nСума векторів:");
        sum.Output();

        Console.WriteLine($"\nКількість створених векторів: {VectorLong.NumVl()}");
    }
}
