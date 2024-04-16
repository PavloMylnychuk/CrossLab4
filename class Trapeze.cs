internal class Trapeze
{
    public int a { get; set; }
    public int b { get; set; }
    public int h { get; set; }
    public string color { get; set; }

    public Trapeze(int a, int b, int h, string color)
    {
        this.a = a;
        this.b = b;
        this.h = h;
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
                case 2: return h.ToString();
                case 3: return color;
                default: return "Помилка: невірний індекс";
            }
        }
    }

    // Перевантаження операторів
    public static Trapeze operator ++(Trapeze t)
    {
        t.a++;
        t.b++;
        return t;
    }

    public static Trapeze operator --(Trapeze t)
    {
        t.a--;
        t.b--;
        return t;
    }

    public static bool operator true(Trapeze t)
    {
        return t.a != 0 && t.b != 0 && t.h != 0;
    }

    public static bool operator false(Trapeze t)
    {
        return t.a == 0 && t.b == 0 && t.h == 0;
    }

    public static Trapeze operator *(Trapeze t, int scalar)
    {
        t.a *= scalar;
        t.b *= scalar;
        t.h *= scalar;
        return t;
    }

    public static implicit operator string(Trapeze t)
    {
        return $"({t.a}, {t.b}, {t.h}) - {t.color}";
    }

    public static implicit operator Trapeze(string s)
    {
        string[] parts = s.Split(' ');
        return new Trapeze(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), parts[3]);
    }
}
