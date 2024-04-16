using System;

internal class VectorFloat
{
    protected float[] FArray;
    protected uint num;
    protected int codeError;
    protected static uint num_vec;

    // Конструктори
    public VectorFloat()
    {
        FArray = new float[1];
        num = 1;
        num_vec++;
    }

    public VectorFloat(uint num)
    {
        FArray = new float[num];
        this.num = num;
        num_vec++;
    }

    public VectorFloat(uint num, float initValue)
    {
        FArray = new float[num];
        this.num = num;
        num_vec++;
        for (int i = 0; i < num; i++)
        {
            FArray[i] = initValue;
        }
    }

    // Деструктор
    ~VectorFloat()
    {
        Console.WriteLine("Об'єкт класу VectorFloat знищений.");
    }

    // Методи
    public void Input()
    {
        for (int i = 0; i < num; i++)
        {
            Console.Write($"Введіть елемент {i + 1}: ");
            FArray[i] = float.Parse(Console.ReadLine());
        }
    }

    public void Output()
    {
        for (int i = 0; i < num; i++)
        {
            Console.WriteLine($"Елемент {i + 1}: {FArray[i]}");
        }
    }

    public void SetValue(float value)
    {
        for (int i = 0; i < num; i++)
        {
            FArray[i] = value;
        }
    }

    public static uint NumVec()
    {
        return num_vec;
    }

    // Властивості
    public uint Num => num;

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public float this[int index]
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
    public static VectorFloat operator ++(VectorFloat v)
    {
        for (int i = 0; i < v.num; i++)
        {
            v.FArray[i]++;
        }
        return v;
    }

    public static VectorFloat operator --(VectorFloat v)
    {
        for (int i = 0; i < v.num; i++)
        {
            v.FArray[i]--;
        }
        return v;
    }

    public static bool operator true(VectorFloat v)
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

    public static bool operator false(VectorFloat v)
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

    public static bool operator !(VectorFloat v)
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
