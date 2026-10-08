# Refaktorálás gyakorlóprojekt (webshop)

Ez a projekt a *Refaktorálás és IDE-eszközök* fejezethez tartozik. Egy egyszerű webshop rendeléskezelőjét modellezi (termék, vevő, rendelés, fizetés, számla, szállítócímke, értesítés). A kód működik, de szándékosan hagyunk benne olyan hibákat és kellemetlenségeket, amelyeket az IDE refaktoráló eszközeivel lehet kijavítani. A cél, hogy a fejezetben felsorolt összes műveletet kipróbáld.

## Előkészületek

- Visual Studio 2022 és .NET 8.
- Nyisd meg a `WebshopRefactoring.sln` fájlt, majd futtasd a programot (**Ctrl+F5**).
- A kódban az azonosítók angolul vannak, a feladatokat magyar megjegyzések írják le, "N. feladat" felirattal.

## A munka szabályai

- A refaktorálás **nem változtathatja meg a program működését**. Minden feladat után futtasd újra a programot, és ellenőrizd, hogy a kimenet ugyanaz maradt (lásd lentebb).
- Minden feladat előtt érdemes commitolni (`git`), így a változásokat utólag is megnézheted, és bármikor visszaléphetsz. Visszavonni a **Ctrl+Z**-vel is lehet.
- A legtöbb refaktorálás előtt az IDE mutat egy előnézetet (*Preview changes*). Érdemes átnézni, mit fog átírni.
- A feladatokat tetszőleges sorrendben megoldhatod, de a megadott sorrend jó kiindulás.

## Hasznos billentyűk

| Művelet | Billentyű |
|---|---|
| Gyorsműveletek és refaktorálások menü | Ctrl+. |
| Rename | F2 vagy Ctrl+R, Ctrl+R |
| Extract Method | Ctrl+R, Ctrl+M |
| Encapsulate Field | Ctrl+R, Ctrl+E |
| Extract Interface | Ctrl+R, Ctrl+I |
| Futtatás (hibakereső nélkül) | Ctrl+F5 |

## A feladatok

| # | Művelet | Hol találod | Visual Studióban |
|---|---|---|---|
| 1 | Rename | `Order.cs` | beépített |
| 2 | Extract Method | `InvoicePrinter.cs` | beépített |
| 3 | Encapsulate Field | `Product.cs` | beépített |
| 4 | Implement Interface | `IPaymentMethod.cs` | beépített |
| 5 | Extract Interface | `EmailNotifier.cs` | beépített |
| 6 | Move Field + Move Method (statikus tagok) | `Order.cs` | beépített (Move static members to another type) |
| 7 | Move Method (példánymetódus) | `Order.cs` | kézi munka |
| 8 | Inline Method | `Order.cs` | beépített |
| 9 | Inline Variable | `OrderProcessor.cs` | beépített |
| 10 | Introduce Parameter Object | `ShippingLabelPrinter.cs` | kézi munka |

## Rider és ReSharper

A 7. és a 10. feladatot a Visual Studióban kézzel kell megoldani, mert nincs hozzájuk beépített refaktorálás. A JetBrains **Rider** és **ReSharper** eszközei ezeket automatikusan elvégzik (*Move Instance Method*, illetve *Transform Parameters*). Diákként ingyenes hozzáférést kaphatsz hozzájuk, érdemes kipróbálni: oldd meg ezt a két feladatot egyszer kézzel, egyszer az eszközzel, és hasonlítsd össze az eredményt!

## Elvárt kimenet

A program kimenete a feladatok megoldása előtt és után is ez:

```
Payment method: Credit card
Charging 388493 HUF to card ending 4321
=== INVOICE ===
Customer: Anna Kiss
Email: anna.kiss@example.com
--------------------------------
Laptop x 1 = 300000 HUF
Mouse x 2 = 16000 HUF
Notebook x 3 = 6000 HUF
--------------------------------
Net total: 322000 HUF
Discount (5%): -16100 HUF
VAT (27%): 82593 HUF
TOTAL: 388493 HUF
--- SHIPPING LABEL ---
Anna Kiss
Fo utca 12.
6720 Szeged
HUNGARY
Email sent to anna.kiss@example.com: order confirmed.
Email sent to anna.kiss@example.com: your parcel is on the way.
```

A 4. feladatban az új fizetési mód kipróbálásakor a fizetésre vonatkozó két sor természetesen más lesz.

## A projekt felépítése

| Fájl | Szerepe |
|---|---|
| `Program.cs` | belépési pont, a rendelés összeállítása |
| `Product.cs`, `Customer.cs`, `OrderLine.cs`, `Order.cs` | a rendelés adatai és számításai |
| `OrderProcessor.cs` | a rendelés feldolgozása (fizetés, számla, címke, értesítés) |
| `IPaymentMethod.cs`, `CardPayment.cs` | fizetési mód interfész és egy megvalósítás |
| `InvoicePrinter.cs`, `ShippingLabelPrinter.cs` | számla és szállítócímke kiírása |
| `EmailNotifier.cs` | e-mail értesítés |
| `PriceCalculator.cs` | egyelőre üres, a 6. feladatban töltöd fel |

## Ha végeztél

- Írj hozzá egy második rendelést egy VIP vevővel (10% kedvezmény), és nézd meg, hogy a 7. feladat után is jól számol-e.
- Gondold végig, honnan tudnád automatikusan ellenőrizni, hogy a refaktorálás nem rontott el semmit. (Segítség: kiegészítő témák, egységtesztelés.)
