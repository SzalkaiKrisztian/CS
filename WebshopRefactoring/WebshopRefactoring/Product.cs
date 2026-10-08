namespace WebshopRefactoring;

public class Product
{
    // 3. feladat (Encapsulate Field)
    // Ezek a mezők publikusak, így bárki bármilyen ellenőrzés nélkül átírhatja őket
    // (például az ár lehetne negatív). Alakítsd őket tulajdonsággá (property):
    // állj a mező nevére, majd Ctrl+R, Ctrl+E (vagy Ctrl+. és Encapsulate field).
    // Figyeld meg, hogy a többi fájlban a product.name és a product.price hivatkozások
    // is átíródnak az új tulajdonságokra.
    // Extra: az ár tulajdonság set ágában dobj kivételt, ha az érték negatív
    // (lásd az egységbe zárásról szóló fejezetet).
    private string name;
    private decimal price;
    private string category;

    public string Name { get => name; set => name = value; }
    public decimal Price { get => price; set 
        {
           if(price >= 0)
            {
                price=value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
    public string Category { get => category; set => category = value; }

    public Product(string name, decimal price, string category)
    {
        this.Name = name;
        this.Price = price;
        this.Category = category;
    }
}
