namespace WebshopRefactoring;

public class InvoicePrinter
{
    // 2. feladat (Extract Method)
    // Ez a metódus túl hosszú, három dolgot csinál: kiírja a fejlécet, kiírja a tételeket,
    // majd kiszámolja és kiírja az összesítést. Emelj ki legalább két részt önálló metódusba:
    //  - jelöld ki a fejléc első négy sorát, majd Ctrl+R, Ctrl+M (vagy Ctrl+. és Extract method),
    //    a metódus neve legyen PrintHeader;
    //  - jelöld ki a "decimal net = 0;" sortól a ciklus végéig tartó részt (PrintLines néven),
    //    és figyeld meg, hogy az IDE visszatérési értéket készít a net változóhoz;
    //  - az összesítést (a discountPercent soron kezdve) is kiemelheted PrintTotals néven.
    // Futtasd újra a programot: a számla ugyanúgy nézzen ki, mint korábban.
    public void Print(Order order)
    {
        PrintHeader(order);
        decimal net = PrintLines(order);

        decimal discountPercent = order.GetDiscountPercent();
        decimal discount = net * discountPercent / 100;
        decimal afterDiscount = net - discount;
        decimal vat = Order.CalculateVat(afterDiscount);

        Console.WriteLine("Net total: " + net.ToString("0") + " HUF");
        Console.WriteLine("Discount (" + discountPercent.ToString("0") + "%): -" + discount.ToString("0") + " HUF");
        Console.WriteLine("VAT (" + (Order.VatRate * 100).ToString("0") + "%): " + vat.ToString("0") + " HUF");
        Console.WriteLine("TOTAL: " + order.Calc().ToString("0") + " HUF");
    }

    private static decimal PrintLines(Order order)
    {
        decimal net = 0;
        foreach (var line in order.Lines)
        {
            decimal lineTotal = line.Product.Price * line.Quantity;
            net += lineTotal;
            Console.WriteLine(line.Product.Name + " x " + line.Quantity + " = " + lineTotal.ToString("0") + " HUF");
        }

        Console.WriteLine("--------------------------------");
        return net;
    }

    private static void PrintHeader(Order order)
    {
        Console.WriteLine("=== INVOICE ===");
        Console.WriteLine("Customer: " + order.GetCustomerName());
        Console.WriteLine("Email: " + order.Customer.Email);
        Console.WriteLine("--------------------------------");
    }
}
