namespace WebshopRefactoring;

public class Order
{
    // 6. feladat (Move Field + Move Method, statikus tagok)
    // Az áfakulcs és az áfa kiszámítása nem a rendelés dolga, egy árkalkulátor osztályba tartozik.
    // Költöztesd át a VatRate konstanst és a CalculateVat metódust a PriceCalculator osztályba
    // (PriceCalculator.cs, jelenleg üres): állj a CalculateVat nevére, Ctrl+., majd
    // Move static members to another type. A dialógusban jelöld ki mindkét tagot.
    // Ez a Visual Studio beépített refaktorálása. Utána nézd meg, hogy az InvoicePrinter.cs
    // hivatkozásai is átíródtak-e.
    public const decimal VatRate = 0.27m;

    public Customer Customer { get; }

    private readonly List<OrderLine> lines = new List<OrderLine>();
    public IReadOnlyList<OrderLine> Lines => lines;

    public Order(Customer customer)
    {
        Customer = customer;
    }

    // 1. feladat (Rename), második rész
    // A p és q paraméternevek semmit sem mondanak. Nevezd át őket product és quantity nevekre
    // (állj a névre, F2 vagy Ctrl+R, Ctrl+R).
    public void AddLine(Product product, int quantity)
    {
        lines.Add(new OrderLine(product, quantity));
    }

    // 8. feladat (Inline Method)
    // Ez a metódus semmi mást nem csinál, csak továbbadja a vevő nevét, tehát felesleges közvetítő.
    // Állj a metódus egyik hívására (például az InvoicePrinter.cs fájlban), nyomj Ctrl+.-ot,
    // és válaszd az Inline lehetőséget. Ha kétféle változatot látsz (a metódus megtartása vagy
    // törlése), próbáld ki mindkettőt.
    // A végén a hívások helyén az order.Customer.Name kifejezésnek kell szerepelnie.
    public string GetCustomerName()
    {
        return Customer.Name;
    }

    // 1. feladat (Rename), első rész
    // A Calc név nem árulja el, mit számol a metódus (a rendelés végösszegét, kedvezménnyel és áfával).
    // Nevezd át CalculateTotal-ra: állj a névre, majd F2 (vagy Ctrl+R, Ctrl+R).
    // Figyeld meg, hogy a hívások az InvoicePrinter.cs és az OrderProcessor.cs fájlban is átíródnak.
    public decimal Calc()
    {
        decimal net = 0;
        foreach (var line in lines)
        {
            net += line.Product.Price * line.Quantity;
        }

        decimal discount = net * GetDiscountPercent() / 100;
        decimal afterDiscount = net - discount;
        return afterDiscount + CalculateVat(afterDiscount);
    }

    // 7. feladat (Move Method, példánymetódus)
    // Ez a metódus csak a vevő adatait használja (IsVip, LoyaltyPoints), a rendelésről semmit sem tud,
    // ezért a Customer osztályba tartozik. Költöztesd át a Customer.cs fájlba:
    //  - vágd ki a metódust, és illeszd be a Customer osztályba,
    //  - a törzsében töröld a "Customer." előtagot (a Customer osztályon belül a tagok közvetlenül elérhetők),
    //  - javítsd a hívásokat (Order.cs, InvoicePrinter.cs), hogy a vevő metódusát hívják.
    // A fordító hibaüzenetei végigvezetnek a javítandó helyeken.
    // Megjegyzés: a Visual Studióban a példánymetódusok áthelyezésére nincs beépített refaktorálás,
    // ezért kell kézzel dolgozni. A JetBrains Rider és a ReSharper ezt automatikusan elvégzi
    // (Move Instance Method). Diákként ingyenes hozzáférést kaphatsz hozzájuk, érdemes kipróbálni!
    public decimal GetDiscountPercent()
    {
        if (Customer.IsVip)
        {
            return 10;
        }

        if (Customer.LoyaltyPoints >= 100)
        {
            return 5;
        }

        return 0;
    }

    // (6. feladat, lásd a VatRate konstansnál)
    public static decimal CalculateVat(decimal amount)
    {
        return amount * VatRate;
    }
}
