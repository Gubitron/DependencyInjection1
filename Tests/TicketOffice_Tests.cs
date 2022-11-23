namespace Tests;

public class TicketOffice_Tests
{
    [Theory, AutoData]
    public void BuyTickets_SunshineCase_ReturnsTicket(MovieSession movieSession)
    {
        // Arrange

        // Act
        var action = TicketOffice.BuyTickets(movieSession, 2);

        // Assert
        action.Should().HaveCount(2);
        action.Should().BeOfType<List<Ticket>>();
    }

    [Theory, AutoData]
    public void BuyTickets_FullyBooked_ThrowsException(string movieName, int auditoriumNumber, DateTime startsAt)
    {
        // Arrange
        var movieSession = new MovieSession(new List<Ticket>(), movieName, auditoriumNumber, startsAt);

        // Act
        var action = () => TicketOffice.BuyTickets(movieSession, 1);

        // Assert
        action.Should().Throw<Exception>();
    }

    [Theory, AutoData]
    public void BuyTickets_NotEnoughTickets_ThrowsException(string movieName, int auditoriumNumber, DateTime startsAt)
    {
        // Arrange
        List<Ticket> tickets = new List<Ticket> { new Ticket() };
        MovieSession movieSession = new MovieSession(tickets, movieName, auditoriumNumber, startsAt);

        // Act
        var action = () => TicketOffice.BuyTickets(movieSession, 2);

        // Assert
        action.Should().Throw<Exception>();
    }
}
