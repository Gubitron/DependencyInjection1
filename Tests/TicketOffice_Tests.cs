namespace Tests;

public class TicketOffice_Tests
{
    [Theory, AutoData]
    public void BuyTickets_SunshineCase_ReturnsTicket(MovieSessionRepository movieRepository, 
                                                      MovieSession movieSession)
    {
        // Arrange
        var fixture = new Fixture()
            .Customize(new AutoMoqCustomization());
        var sut = new TicketOffice(fixture.Create<AuditoriumRepository>(), movieRepository);

        // Act

        var action = sut.Invoking(x => x.BuyTickets(movieSession, 2)).Should().NotThrow();

        // Assert
        action.Subject.Should().HaveCount(2);
        action.Subject.Should().BeOfType<List<Ticket>>();
    }

    [Theory, AutoData]
    public void BuyTickets_FullyBooked_ThrowsException(MovieSessionRepository movieRepository,
                                                       MovieSession movieSession)
    {
        // Arrange
        var fixture = new Fixture()
            .Customize(new AutoMoqCustomization());
        var sut = new TicketOffice(fixture.Create<AuditoriumRepository>(), movieRepository);

        // Act
        _ = sut.BuyTickets(movieSession, movieSession.Tickets.Count);
        var action = sut.Invoking(x => x.BuyTickets(movieSession, 1)).Should().Throw<Exception>();
    }

    [Theory, AutoData]
    public void BuyTickets_NotEnoughTickets_ThrowsException(MovieSessionRepository movieRepository,
                                                            MovieSession movieSession)
    {
        // Arrange
        var fixture = new Fixture()
            .Customize(new AutoMoqCustomization());
        var sut = new TicketOffice(fixture.Create<AuditoriumRepository>(), movieRepository);

        // Act
        _ = sut.BuyTickets(movieSession, movieSession.Tickets.Count - 1);
        var action = sut.Invoking(x => x.BuyTickets(movieRepository.MovieSessions[2], 2)).Should().Throw<Exception>();
    }
}
