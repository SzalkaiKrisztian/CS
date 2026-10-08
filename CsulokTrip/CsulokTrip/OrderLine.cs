namespace CsulokTrip;

/// <summary>
/// One line of an order, e.g. "Csulok" x 3 at 4 500 HUF each.
/// </summary>
public record OrderLine(string Name, decimal UnitPrice, int Quantity);
