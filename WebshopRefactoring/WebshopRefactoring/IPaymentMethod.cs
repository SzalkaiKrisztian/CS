namespace WebshopRefactoring;

// 4. feladat (Implement Interface)
// Jelenleg egyetlen fizetési mód van (CardPayment.cs). Készíts egy újat:
//  - hozz létre egy új osztályt BankTransferPayment néven egy új fájlban
//    (jobb klikk a projekten, Add, Class),
//  - írd az osztály neve mögé, hogy ": IPaymentMethod",
//  - az osztály neve alatt piros hullámvonal jelenik meg, mert még nem valósítja meg az interfészt:
//    állj a névre, Ctrl+., majd Implement interface, és az IDE legenerálja a hiányzó tagokat,
//  - töltsd ki a generált törzseket (például a Pay írjon ki egy üzenetet, és adjon vissza true-t),
//  - végül próbáld ki a Program.cs fájlban a CardPayment helyett.
public interface IPaymentMethod
{
    string Name { get; }

    bool Pay(decimal amount);
}
