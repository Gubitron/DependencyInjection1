namespace DependencyInjection1.Classes;

public class MovieSession
{
    private readonly Guid _sessionId;
    private readonly int _auditoriumNumber;
    private readonly string _movieName;
    private List<Ticket> _tickets;
    private DateTime _startsAt;
    private Dictionary<Guid, bool> _bookings;
    private Dictionary<Guid, bool> _scannedTickets;


    public MovieSession(string movieName, int auditoriumNumber, int ticketCount, DateTime startsAt)
    {
        _sessionId = Guid.NewGuid();
        _movieName = movieName;
        _auditoriumNumber = auditoriumNumber;
        _startsAt = startsAt;

        _tickets = new List<Ticket>();
        for (int i = 0; i < ticketCount; i++)
        {
            _tickets.Add(new Ticket());
        }

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

    public Ticket? BookTicket()
    {
        foreach (Ticket ticket in _tickets)
        {
            bool value;
            if (_bookings.TryGetValue(ticket.Id, out value))
            {
                if (value == false)
                {
                    SetTicketAsBooked(ticket.Id);
                    return ticket;
                }
            }
        }

        return null;
    }

    public bool TicketValid(Ticket ticket)
    {
        return _tickets.Any(x => x.Id == ticket.Id);
    }

    public bool ScanTicket(Ticket ticket)
    {
        if (!_scannedTickets[ticket.Id])
        {
            _scannedTickets[ticket.Id] = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
