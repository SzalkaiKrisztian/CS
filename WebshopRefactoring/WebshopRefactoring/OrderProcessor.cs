namespace WebshopRefactoring;

public class OrderProcessor
{
    private readonly EmailNotifier notifier;
    private readonly IPaymentMethod payment;
    private readonly InvoicePrinter invoicePrinter = new InvoicePrinter();
    private readonly ShippingLabelPrinter labelPrinter = new ShippingLabelPrinter();

    public OrderProcessor(EmailNotifier notifier, IPaymentMethod payment)
    {
        this.notifier = notifier;
        this.payment = payment;
    }

    public void Process(Order order)
    {
        Console.WriteLine("Payment method: " + payment.Name);

        // 9. feladat (Inline Variable)
        // A totalToPay változót csak egyszer használjuk fel, a következő sorban, ezért nem kell
        // külön változóba tenni. Állj a változó nevére a deklarációnál, Ctrl+., majd
        // Inline temporary variable. Próbáld ki a success változóval is.
        decimal totalToPay = order.Calc();
        bool success = payment.Pay(totalToPay);
        if (!success)
        {
            Console.WriteLine("Payment failed, the order was not processed.");
            return;
        }

        invoicePrinter.Print(order);
        labelPrinter.Print(order.GetCustomerName(), order.Customer.Street, order.Customer.City, order.Customer.ZipCode, order.Customer.Country);
        notifier.SendOrderConfirmation(order);
        notifier.SendShippingNotice(order);
    }
}
