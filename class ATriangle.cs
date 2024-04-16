internal class ATriangle
{
    public int a { get; set; }
    public int b { get; set; }
    public string color { get; set; }

    public ATriangle(int a, int b, string color)
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
    public static ATriangle operator ++(ATriangle t)
    {
        t.a++;
        t.b++;
        return t;
    }

    public static ATriangle operator --(ATriangle t)
    {
        t.a--;
        t.b--;
        return t;
    }

    public static bool operator true(ATriangle t)
    {
        return t.a * t.a + t.b * t.b == 5 * 5; // Перевірка на прямокутний трикутник
    }

    public static bool operator false(ATriangle t)
    {
        return t.a * t.a + t.b * t.b != 5 * 5;
    }

    public static ATriangle operator +(ATriangle t, int scalar)
    {
        t.a += scalar;
        t.b += scalar;
        return t;
    }

    public static implicit operator string(ATriangle t)
    {
        return $"({t.a}, {t.b}) - {t.color}";
    }

    public static implicit operator ATriangle(string s)
    {
        string[] parts = s.Split(' ');
        return new ATriangle(int.Parse(parts[0]), int.Parse(parts[1]), parts[2]);
    }
}
