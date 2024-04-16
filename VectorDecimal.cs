using System;

internal class VectorDecimal
{
    protected decimal[] ArrayDecimal;
    protected uint num;
    protected int codeError;
    protected static uint num_vec;

    // Конструктори
    public VectorDecimal()
    {
        ArrayDecimal = new decimal[1];
        num = 1;
        num_vec++;
    }

    public VectorDecimal(uint num)
    {
        ArrayDecimal = new decimal[num];
        this.num = num;
        num_vec++;
    }

    public VectorDecimal(uint num, decimal initValue)
    {
        ArrayDecimal = new decimal[num];
        this.num = num;
        num_vec++;
        for (int i = 0; i < num; i++)
        {
            ArrayDecimal[i] = initValue;
        }
    }

    // Деструктор
    ~VectorDecimal()
    {
        Console.WriteLine("Об'єкт класу VectorDecimal знищений.");
    }

    // Методи
    public void Input()
    {
        for (int i = 0; i < num; i++)
        {
            Console.Write($"Введіть елемент {i + 1}: ");
            ArrayDecimal[i] = decimal.Parse(Console.ReadLine());
        }
    }

    public void Output()
    {
        for (int i = 0; i < num; i++)
        {
            Console.WriteLine($"Елемент {i + 1}: {ArrayDecimal[i]}");
        }
    }

    public void SetValue(decimal value)
    {
        for (int i = 0; i < num; i++)
        {
            ArrayDecimal[i] = value;
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
    public decimal this[int index]
    {
        get
        {
            if (index >= 0 && index < num)
            {
                return ArrayDecimal[index];
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
                ArrayDecimal[index] = value;
            }
            else
            {
                codeError = 1;
            }
        }
    }

    // Перевантаження операторів
    public static VectorDecimal operator ++(VectorDecimal v)
    {
        for (int i = 0; i < v.num; i++)
        {
            v.ArrayDecimal[i]++;
        }
        return v;
    }

    public static VectorDecimal operator --(VectorDecimal v)
    {
        for (int i = 0; i < v.num; i++)
        {
            v.ArrayDecimal[i]--;
        }
        return v;
    }

    public static bool operator true(VectorDecimal v)
    {
        for (int i = 0; i < v.num; i++)
        {
            if (v.ArrayDecimal[i] == 0)
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator false(VectorDecimal v)
    {
        for (int i = 0; i < v.num; i++)
        {
            if (v.ArrayDecimal[i] != 0)
            {
                return true;
            }
        }
        return false;
    }

    public static bool operator !(VectorDecimal v)
    {
        for (int i = 0; i < v.num; i++)
        {
            if (v.ArrayDecimal[i] == 0)
            {
                return true;
            }
        }
        return false;
    }

    // Додаткові перевантаження та інші оператори можна додати за потреби
}
