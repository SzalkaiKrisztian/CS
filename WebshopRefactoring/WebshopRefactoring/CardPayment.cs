namespace WebshopRefactoring;

// Bankkártyás fizetés. Ez a mintaimplementáció, a 4. feladatban ehhez hasonlót kell készítened.
public class CardPayment : IPaymentMethod
{
    private readonly string cardNumber;

    public CardPayment(string cardNumber)
    {
        this.cardNumber = cardNumber;
    }

    public string Name => "Credit card";

    public bool Pay(decimal amount)
    {
        string lastFourDigits = cardNumber.Substring(cardNumber.Length - 4);
        Console.WriteLine("Charging " + amount.ToString("0") + " HUF to card ending " + lastFourDigits);
        return true;
    }
}
