internal class Triangle
{
    public int a { get; set; }
    public int b { get; set; }
    public int c { get; set; }
    public string color { get; set; }

    public Triangle(int a, int b, int c, string color)
    {
        this.a = a;
        this.b = b;
        this.c = c;
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
                case 1: return b.ToString();
                case 2: return c.ToString();
                case 3: return color;
                default: return "Помилка: невірний індекс";
            }
        }
    }

    // Перевантаження операторів
    public static Triangle operator ++(Triangle t)
    {
        t.a++;
        t.b++;
        t.c++;
        return t;
    }

    public static Triangle operator --(Triangle t)
    {
        t.a--;
        t.b--;
        t.c--;
        return t;
    }

    public static bool operator true(Triangle t)
    {
        return t.a + t.b > t.c && t.a + t.c > t.b && t.b + t.c > t.a;
    }

    public static bool operator false(Triangle t)
    {
        return !(t.a + t.b > t.c && t.a + t.c > t.b && t.b + t.c > t.a);
    }

    public static Triangle operator *(Triangle t, int scalar)
    {
        t.a *= scalar;
        t.b *= scalar;
        t.c *= scalar;
        return t;
    }

    public static implicit operator string(Triangle t)
    {
        return $"({t.a}, {t.b}, {t.c}) - {t.color}";
    }

    public static implicit operator Triangle(string s)
    {
        string[] parts = s.Split(' ');
        return new Triangle(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), parts[3]);
    }
}
