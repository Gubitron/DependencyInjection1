namespace Tests;

public class CinemaApplicationService_Tests
{
    Mock<IDateTime> _dateTime;
    ServiceProvider _applicationService;

    public CinemaApplicationService_Tests()
    {
        _dateTime = new Mock<IDateTime>();

        _applicationService = new ServiceCollection()
                .AddSingleton<CinemaApplicationService>()
                .AddSingleton<IAuditoriumRepository, AuditoriumRepository>()
                .AddSingleton<IMovieSessionRepository, MovieSessionRepository>()
                .AddSingleton<TicketOffice>()
                .AddSingleton<IDateTime>(_dateTime.Object)
                .BuildServiceProvider();
    }

    [Theory, AutoData]
    public void BuyTickets_PurchaseSingleTicket_ReturnsTicket(MovieSession session)
    {
        // Arrange
        var sut = _applicationService.GetRequiredService<CinemaApplicationService>();
        var movieSessions = _applicationService.GetRequiredService<IMovieSessionRepository>();
        movieSessions.Add(session);

        // Act
        var actual = sut.BuyTickets(session.SessionId, 1);

        // Assert
        actual.Should().HaveCount(1);
        actual.Should().BeOfType<List<Ticket>>();
    }

    [Theory, AutoData]
    public void BuyTickets_PurchaseMultipleTickets_ReturnsTickets(MovieSession session)
    {
        // Arrange
        var sut = _applicationService.GetRequiredService<CinemaApplicationService>();
        var movieSessions = _applicationService.GetRequiredService<IMovieSessionRepository>();
        movieSessions.Add(session);

        // Act
        var actual = sut.BuyTickets(session.SessionId, 3);

        // Assert
        actual.Should().HaveCount(3);
        actual.Should().BeOfType<List<Ticket>>();
    }

    [Theory, AutoData]
    public void BuyTickets_PurchasingTooManyTickets_ThrowsException(MovieSession session)
    {
        // Arrange
        var sut = _applicationService.GetRequiredService<CinemaApplicationService>();

        // Assert
        var action = sut
            .Invoking(x => x.BuyTickets(session.SessionId, session.Tickets.Count + 1))
            .Should()
            .Throw<Exception>();
    }

    [Fact]
    public void BuyTickets_WithInvalidId_ThrowsException()
    {
        // Arrange
        var sut = _applicationService.GetRequiredService<CinemaApplicationService>();

        // Assert
        var action = sut
            .Invoking(x => x.BuyTickets(Guid.NewGuid(), 1))
            .Should()
            .Throw<Exception>();
    }

    [Theory, AutoData]
    public void EnterAuditorium_WithValidTicketAndTime_NoException(string movieName, 
                                                                   int auditoriumNumber, 
                                                                   DateTime startsAt, 
                                                                   Ticket ticket)
    {
        // Arrange
        var sut = _applicationService.GetRequiredService<CinemaApplicationService>();
        var auditoriums = _applicationService.GetRequiredService<IAuditoriumRepository>();
        var movieSessions = _applicationService.GetRequiredService<IMovieSessionRepository>();

        List<Ticket> tickets = new List<Ticket> { ticket };
        MovieSession movieSession = new MovieSession(tickets, 
                                                     movieName, 
                                                     auditoriumNumber, 
                                                     startsAt);

        _dateTime.SetupGet(x => x.Now).Returns(startsAt.AddMinutes(-1));
        var auditorium = new Auditorium(auditoriumNumber,
                                        tickets.Count, 
                                        movieSession, 
                                        _dateTime.Object);

        auditoriums.Add(auditorium);
        movieSessions.Add(movieSession);

        // Assert
        var action = sut
            .Invoking(x => x.EnterAuditorium(auditoriumNumber, ticket))
            .Should()
            .NotThrow();
    }

    [Fact]
    public void EnterAuditorium_WithInvalidTicket_ThrowsException()
    {
        // Arrange
        var sut = _applicationService.GetRequiredService<CinemaApplicationService>();
        var movieSessions = _applicationService.GetRequiredService<IMovieSessionRepository>();

        // Assert
        var action = sut
            .Invoking(x => x.EnterAuditorium(movieSessions.MovieSessions[0].AuditoriumNumber, new Ticket()))
            .Should()
            .Throw<Exception>();
    }

    [Fact]
    public void EnterAuditorium_IncorrectAuditoriumNumber_ThrowsException()
    {
        // Arrange
        var sut = _applicationService.GetRequiredService<CinemaApplicationService>();
        var movieSessions = _applicationService.GetRequiredService<IMovieSessionRepository>();

        // Assert
        var action = sut
            .Invoking(x => x.EnterAuditorium(-1, movieSessions.MovieSessions[0].Tickets[5]))
            .Should()
            .Throw<Exception>();
    }
}
