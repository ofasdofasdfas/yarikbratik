using System;
using System.Globalization;
using System.Security.Policy;
using System.Security.Principal;
using System.Windows;

namespace BankAccountApp
{
    public partial class MainWindow : Window
    {
        private Account account;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Считываем данные с интерфейса
                string ownerLastName = txtOwner.Text.Trim();
                string accountNumber = txtAccountNumber.Text.Trim();
                double interestRate = double.Parse(txtInterestRate.Text.Trim(), CultureInfo.InvariantCulture);
                long rubles = long.Parse(txtRubles.Text.Trim());
                byte kopecks = byte.Parse(txtKopecks.Text.Trim());

                // Создаем объект Money для текущего баланса
                Money initialBalance = new Money(rubles, kopecks);

                // Создаем новый банковский счет
                account = new Account(ownerLastName, accountNumber, interestRate, initialBalance);

                // Выводим информацию о созданном счете
                DisplayMessage($"Открыт новый счет для {account.OwnerLastName}. Номер счета: {account.AccountNumber}. Текущий баланс: {account.Balance}");
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnChangeOwner_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (account == null)
                    throw new InvalidOperationException("Сначала создайте счет.");

                // Считываем нового владельца с интерфейса
                string newOwnerLastName = txtOwner.Text.Trim();

                // Меняем владельца счета
                account.ChangeOwner(newOwnerLastName);

                DisplayMessage($"Владелец счета изменен на {account.OwnerLastName}");
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (account == null)
                    throw new InvalidOperationException("Сначала создайте счет.");

                // Считываем сумму для снятия с интерфейса
                long rubles = long.Parse(txtRubles.Text.Trim());
                byte kopecks = byte.Parse(txtKopecks.Text.Trim());
                Money amount = new Money(rubles, kopecks);

                // Снимаем деньги со счета
                account.Withdraw(amount);

                DisplayMessage($"Со счета снято: {amount}. Текущий баланс: {account.Balance}");
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (account == null)
                    throw new InvalidOperationException("Сначала создайте счет.");

                // Считываем сумму для зачисления с интерфейса
                long rubles = long.Parse(txtRubles.Text.Trim());
                byte kopecks = byte.Parse(txtKopecks.Text.Trim());
                Money amount = new Money(rubles, kopecks);

                // Зачисляем деньги на счет
                account.Deposit(amount);

                DisplayMessage($"На счет зачислено: {amount}. Текущий баланс: {account.Balance}");
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnAccrueInterest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (account == null)
                    throw new InvalidOperationException("Сначала создайте счет.");

                // Начисляем проценты на счет
                account.AccrueInterest();

                DisplayMessage($"Проценты начислены. Текущий баланс: {account.Balance}");
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnConvertToDollars_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (account == null)
                    throw new InvalidOperationException("Сначала создайте счет.");

                // Конвертируем баланс в доллары
                double exchangeRate = 75.0; // Примерный курс
                Money amountInDollars = account.ConvertToDollars(exchangeRate);

                DisplayMessage($"Текущий баланс в долларах: {amountInDollars}");
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnConvertToEuro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (account == null)
                    throw new InvalidOperationException("Сначала создайте счет.");

                // Конвертируем баланс в евро
                double exchangeRate = 85.0; // Примерный курс
                Money amountInEuro = account.ConvertToEuro(exchangeRate);

                DisplayMessage($"Текущий баланс в евро: {amountInEuro}");
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnAmountInWords_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (account == null)
                    throw new InvalidOperationException("Сначала создайте счет.");

                // Получаем текущий баланс прописью
                string amountInWords = account.GetAmountInWords();

                DisplayMessage($"Текущий баланс прописью: {amountInWords}");
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void DisplayMessage(string message)
        {
            txtResult.Text += $"{message}\n";
        }

        private void DisplayError(string error)
        {
            txtResult.Text += $"Ошибка: {error}\n";
        }
    }
}
