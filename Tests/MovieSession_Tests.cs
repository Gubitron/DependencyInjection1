namespace Tests;

public class MovieSession_Tests
{
    [Theory, AutoData]
    public void SessionFullyBooked_WhenNoMoreTickets_ReturnsNull(string movieName, 
                                                                 int auditoriumNumber, 
                                                                 DateTime startsAt, 
                                                                 Ticket ticket)
    {
        // Arrange
        List<Ticket> tickets = new List<Ticket> { ticket };
        MovieSession sut = new MovieSession(tickets,
                                            movieName,
                                            auditoriumNumber,
                                            startsAt);

        // Act
        var bookedTicket = sut.BookTicket().First();
        var remainingTickets = sut.CheckRemainingTicketCount();
        var overbooking = () => sut.BookTicket();
        var fullyBooked = sut.SessionFullyBooked();

        // Assert
        bookedTicket.Should().BeOfType<Ticket>();
        remainingTickets.Should().Be(0);
        overbooking.Should().Throw<Exception>();
        fullyBooked.Should().BeTrue();
    }
}
