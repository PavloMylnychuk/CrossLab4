internal class Money
{
    public int first { get; set; }
    public int second { get; set; }

    public Money(int first, int second)
    {
        this.first = first;
        this.second = second;
    }

    // Індексатор
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return first;
                case 1: return second;
                default: throw new IndexOutOfRangeException("Невірний індекс");
            }
        }
    }

    // Перевантаження операторів
    public static Money operator ++(Money m)
    {
        m.first++;
        m.second++;
        return m;
    }

    public static Money operator --(Money m)
    {
        m.first--;
        m.second--;
        return m;
    }

    public static bool operator !(Money m)
    {
        return m.second != 0;
    }

    public static Money operator +(Money m, int scalar)
    {
        m.second += scalar;
        return m;
    }

    public static implicit operator string(Money m)
    {
        return $"({m.first}, {m.second})";
    }

    public static implicit operator Money(string s)
    {
        string[] parts = s.Split(' ');
        return new Money(int.Parse(parts[0]), int.Parse(parts[1]));
    }
}
