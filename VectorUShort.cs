using System;

internal class VectorUshort
{
    protected ushort[] ArrayUShort;
    protected uint num;
    protected uint codeError;
    protected static uint num_vs;

    // Конструктори
    public VectorUshort()
    {
        ArrayUShort = new ushort[1];
        num = 1;
        num_vs++;
    }

    public VectorUshort(uint size)
    {
        ArrayUShort = new ushort[size];
        num = size;
        num_vs++;
    }

    public VectorUshort(uint size, ushort initValue)
    {
        ArrayUShort = new ushort[size];
        num = size;
        num_vs++;
        for (int i = 0; i < size; i++)
        {
            ArrayUShort[i] = initValue;
        }
    }

    // Деструктор
    ~VectorUshort()
    {
        Console.WriteLine("Об'єкт класу VectorUshort знищений.");
    }

    // Методи
    public void Input()
    {
        for (int i = 0; i < num; i++)
        {
            Console.Write($"Введіть елемент {i + 1}: ");
            ArrayUShort[i] = ushort.Parse(Console.ReadLine());
        }
    }

    public void Output()
    {
        for (int i = 0; i < num; i++)
        {
            Console.WriteLine($"Елемент {i + 1}: {ArrayUShort[i]}");
        }
    }

    public void SetValue(ushort value)
    {
        for (int i = 0; i < num; i++)
        {
            ArrayUShort[i] = value;
        }
    }

    public static uint NumVs()
    {
        return num_vs;
    }

    // Властивості
    public uint Size => num;

    public uint CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public ushort this[int index]
    {
        get
        {
            if (index >= 0 && index < num)
            {
                return ArrayUShort[index];
            }
            else
            {
                codeError = 1;
                return 0;
            }
        }
        set
        {
            if (index >= 0 && index < num)
            {
                ArrayUShort[index] = value;
            }
            else
            {
                codeError = 1;
            }
        }
    }

    // Перевантаження операторів
    public static VectorUshort operator ++(VectorUshort v)
    {
        for (int i = 0; i < v.num; i++)
        {
            v.ArrayUShort[i]++;
        }
        return v;
    }

    public static VectorUshort operator --(VectorUshort v)
    {
        for (int i = 0; i < v.num; i++)
        {
            v.ArrayUShort[i]--;
        }
        return v;
    }

    public static bool operator true(VectorUshort v)
    {
        for (int i = 0; i < v.num; i++)
        {
            if (v.ArrayUShort[i] == 0)
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator false(VectorUshort v)
    {
        for (int i = 0; i < v.num; i++)
        {
            if (v.ArrayUShort[i] != 0)
            {
                return true;
            }
        }
        return false;
    }

    public static bool operator !(VectorUshort v)
    {
        for (int i = 0; i < v.num; i++)
        {
            if (v.ArrayUShort[i] == 0)
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
        VectorUshort v1 = new VectorUshort(3, 5);
        VectorUshort v2 = new VectorUshort(3, 10);
        VectorUshort sum = v1 + v2;

        Console.WriteLine("Вектор 1:");
        v1.Output();

        Console.WriteLine("\nВектор 2:");
        v2.Output();

        Console.WriteLine("\nСума векторів:");
        sum.Output();

        Console.WriteLine($"\nКількість створених векторів: {VectorUshort.NumVs()}");
    }
}
