namespace DependencyInjection1.Classes;

public class MovieSession
{
    private readonly Guid _sessionId;
    private readonly int _auditoriumNumber;
    private readonly string _movieName;
    private List<Ticket> _tickets;
    private DateTime _startsAt;


    public MovieSession(IServiceProvider services, string movieName, int auditoriumNumber, int ticketCount, DateTime startsAt)
    {
        _sessionId = Guid.NewGuid();
        _movieName = movieName;
        _auditoriumNumber = auditoriumNumber;
        _startsAt = startsAt;

        _tickets = new List<Ticket>();
        for(int i = 0; i < ticketCount; i++)
        {
            _tickets.Add(ActivatorUtilities.CreateInstance<Ticket>(services));
        }
    }

    public Guid SessionId => _sessionId;

    public int AuditoriumNumber => _auditoriumNumber;

    public string MovieName => _movieName;

    public List<Ticket> Tickets { get => _tickets; }

    public DateTime StartsAt { get => _startsAt; }
}
