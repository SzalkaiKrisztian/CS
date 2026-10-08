namespace WebshopRefactoring;

// 5. feladat (Extract Interface)
// Az OrderProcessor közvetlenül ettől az osztálytól függ, ezért nem lehet egyszerűen lecserélni
// például SMS-értesítésre. Válassz le egy interfészt az osztály publikus metódusaiból:
//  - állj az osztály nevére, majd Ctrl+R, Ctrl+I (vagy Ctrl+. és Extract interface),
//  - a dialógusban jelöld ki mindkét metódust, a név legyen INotifier,
//  - az OrderProcessor.cs fájlban cseréld le az EmailNotifier típust INotifier-re
//    (a mezőben és a konstruktor paraméterében is).
// Extra: készíts egy SmsNotifier osztályt, amely szintén megvalósítja az INotifier interfészt
// (Implement interface), és próbáld ki a Program.cs fájlban.
public class EmailNotifier
{
    public void SendOrderConfirmation(Order order)
    {
        Console.WriteLine("Email sent to " + order.Customer.Email + ": order confirmed.");
    }

    public void SendShippingNotice(Order order)
    {
        Console.WriteLine("Email sent to " + order.Customer.Email + ": your parcel is on the way.");
    }
}
