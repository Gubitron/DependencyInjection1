namespace Tests;

public class MovieSession_Tests
{
    [Theory]
    [AutoData]
    public void SessionFullyBooked_WhenNoMoreTickets_ReturnsNull(MovieSession session)
    {
        var sut = session;

        var ticketCount = sut.Tickets.Count;
        foreach (Ticket ticket in sut.Tickets)
        {
            var bookedTicket = sut.BookTicket();
            bookedTicket.Should().BeOfType<Ticket>();

            ticketCount--;
            var remainingTickets = sut.CheckRemainingTicketCount();
            remainingTickets.Should().Be(ticketCount);
        }

        var actual = sut.BookTicket();
        actual.Should().BeNull();

        var fullyBooked = sut.SessionFullyBooked();
        fullyBooked.Should().BeTrue();
    } 
}
