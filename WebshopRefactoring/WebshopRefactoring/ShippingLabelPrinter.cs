namespace WebshopRefactoring;

public class ShippingLabelPrinter
{
    // 10. feladat (Introduce Parameter Object)
    // Ennek a metódusnak öt paramétere van, és a négy címadat (street, city, zipCode, country)
    // mindig együtt jár. Az ilyen összetartozó adatokat érdemes egy külön objektumba szervezni:
    //  - hozz létre egy Address osztályt négy tulajdonsággal (Street, City, ZipCode, Country),
    //  - cseréld le a metódus négy címparaméterét egyetlen Address típusú paraméterre,
    //  - javítsd a hívást az OrderProcessor.cs fájlban: ott készítsd el az Address objektumot
    //    a vevő adataiból.
    // Extra: a Customer osztály is tárolhatná a címet egyetlen Address tulajdonságban.
    // Megjegyzés: a Visual Studióban erre nincs beépített refaktorálás, ezért kell kézzel dolgozni.
    // A JetBrains Rider és a ReSharper ezt automatikusan elvégzi (Transform Parameters).
    // Diákként ingyenes hozzáférést kaphatsz hozzájuk, érdemes kipróbálni!
    public void Print(string recipientName, string street, string city, string zipCode, string country)
    {
        Console.WriteLine("--- SHIPPING LABEL ---");
        Console.WriteLine(recipientName);
        Console.WriteLine(street);
        Console.WriteLine(zipCode + " " + city);
        Console.WriteLine(country.ToUpperInvariant());
    }
}
