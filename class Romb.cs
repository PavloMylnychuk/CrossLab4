internal class Romb
{
    public int a { get; set; }
    public int d1 { get; set; }
    public string color { get; set; }

    public Romb(int a, int d1, string color)
    {
        this.a = a;
        this.d1 = d1;
        this.color = color;
    }

    // Індексатор
    public string this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return a.ToString();
                case 1: return d1.ToString();
                case 2: return color;
                default: return "Помилка: невірний індекс";
            }
        }
    }

    // Перевантаження операторів
    public static Romb operator ++(Romb r)
    {
        r.a++;
        r.d1++;
        return r;
    }

    public static Romb operator --(Romb r)
    {
        r.a--;
        r.d1--;
        return r;
    }

    public static bool operator true(Romb r)
    {
        return r.a == r.d1;
    }

    public static bool operator false(Romb r)
    {
        return r.a != r.d1;
    }

    public static Romb operator *(Romb r, int scalar)
    {
        r.a *= scalar;
        r.d1 *= scalar;
        return r;
    }

    public static implicit operator string(Romb r)
    {
        return $"({r.a}, {r.d1}) - {r.color}";
    }

    public static implicit operator Romb(string s)
    {
        string[] parts = s.Split(' ');
        return new Romb(int.Parse(parts[0]), int.Parse(parts[1]), parts[2]);
    }
}
