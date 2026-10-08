namespace CsulokTrip.test
{
    public class UnitTest1
    {
        [Fact]
        public void CalculateSubtotal_NullOrEmpty_ReturnsZero()
        {
            Assert.Equal(0m, OrderCalculator.CalculateSubtotal(null));
            Assert.Equal(0m, OrderCalculator.CalculateSubtotal(Array.Empty<OrderLine>()));
        }

        [Fact]
        public void CalculateSubtotal_SumsAllLines()
        {
            var lines = new[]
            {
            new OrderLine("Csülök", 4500m, 2),
            new OrderLine("Köret", 1200m, 3),
            new OrderLine("Üdítõ", 700m, 1)
        };
            Assert.Equal(13300m, OrderCalculator.CalculateSubtotal(lines));
        }

        [Fact]
        public void GetGroupDiscountPercent_ReturnsCorrectBoundaries()
        {
            Assert.Equal(0m, OrderCalculator.GetGroupDiscountPercent(1));
            Assert.Equal(0m, OrderCalculator.GetGroupDiscountPercent(9));
            Assert.Equal(5m, OrderCalculator.GetGroupDiscountPercent(10));
            Assert.Equal(5m, OrderCalculator.GetGroupDiscountPercent(19));
            Assert.Equal(10m, OrderCalculator.GetGroupDiscountPercent(20));
        }

        [Fact]
        public void GetGroupDiscountPercent_LessThanOne_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => OrderCalculator.GetGroupDiscountPercent(0));
        }

        [Fact]
        public void ApplyDiscount_RoundsHalfAwayFromZero()
        {
            Assert.Equal(905m, OrderCalculator.ApplyDiscount(1005m, 10m));
        }

        [Fact]
        public void AverageSpendPerPerson_ReturnsZeroForZeroOrNegativePeople()
        {
            Assert.Equal(0m, OrderCalculator.AverageSpendPerPerson(1000m, 0));
            Assert.Equal(0m, OrderCalculator.AverageSpendPerPerson(1000m, -1));
        }

        [Fact]
        public void AverageSpendPerPerson_RoundsHalfAwayFromZero()
        {
            Assert.Equal(503m, OrderCalculator.AverageSpendPerPerson(1005m, 2));
        }

        [Fact]
        public void Constructor_LessThanOne_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TableBooking(0));
        }

        [Fact]
        public void Constructor_SetsCapacityAndAvailableSeats()
        {
            var booking = new TableBooking(20);
            Assert.Equal(20, booking.Capacity);
            Assert.Equal(0, booking.Reserved);
            Assert.Equal(20, booking.Available);
        }

        [Fact]
        public void Reserve_ValidSeats_ChangesReservation()
        {
            var booking = new TableBooking(20);
            Assert.True(booking.Reserve(5));
            Assert.Equal(5, booking.Reserved);
            Assert.Equal(15, booking.Available);
        }

        [Fact]
        public void Reserve_ExactlyAllAvailableSeats_IsAllowed()
        {
            var booking = new TableBooking(10);
            Assert.True(booking.Reserve(10));
            Assert.Equal(10, booking.Reserved);
            Assert.Equal(0, booking.Available);
        }

        [Fact]
        public void Reserve_InvalidSeats_ReturnsFalseAndDoesNotChangeState()
        {
            var booking = new TableBooking(10);
            Assert.False(booking.Reserve(0));
            Assert.False(booking.Reserve(-1));
            Assert.False(booking.Reserve(11));
            Assert.Equal(0, booking.Reserved);
        }

        [Fact]
        public void Cancel_ValidSeats_ChangesReservation()
        {
            var booking = new TableBooking(10);
            booking.Reserve(7);
            Assert.True(booking.Cancel(3));
            Assert.Equal(4, booking.Reserved);
            Assert.Equal(6, booking.Available);
        }

        [Fact]
        public void Cancel_TooManyOrInvalidSeats_ReturnsFalseAndDoesNotChangeState()
        {
            var booking = new TableBooking(10);
            booking.Reserve(5);
            Assert.False(booking.Cancel(0));
            Assert.False(booking.Cancel(-1));
            Assert.False(booking.Cancel(6));
            Assert.Equal(5, booking.Reserved);
        }

        [Fact]
        public void PortionsNeeded_UsesWholeExtraPortionForOddNumber()
        {
            var booking = new TableBooking(10);
            booking.Reserve(5);
            Assert.Equal(3, booking.PortionsNeeded());
        }
    }
}