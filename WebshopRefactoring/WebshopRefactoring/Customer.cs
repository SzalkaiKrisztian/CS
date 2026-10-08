namespace WebshopRefactoring;

// Egy vevő adatai: elérhetőség, szállítási cím és hűségadatok.
public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }

    public string Street { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }

    public bool IsVip { get; set; }
    public int LoyaltyPoints { get; set; }
}
