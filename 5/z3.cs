using System;

abstract class BankAccount
{
    public string AccountNumber { get; set; }
    public double Balance { get; set; }

    public BankAccount(string number, double balance)
    {
        AccountNumber = number;
        Balance = balance;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Счет {AccountNumber}, баланс: {Balance} руб.");
    }
}

interface IDebitAccount
{
    void Withdraw(double amount);
    void Deposit(double amount);
}

interface ICreditAccount
{
    double CreditLimit { get; }
    bool TakeCredit(double amount);
    void RepayCredit(double amount);
}

class SavingsAccount : BankAccount, IDebitAccount
{
    public SavingsAccount(string number, double balance) : base(number, balance) { }

    public void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Снято {amount} руб. Остаток: {Balance}");
        }
        else
        {
            Console.WriteLine("Недостаточно средств.");
        }
    }

    public void Deposit(double amount)
    {
        Balance += amount;
        Console.WriteLine($"Внесено {amount} руб. Новый баланс: {Balance}");
    }

    public override void DisplayInfo()
    {
        Console.Write("[Дебетовый] ");
        base.DisplayInfo();
    }
}

class LoanAccount : BankAccount, ICreditAccount
{
    private double creditDebt;

    public double CreditLimit { get; private set; }

    public LoanAccount(string number, double limit) : base(number, 0)
    {
        CreditLimit = limit;
        creditDebt = 0;
    }

    public bool TakeCredit(double amount)
    {
        if (creditDebt + amount <= CreditLimit)
        {
            creditDebt += amount;
            Balance += amount;
            Console.WriteLine($"Взят кредит {amount} руб. Текущий долг: {creditDebt}");
            return true;
        }
        else
        {
            Console.WriteLine("Превышен кредитный лимит.");
            return false;
        }
    }

    public void RepayCredit(double amount)
    {
        if (amount > creditDebt)
            amount = creditDebt;
        creditDebt -= amount;
        Balance -= amount;
        Console.WriteLine($"Погашено {amount} руб. Остаток долга: {creditDebt}");
    }

    public override void DisplayInfo()
    {
        Console.Write("[Кредитный] ");
        base.DisplayInfo();
        Console.WriteLine($"Кредитный лимит: {CreditLimit}, текущий долг: {creditDebt}");
    }
}

class Program
{
    static void Main()
    {
        BankAccount[] accounts = new BankAccount[]
        {
            new SavingsAccount("SAV-001", 5000),
            new LoanAccount("LOAN-001", 10000),
            new SavingsAccount("SAV-002", 3000),
            new LoanAccount("LOAN-002", 20000)
        };

        Console.WriteLine("Все счета:");
        foreach (BankAccount acc in accounts)
        {
            acc.DisplayInfo();
            Console.WriteLine();
        }

        Console.WriteLine("Кредитные счета:");
        foreach (BankAccount acc in accounts)
        {
            if (acc is ICreditAccount credit)
            {
                Console.WriteLine($"Счет {acc.AccountNumber} (кредитный лимит: {credit.CreditLimit})");
            }
        }
    }
}