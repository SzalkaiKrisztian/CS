namespace CsulokTrip;

/// <summary>
/// A table reservation for the class at the restaurant.
/// </summary>
public class TableBooking
{
    public int Capacity { get; }
    public int Reserved { get; private set; }
    public int Available => Capacity - Reserved;

    /// <summary>
    /// Throws ArgumentOutOfRangeException if capacity is less than 1.
    /// </summary>
    public TableBooking(int capacity)
    {
        if (capacity < 1)
            throw new ArgumentOutOfRangeException(nameof(capacity));

        Capacity = capacity;
    }

    /// <summary>
    /// Reserves the given number of seats and returns true.
    /// Returns false and changes nothing if seats is less than 1 or
    /// more than the number of available seats.
    /// Reserving exactly all remaining seats is allowed.
    /// </summary>
    public bool Reserve(int seats)
    {
        if (seats < 1 || seats > Available)
            return false;

        Reserved += seats;
        return true;
    }

    /// <summary>
    /// Cancels the given number of seats and returns true.
    /// Returns false and changes nothing if seats is less than 1 or
    /// more than the number of currently reserved seats.
    /// </summary>
    public bool Cancel(int seats)
    {
        if (seats < 1 || seats > Reserved)
            return false;

        Reserved -= seats;
        return true;
    }

    /// <summary>
    /// One portion of csulok is shared by two people.
    /// Returns how many portions are needed for the reserved seats;
    /// an odd number of people still needs a whole extra portion (5 people = 3 portions).
    /// </summary>
    public int PortionsNeeded()
    {
        return (Reserved + 1) / 2;
    }
}
