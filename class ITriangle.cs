internal class ITriangle
{
    public int a { get; set; }
    public int b { get; set; }
    public string color { get; set; }

    public ITriangle(int a, int b, string color)
    {
        this.a = a;
        this.b = b;
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
                case 2: return color;
                default: return "Помилка: невірний індекс";
            }
        }
    }

    // Перевантаження операторів
    public static ITriangle operator ++(ITriangle t)
    {
        t.a++;
        t.b++;
        return t;
    }

    public static ITriangle operator --(ITriangle t)
    {
        t.a--;
        t.b--;
        return t;
    }

    public static bool operator true(ITriangle t)
    {
        return t.a == t.b;
    }

    public static bool operator false(ITriangle t)
    {
        return t.a != t.b;
    }

    public static ITriangle operator *(ITriangle t, int scalar)
    {
        t.a *= scalar;
        t.b *= scalar;
        return t;
    }

    public static implicit operator string(ITriangle t)
    {
        return $"({t.a}, {t.b}) - {t.color}";
    }

    public static implicit operator ITriangle(string s)
    {
        string[] parts = s.Split(' ');
        return new ITriangle(int.Parse(parts[0]), int.Parse(parts[1]), parts[2]);
    }
}
