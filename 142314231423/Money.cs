public class Money
{
    public long Rubles { get; private set; }
    public byte Kopecks { get; private set; }

    public Money(long rubles, byte kopecks)
    {
        Rubles = rubles;
        Kopecks = kopecks;
    }

    public override string ToString()
    {
        return $"{Rubles},{Kopecks:D2}";
    }

    // Методы для операций над деньгами (сложение, вычитание, деление, умножение и т.д.) могут быть добавлены здесь
}
