using System;

internal class VectorDouble
{
    protected double[] FArray;
    protected uint num;
    protected int codeError;
    protected static uint num_vd;

    // Конструктори
    public VectorDouble()
    {
        FArray = new double[1];
        num = 1;
        num_vd++;
    }

    public VectorDouble(uint num)
    {
        FArray = new double[num];
        this.num = num;
        num_vd++;
    }

    public VectorDouble(uint num, double initValue)
    {
        FArray = new double[num];
        this.num = num;
        num_vd++;
        for (int i = 0; i < num; i++)
        {
            FArray[i] = initValue;
        }
    }

    // Деструктор
    ~VectorDouble()
    {
        Console.WriteLine("Об'єкт класу VectorDouble знищений.");
    }

    // Методи
    public void Input()
    {
        for (int i = 0; i < num; i++)
        {
            Console.Write($"Введіть елемент {i + 1}: ");
            FArray[i] = double.Parse(Console.ReadLine());
        }
    }

    public void Output()
    {
        for (int i = 0; i < num; i++)
        {
            Console.WriteLine($"Елемент {i + 1}: {FArray[i]}");
        }
    }

    public void SetValue(double value)
    {
        for (int i = 0; i < num; i++)
        {
            FArray[i] = value;
        }
    }

    public static uint NumVec()
    {
        return num_vd;
    }

    // Властивості
    public uint Num => num;

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public double this[int index]
    {
        get
        {
            if (index >= 0 && index < num)
            {
                return FArray[index];
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
                FArray[index] = value;
            }
            else
            {
                codeError = 1;
            }
        }
    }

    // Перевантаження операторів
    public static VectorDouble operator ++(VectorDouble v)
    {
        for (int i = 0; i < v.num; i++)
        {
            v.FArray[i]++;
        }
        return v;
    }

    public static VectorDouble operator --(VectorDouble v)
    {
        for (int i = 0; i < v.num; i++)
        {
            v.FArray[i]--;
        }
        return v;
    }

    public static bool operator true(VectorDouble v)
    {
        for (int i = 0; i < v.num; i++)
        {
            if (v.FArray[i] == 0)
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator false(VectorDouble v)
    {
        for (int i = 0; i < v.num; i++)
        {
            if (v.FArray[i] != 0)
            {
                return true;
            }
        }
        return false;
    }

    public static bool operator !(VectorDouble v)
    {
        for (int i = 0; i < v.num; i++)
        {
            if (v.FArray[i] == 0)
            {
                return true;
            }
        }
        return false;
    }

    // Додаткові перевантаження та інші оператори можна додати за потреби
}
