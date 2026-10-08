namespace CsulokTrip;

/// <summary>
/// Price calculations for the restaurant visit of the school trip.
/// All amounts are in Hungarian forints (HUF).
/// </summary>
public static class OrderCalculator
{
    /// <summary>
    /// Returns the sum of UnitPrice * Quantity over ALL lines.
    /// A null or empty list gives 0.
    /// </summary>
    public static decimal CalculateSubtotal(IReadOnlyList<OrderLine>? lines)
    {
        if (lines == null || lines.Count == 0)
            return 0;

        decimal total = 0;

        for (int i = 0; i < lines.Count; i++)
        {
            total += lines[i].UnitPrice * lines[i].Quantity;
        }

        return total;
    }

    /// <summary>
    /// Returns the group discount in percent:
    /// 1-9 people: 0, 10-19 people: 5, 20 or more people: 10.
    /// Throws ArgumentOutOfRangeException if groupSize is less than 1.
    /// </summary>
    public static decimal GetGroupDiscountPercent(int groupSize)
    {
        if (groupSize < 1)
            throw new ArgumentOutOfRangeException(nameof(groupSize));

        if (groupSize >= 20)
            return 10;

        if (groupSize >= 10)
            return 5;

        return 0;
    }

    /// <summary>
    /// Reduces the amount by the given percent (10 means 10%) and rounds the
    /// result to a whole forint. Halves are rounded away from zero (904.5 becomes 905).
    /// </summary>
    public static decimal ApplyDiscount(decimal amount, decimal percent)
    {
        decimal discounted = amount * (100 - percent) / 100;
        return Math.Round(discounted, MidpointRounding.AwayFromZero);
    }

    /// <summary>
    /// Returns what one person pays on average: total divided by people,
    /// rounded to a whole forint (halves away from zero).
    /// Returns 0 if people is 0 or less.
    /// </summary>
    public static decimal AverageSpendPerPerson(decimal total, int people)
    {
        if (people <= 0)
            return 0;

        return Math.Round(total / people, MidpointRounding.AwayFromZero);
    }
}
