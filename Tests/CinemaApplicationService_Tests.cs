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
                .AddSingleton<AuditoriumRepository>()
                .AddSingleton<MovieSessionRepository>()
                .AddSingleton<TicketOffice>()
                .AddSingleton<IDateTime>(_dateTime.Object)
                .BuildServiceProvider();
    }

    [Theory, AutoData]
    public void BuyTickets_PurchaseSingleTicket_ReturnsTicket(MovieSession session)
    {
        var sut = _applicationService.GetRequiredService<CinemaApplicationService>();
        var movieSessions = _applicationService.GetRequiredService<MovieSessionRepository>();
        movieSessions.Add(session);

        var actual = sut.BuyTickets(session.SessionId, 1);

        actual.Should().HaveCount(1);
        actual.Should().BeOfType<List<Ticket>>();
    }

    [Theory, AutoData]
    public void BuyTickets_PurchaseMultipleTickets_ReturnsTickets(MovieSession session)
    {
        var sut = _applicationService.GetRequiredService<CinemaApplicationService>();
        var movieSessions = _applicationService.GetRequiredService<MovieSessionRepository>();
        movieSessions.Add(session);

        var actual = sut.BuyTickets(session.SessionId, 3);

        actual.Should().HaveCount(3);
        actual.Should().BeOfType<List<Ticket>>();
    }

    [Theory, AutoData]
    public void BuyTickets_PurchasingTooManyTickets_ThrowsException(MovieSession session)
    {
        var sut = _applicationService.GetRequiredService<CinemaApplicationService>();

        var action = sut
            .Invoking(x => x.BuyTickets(session.SessionId, session.Tickets.Count + 1))
            .Should()
            .Throw<Exception>();
    }

    [Fact]
    public void BuyTickets_WithInvalidId_ThrowsException()
    {
        var sut = _applicationService.GetRequiredService<CinemaApplicationService>();

        var action = sut
            .Invoking(x => x.BuyTickets(Guid.NewGuid(), 1))
            .Should()
            .Throw<Exception>();
    }

    [Theory, AutoData]
    public void EnterAuditorium_WithValidTicketAndTime_NoException(MovieSession movieSession)
    {
        _dateTime.SetupGet(x => x.Now).Returns(movieSession.StartsAt.AddMinutes(-1));

        var sut = _applicationService.GetRequiredService<CinemaApplicationService>();
        var auditoriums = _applicationService.GetRequiredService<AuditoriumRepository>();
        var movieSessions = _applicationService.GetRequiredService<MovieSessionRepository>();

        var auditorium = new Auditorium(movieSession.AuditoriumNumber, 
                                        movieSession.Tickets.Count, 
                                        movieSession, 
                                        _dateTime.Object);

        auditoriums.Add(auditorium);
        movieSessions.Add(movieSession);

        var action = sut
            .Invoking(x => x.EnterAuditorium(movieSession.AuditoriumNumber, movieSession.Tickets[0]))
            .Should()
            .NotThrow();
    }

    [Fact]
    public void EnterAuditorium_WithInvalidTicket_ThrowsException()
    {
        var sut = _applicationService.GetRequiredService<CinemaApplicationService>();
        var movieSessions = _applicationService.GetRequiredService<MovieSessionRepository>();

        var action = sut
            .Invoking(x => x.EnterAuditorium(movieSessions.MovieSessions[0].AuditoriumNumber, new Ticket()))
            .Should()
            .Throw<Exception>();
    }

    [Fact]
    public void EnterAuditorium_IncorrectAuditoriumNumber_ThrowsException()
    {
        var sut = _applicationService.GetRequiredService<CinemaApplicationService>();
        var movieSessions = _applicationService.GetRequiredService<MovieSessionRepository>();

        var action = sut
            .Invoking(x => x.EnterAuditorium(-1, movieSessions.MovieSessions[0].Tickets[5]))
            .Should()
            .Throw<Exception>();
    }
}
