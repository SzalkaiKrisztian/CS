namespace WebshopRefactoring;

// Egy rendelési tétel: melyik termékből hány darabot rendeltek.
public class OrderLine
{
    public Product Product { get; }
    public int Quantity { get; }

    public OrderLine(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }
}
