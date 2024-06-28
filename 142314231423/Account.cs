public class Account
{
    public string OwnerLastName { get; private set; }
    public string AccountNumber { get; private set; }
    public double InterestRate { get; private set; }
    public Money Balance { get; private set; }

    public Account(string ownerLastName, string accountNumber, double interestRate, Money initialBalance)
    {
        OwnerLastName = ownerLastName;
        AccountNumber = accountNumber;
        InterestRate = interestRate;
        Balance = initialBalance;
    }

    public void ChangeOwner(string newOwnerLastName)
    {
        OwnerLastName = newOwnerLastName;
    }

    public void Withdraw(Money amount)
    {
        // Реализация снятия денег со счета
        // Пример:
        Balance = new Money(Balance.Rubles - amount.Rubles, (byte)(Balance.Kopecks - amount.Kopecks));
    }

    public void Deposit(Money amount)
    {
        // Реализация зачисления денег на счет
        // Пример:
        Balance = new Money(Balance.Rubles + amount.Rubles, (byte)(Balance.Kopecks + amount.Kopecks));
    }

    public void AccrueInterest()
    {
        // Реализация начисления процентов на счет
        // Пример:
        double interestAmount = Balance.Rubles * (InterestRate / 100.0);
        long rublesInterest = (long)Math.Floor(interestAmount);
        byte kopecksInterest = (byte)((interestAmount - rublesInterest) * 100);
        Balance = new Money(Balance.Rubles + rublesInterest, (byte)(Balance.Kopecks + kopecksInterest));
    }

    public Money ConvertToDollars(double exchangeRate)
    {
        // Реализация конвертации баланса в доллары
        // Пример:
        double dollars = Balance.Rubles / exchangeRate;
        double kopecksInDollars = (Balance.Kopecks / exchangeRate) * 100;
        return new Money((long)dollars, (byte)kopecksInDollars);
    }

    public Money ConvertToEuro(double exchangeRate)
    {
        // Реализация конвертации баланса в евро
        // Пример:
        double euros = Balance.Rubles / exchangeRate;
        double kopecksInEuros = (Balance.Kopecks / exchangeRate) * 100;
        return new Money((long)euros, (byte)kopecksInEuros);
    }

    public string GetAmountInWords()
    {
        // Реализация получения текущего баланса прописью
        // Пример:
        return NumToWords(Balance.Rubles) + " рублей " + NumToWords(Balance.Kopecks) + " копеек";
    }

    private string NumToWords(long number)
    {
        // Метод для преобразования числа в слова
        // Этот код можно использовать для преобразования числа в слова
        string words = "";

        return words.Trim();
    }
}
