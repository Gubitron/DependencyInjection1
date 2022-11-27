namespace DependencyInjection.Domain;

public class MovieSession
{
    private readonly Guid _sessionId;
    private readonly int _auditoriumNumber;
    private readonly string _movieName;
    private List<Ticket> _tickets;
    private DateTime _startsAt;
    private Dictionary<Guid, bool> _bookings;
    private Dictionary<Guid, bool> _scannedTickets;


    public MovieSession(List<Ticket> tickets, string movieName, int auditoriumNumber, DateTime startsAt)
    {
        _sessionId = Guid.NewGuid();
        _movieName = movieName;
        _auditoriumNumber = auditoriumNumber;
        _startsAt = startsAt;
        _tickets = tickets;

        _bookings = new Dictionary<Guid, bool>();
        foreach (Ticket ticket in _tickets)
        {
            _bookings.Add(ticket.Id, false);
        }

        _scannedTickets = new Dictionary<Guid, bool>();
        foreach (Ticket ticket in _tickets)
        {
            _scannedTickets.Add(ticket.Id, false);
        }
    }

    public Guid SessionId => _sessionId;

    public int AuditoriumNumber => _auditoriumNumber;

    public string MovieName => _movieName;

    public List<Ticket> Tickets { get => _tickets; }

    public DateTime StartsAt { get => _startsAt; set => _startsAt = value; }

    public void SetTicketAsBooked(Guid ticketId)
    {
        _bookings[ticketId] = true;
    }

    public bool SessionFullyBooked()
    {
        return _bookings.Values.All(x => x == true);
    }

    public int CheckRemainingTicketCount()
    {
        return _bookings.Where(x => x.Value == false).Count();
    }

    public IEnumerable<Ticket> BookTicket()
    {
        Guid ticketId = _bookings.First(x => x.Value == false).Key;
        SetTicketAsBooked(ticketId);
        return _tickets.Where(x => x.Id == ticketId);
    }

    public bool TicketValid(Ticket ticket)
    {
        return _tickets.Any(x => x.Id == ticket.Id);
    }

    public bool ScanTicket(Ticket ticket)
    {

        if (_scannedTickets[ticket.Id])
        {
            return false;
        }

        _scannedTickets[ticket.Id] = true;
        return true;
    }
}
