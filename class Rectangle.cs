internal class Rectangle
{
    public int a { get; set; }
    public int b { get; set; }
    public string color { get; set; }

    public Rectangle(int a, int b, string color)
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
    public static Rectangle operator ++(Rectangle r)
    {
        r.a++;
        r.b++;
        return r;
    }

    public static Rectangle operator --(Rectangle r)
    {
        r.a--;
        r.b--;
        return r;
    }

    public static bool operator true(Rectangle r)
    {
        return r.a == r.b;
    }

    public static bool operator false(Rectangle r)
    {
        return r.a != r.b;
    }

    public static Rectangle operator *(Rectangle r, int scalar)
    {
        r.a *= scalar;
        r.b *= scalar;
        return r;
    }

    public static implicit operator string(Rectangle r)
    {
        return $"({r.a}, {r.b}) - {r.color}";
    }

    public static implicit operator Rectangle(string s)
    {
        string[] parts = s.Split(' ');
        return new Rectangle(int.Parse(parts[0]), int.Parse(parts[1]), parts[2]);
    }
}
