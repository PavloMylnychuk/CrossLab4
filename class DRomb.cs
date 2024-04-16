internal class DRomb
{
    public int d1 { get; set; }
    public int d2 { get; set; }
    public string color { get; set; }

    public DRomb(int d1, int d2, string color)
    {
        this.d1 = d1;
        this.d2 = d2;
        this.color = color;
    }

    // Індексатор
    public string this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return d1.ToString();
                case 1: return d2.ToString();
                case 2: return color;
                default: return "Помилка: невірний індекс";
            }
        }
    }

    // Перевантаження операторів
    public static DRomb operator ++(DRomb r)
    {
        r.d1++;
        r.d2++;
        return r;
    }

    public static DRomb operator --(DRomb r)
    {
        r.d1--;
        r.d2--;
        return r;
    }

    public static bool operator true(DRomb r)
    {
        return r.d1 == r.d2;
    }

    public static bool operator false(DRomb r)
    {
        return r.d1 != r.d2;
    }

    public static DRomb operator +(DRomb r, int scalar)
    {
        r.d1 += scalar;
        r.d2 += scalar;
        return r;
    }

    public static implicit operator string(DRomb r)
    {
        return $"({r.d1}, {r.d2}) - {r.color}";
    }

    public static implicit operator DRomb(string s)
    {
        string[] parts = s.Split(' ');
        return new DRomb(int.Parse(parts[0]), int.Parse(parts[1]), parts[2]);
    }
}
