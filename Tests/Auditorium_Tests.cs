namespace Tests;
public class Auditorium_Tests
{
    [Theory, AutoData]
    public void TryEnter_ConditionsMet_ReturnsTrue(MovieSession session)
    {
        // Arrange
        var dateTime = new Mock<IDateTime>();
        dateTime.SetupGet(x => x.Now).Returns(session.StartsAt);

        var sut = new Auditorium(session.AuditoriumNumber, session.Tickets.Count, session, dateTime.Object);

        // Act
        var actual = sut.TryEnter(session.Tickets[0]);

        // Assert
        actual.Should().BeTrue();
    }

    [Theory]
    [AutoData]
    public void TryEnter_TooEarly_ReturnsFalse(MovieSession session)
    {
        // Arrange
        var dateTime = new Mock<IDateTime>();
        dateTime.SetupGet(x => x.Now).Returns(session.StartsAt.AddMinutes(-15.01));

        var sut = new Auditorium(session.AuditoriumNumber, session.Tickets.Count, session, dateTime.Object);

        // Act
        var actual = sut.TryEnter(session.Tickets[0]);

        // Assert
        actual.Should().BeFalse();
    }

    [Theory]
    [AutoData]
    public void TryEnter_TooLate_ReturnsFalse(MovieSession session)
    {
        // Arrange
        var dateTime = new Mock<IDateTime>();
        dateTime.SetupGet(x => x.Now).Returns(session.StartsAt.AddMinutes(0.01));

        var sut = new Auditorium(session.AuditoriumNumber, session.Tickets.Count, session, dateTime.Object);

        // Act
        var actual = sut.TryEnter(session.Tickets[0]);

        // Assert
        actual.Should().BeFalse();
    }

    [Theory]
    [AutoData]
    public void TryEnter_TicketForThisSession_ReturnsFalse(MovieSession session)
    {
        // Arrange
        var dateTime = new Mock<IDateTime>();
        dateTime.SetupGet(x => x.Now).Returns(session.StartsAt);

        var sut = new Auditorium(session.AuditoriumNumber, session.Tickets.Count, session, dateTime.Object);
        var ticket = new Ticket();

        // Act
        var actual = sut.TryEnter(ticket);

        // Assert
        actual.Should().BeFalse();
    }

    [Theory]
    [AutoData]
    public void TryEnter_TicketWasScanned_ReturnsFalse(MovieSession session)
    {
        // Arrange
        var dateTime = new Mock<IDateTime>();
        dateTime.SetupGet(x => x.Now).Returns(session.StartsAt);

        var sut = new Auditorium(session.AuditoriumNumber, session.Tickets.Count, session, dateTime.Object);
        session.ScanTicket(session.Tickets[0]);

        // Act
        var actual = sut.TryEnter(session.Tickets[0]);

        // Assert
        actual.Should().BeFalse();
    }
}