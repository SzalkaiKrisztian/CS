namespace WebshopRefactoring;

// Üdv a refaktorálós gyakorlóprojektben!
//
// Ez a program egy egyszerű webshop rendeléskezelőjét modellezi: van termék, vevő, rendelés,
// fizetési mód, számla, szállítócímke és e-mail értesítés.
// A kód működik, de szándékosan nem tökéletes: a feladatok azt kérik, hogy javítsd ki
// az IDE refaktoráló eszközeivel.
//
// A feladatok "N. feladat" feliratú megjegyzésekként vannak a kódban, ott, ahol dolgozni kell:
//
//    1. feladat   Rename                         Order.cs
//    2. feladat   Extract Method                 InvoicePrinter.cs
//    3. feladat   Encapsulate Field              Product.cs
//    4. feladat   Implement Interface            IPaymentMethod.cs
//    5. feladat   Extract Interface              EmailNotifier.cs
//    6. feladat   Move Field + Move Method       Order.cs (statikus tagok)
//    7. feladat   Move Method                    Order.cs (példánymetódus)
//    8. feladat   Inline Method                  Order.cs
//    9. feladat   Inline Variable                OrderProcessor.cs
//   10. feladat   Introduce Parameter Object     ShippingLabelPrinter.cs
//
// A refaktorálás alapszabálya: a program működése nem változhat.
// Minden feladat után futtasd újra a programot (Ctrl+F5), és ellenőrizd, hogy a kimenet
// ugyanaz maradt. Az elvárt kimenetet a README.md tartalmazza.
public class Program
{
    public static void Main()
    {
        var laptop = new Product("Laptop", 300000, "Electronics");
        var mouse = new Product("Mouse", 8000, "Electronics");
        var notebook = new Product("Notebook", 2000, "Office");

        var customer = new Customer
        {
            Name = "Anna Kiss",
            Email = "anna.kiss@example.com",
            Street = "Fo utca 12.",
            City = "Szeged",
            ZipCode = "6720",
            Country = "Hungary",
            IsVip = false,
            LoyaltyPoints = 120
        };

        var order = new Order(customer);
        order.AddLine(laptop, 1);
        order.AddLine(mouse, 2);
        order.AddLine(notebook, 3);

        // A 4. feladat után itt kipróbálhatod az új fizetési módot is a CardPayment helyett.
        var processor = new OrderProcessor(new EmailNotifier(), new CardPayment("1234-5678-9012-4321"));
        processor.Process(order);
    }
}
