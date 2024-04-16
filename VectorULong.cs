using System;

internal class VectorULong
{
    protected ulong[] IntArray;
    protected uint size;
    protected int codeError;
    protected static uint num_vec;

    // Конструктори
    public VectorULong()
    {
        IntArray = new ulong[1];
        size = 1;
        num_vec++;
    }

    public VectorULong(uint size)
    {
        IntArray = new ulong[size];
        this.size = size;
        num_vec++;
    }

    public VectorULong(uint size, ulong initValue)
    {
        IntArray = new ulong[size];
        this.size = size;
        num_vec++;
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = initValue;
        }
    }

    // Деструктор
    ~VectorULong()
    {
        Console.WriteLine("Об'єкт класу VectorULong знищений.");
    }

    // Методи
    public void Input()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Введіть елемент {i + 1}: ");
            IntArray[i] = ulong.Parse(Console.ReadLine());
        }
    }

    public void Output()
    {
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Елемент {i + 1}: {IntArray[i]}");
        }
    }

    public void SetValue(ulong value)
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
    public ulong this[int index]
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
    public static VectorULong operator ++(VectorULong v)
    {
        for (int i = 0; i < v.size; i++)
        {
            v.IntArray[i]++;
        }
        return v;
    }

    public static VectorULong operator --(VectorULong v)
    {
        for (int i = 0; i < v.size; i++)
        {
            v.IntArray[i]--;
        }
        return v;
    }

    public static bool operator true(VectorULong v)
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

    public static bool operator false(VectorULong v)
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

    public static bool operator !(VectorULong v)
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
        VectorULong v1 = new VectorULong(3, 5);
        VectorULong v2 = new VectorULong(3, 10);
        VectorULong sum = v1 + v2;

        Console.WriteLine("Вектор 1:");
        v1.Output();

        Console.WriteLine("\nВектор 2:");
        v2.Output();

        Console.WriteLine("\nСума векторів:");
        sum.Output();

        Console.WriteLine($"\nКількість створених векторів: {VectorULong.NumVec()}");
    }
}
