internal class Point
{
    public int x { get; set; }
    public int y { get; set; }
    public string color { get; set; }

    public Point(int x, int y, string color)
    {
        this.x = x;
        this.y = y;
        this.color = color;
    }

    // Індексатор
    public string this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return x.ToString();
                case 1: return y.ToString();
                case 2: return color;
                default: return "Помилка: невірний індекс";
            }
        }
    }

    // Перевантаження операторів
    public static Point operator ++(Point p)
    {
        p.x++;
        p.y++;
        return p;
    }

    public static Point operator --(Point p)
    {
        p.x--;
        p.y--;
        return p;
    }

    public static bool operator true(Point p)
    {
        return p.x == p.y;
    }

    public static bool operator false(Point p)
    {
        return p.x != p.y;
    }

    public static Point operator +(Point p, int scalar)
    {
        p.x += scalar;
        p.y += scalar;
        return p;
    }

    public static implicit operator string(Point p)
    {
        return $"({p.x}, {p.y}) - {p.color}";
    }

    public static implicit operator Point(string s)
    {
        string[] parts = s.Split(' ');
        return new Point(int.Parse(parts[0]), int.Parse(parts[1]), parts[2]);
    }
}
