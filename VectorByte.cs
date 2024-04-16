using System;

internal class VectorByte
{
    protected byte[] BArray;
    protected uint n;
    protected int codeError;
    protected static uint num_vec;

    // Конструктори
    public VectorByte()
    {
        BArray = new byte[1];
        n = 1;
        num_vec++;
    }

    public VectorByte(uint n)
    {
        BArray = new byte[n];
        this.n = n;
        num_vec++;
    }

    public VectorByte(uint n, byte initValue)
    {
        BArray = new byte[n];
        this.n = n;
        num_vec++;
        for (int i = 0; i < n; i++)
        {
            BArray[i] = initValue;
        }
    }

    // Деструктор
    ~VectorByte()
    {
        Console.WriteLine("Об'єкт класу VectorByte знищений.");
    }

    // Методи
    public void Input()
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введіть елемент {i + 1}: ");
            BArray[i] = byte.Parse(Console.ReadLine());
        }
    }

    public void Output()
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Елемент {i + 1}: {BArray[i]}");
        }
    }

    public void SetValue(byte value)
    {
        for (int i = 0; i < n; i++)
        {
            BArray[i] = value;
        }
    }

    public static uint NumVec()
    {
        return num_vec;
    }

    // Властивості
    public uint Num => n;

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public byte this[int index]
    {
        get
        {
            if (index >= 0 && index < n)
            {
                return BArray[index];
            }
            else
            {
                codeError = 1;
                return 0;
            }
        }
        set
        {
            if (index >= 0 && index < n)
            {
                BArray[index] = value;
            }
            else
            {
                codeError = 1;
            }
        }
    }

    // Перевантаження операторів
    public static VectorByte operator ++(VectorByte v)
    {
        for (int i = 0; i < v.n; i++)
        {
            v.BArray[i]++;
        }
        return v;
    }

    public static VectorByte operator --(VectorByte v)
    {
        for (int i = 0; i < v.n; i++)
        {
            v.BArray[i]--;
        }
        return v;
    }

    public static bool operator true(VectorByte v)
    {
        for (int i = 0; i < v.n; i++)
        {
            if (v.BArray[i] == 0)
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator false(VectorByte v)
    {
        for (int i = 0; i < v.n; i++)
        {
            if (v.BArray[i] != 0)
            {
                return true;
            }
        }
        return false;
    }

    public static bool operator !(VectorByte v)
    {
        for (int i = 0; i < v.n; i++)
        {
            if (v.BArray[i] == 0)
            {
                return true;
            }
        }
        return false;
    }

    public static VectorByte operator +(VectorByte v1, VectorByte v2)
    {
        if (v1.n != v2.n)
        {
            throw new ArgumentException("Вектори мають різну довжину.");
        }

        VectorByte result = new VectorByte(v1.n);
        for (int i = 0; i < v1.n; i++)
        {
            result[i] = (byte)(v1[i] + v2[i]);
        }
        return result;
    }

    public static VectorByte operator +(VectorByte v, byte scalar)
    {
        VectorByte result = new VectorByte(v.n);
        for (int i = 0; i < v.n; i++)
        {
            result[i] = (byte)(v[i] + scalar);
        }
        return result;
    }

    public static VectorByte operator -(VectorByte v1, VectorByte v2)
    {
        if (v1.n != v2.n)
        {
            throw new ArgumentException("Вектори мають різну довжину.");
        }

        VectorByte result = new VectorByte(v1.n);
        for (int i = 0; i < v1.n; i++)
        {
            result[i] = (byte)(v1[i] - v2[i]);
        }
        return result;
    }

    public static VectorByte operator -(VectorByte v, byte scalar)
    {
        VectorByte result = new VectorByte(v.n);
        for (int i = 0; i < v.n; i++)
        {
            result[i] = (byte)(v[i] - scalar);
        }
        return result;
    }

    public static VectorByte operator *(VectorByte v1, VectorByte v2)
    {
        if (v1.n != v2.n)
        {
            throw new ArgumentException("Вектори мають різну довжину.");
        }

        VectorByte result = new VectorByte(v1.n);
        for (int i = 0; i < v1.n; i++)
        {
            result[i] = (byte)(v1[i] * v2[i]);
        }
        return result;
    }

    public static VectorByte operator *(VectorByte v, byte scalar)
    {
        VectorByte result = new VectorByte(v.n);
        for (int i = 0; i < v.n; i++)
        {
            result[i] = (byte)(v[i] * scalar);
        }
        return result;
    }

    public static VectorByte operator /(VectorByte v1, VectorByte v2)
    {
        if (v1.n != v2.n)
        {
            throw new ArgumentException("Вектори мають різну довжину.");
        }

        VectorByte result = new VectorByte(v1.n);
        for (int i = 0; i < v1.n; i++)
        {
            if (v2[i] == 0)
            {
                throw new DivideByZeroException("Ділення на нуль.");
            }
            result[i] = (byte)(v1[i] / v2[i]);
        }
        return result;
    }

    public static VectorByte operator /(VectorByte v, byte scalar)
    {
        if (scalar == 0)
        {
            throw new DivideByZeroException("Ділення на нуль.");
        }

        VectorByte result = new VectorByte(v.n);
        for (int i = 0; i < v.n; i++)
        {
            result[i] = (byte)(v[i] / scalar);
        }
        return result;
    }

    public static VectorByte operator %(VectorByte v1, VectorByte v2)
    {
        if (v1.n != v2.n)
        {
            throw new ArgumentException("Вектори мають різну довжину.");
        }

        VectorByte result = new VectorByte(v1.n);
        for (int i = 0; i < v1.n; i++)
        {
            if (v2[i] == 0)
            {
                throw new DivideByZeroException("Ділення на нуль.");
            }
            result[i] = (byte)(v1[i] % v2[i]);
        }
        return result;
    }

    public static VectorByte operator %(VectorByte v, byte scalar)
    {
        if (scalar == 0)
        {
            throw new DivideByZeroException("Ділення на нуль.");
        }

        VectorByte result = new VectorByte(v.n);
        for (int i = 0; i < v.n; i++)
        {
            result[i] = (byte)(v[i] % scalar);
        }
        return result;
    }

    public static VectorByte operator |(VectorByte v1, VectorByte v2)
    {
        if (v1.n != v2.n)
        {
            throw new ArgumentException("Вектори мають різну довжину.");
        }

        VectorByte result = new VectorByte(v1.n);
        for (int i = 0; i < v1.n; i++)
        {
            result[i] = (byte)(v1[i] | v2[i]);
        }
        return result;
    }

    public static VectorByte operator |(VectorByte v, byte scalar)
    {
        VectorByte result = new VectorByte(v.n);
        for (int i = 0; i < v.n; i++)
        {
            result[i] = (byte)(v[i] | scalar);
        }
        return result;
    }

    public static VectorByte operator ^(VectorByte v1, VectorByte v2)
    {
        if (v1.n != v2.n)
        {
            throw new ArgumentException("Вектори мають різну довжину.");
        }

        VectorByte result = new VectorByte(v1.n);
        for (int i = 0; i < v1.n; i++)
        {
            result[i] = (byte)(v1[i] ^ v2[i]);
        }
        return result;
    }

    public static VectorByte operator ^(VectorByte v, byte scalar)
    {
        VectorByte result = new VectorByte(v.n);
        for (int i = 0; i < v.n; i++)
        {
            result[i] = (byte)(v[i] ^ scalar);
        }
        return result;
    }

    public static VectorByte operator >>(VectorByte v1, VectorByte v2)
    {
        if (v1.n != v2.n)
        {
            throw new ArgumentException("Вектори мають різну довжину.");
        }

        VectorByte result = new VectorByte(v1.n);
        for (int i = 0; i < v1.n; i++)
        {
            result[i] = (byte)(v1[i] >> v2[i]);
        }
        return result;
    }

    public static VectorByte operator >>(VectorByte v, byte scalar)
    {
        VectorByte result = new VectorByte(v.n);
        for (int i = 0; i < v.n; i++)
        {
            result[i] = (byte)(v[i] >> scalar);
        }
        return result;
    }

    public static VectorByte operator <<(VectorByte v1, VectorByte v2)
    {
        if (v1.n != v2.n)
        {
            throw new ArgumentException("Вектори мають різну довжину.");
        }

        VectorByte result = new VectorByte(v1.n);
        for (int i = 0; i < v1.n; i++)
        {
            result[i] = (byte)(v1[i] << v2[i]);
        }
        return result;
    }

    public static VectorByte operator <<(VectorByte v, byte scalar)
    {
        VectorByte result = new VectorByte(v.n);
        for (int i = 0; i < v.n; i++)
        {
            result[i] = (byte)(v[i] << scalar);
        }
        return result;
    }

    public static bool operator ==(VectorByte v1, VectorByte v2)
    {
        if (v1.n != v2.n)
        {
            return false;
        }

        for (int i = 0; i < v1.n; i++)
        {
            if (v1[i] != v2[i])
            {
                return false;
            }
        }

        return true;
    }

    public static bool operator !=(VectorByte v1, VectorByte v2)
    {
        return !(v1 == v2);
    }

    public static bool operator >(VectorByte v1, VectorByte v2)
    {
        if (v1.n != v2.n)
        {
            throw new ArgumentException("Вектори мають різну довжину.");
        }

        for (int i = 0; i < v1.n; i++)
        {
            if (v1[i] <= v2[i])
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator >=(VectorByte v1, VectorByte v2)
    {
        if (v1.n != v2.n)
        {
            throw new ArgumentException("Вектори мають різну довжину.");
        }

        for (int i = 0; i < v1.n; i++)
        {
            if (v1[i] < v2[i])
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator <(VectorByte v1, VectorByte v2)
    {
        if (v1.n != v2.n)
        {
            throw new ArgumentException("Вектори мають різну довжину.");
        }

        for (int i = 0; i < v1.n; i++)
        {
            if (v1[i] >= v2[i])
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator <=(VectorByte v1, VectorByte v2)
    {
        if (v1.n != v2.n)
        {
            throw new ArgumentException("Вектори мають різну довжину.");
        }

        for (int i = 0; i < v1.n; i++)
        {
            if (v1[i] > v2[i])
            {
                return false;
            }
        }
        return true;
    }
}
