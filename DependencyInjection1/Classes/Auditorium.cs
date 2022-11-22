namespace DependencyInjection1.Classes;

public class Auditorium
{
    private int _number;
    private int _capacity;
    private Guid _currentMovieSessionId;
    private readonly MovieSession _movieSession;
    private IDateTime _dateTime;

    public Auditorium(int number, int capacity, MovieSession movieSession, IDateTime dateTime)
    {
        _currentMovieSessionId = movieSession.SessionId;
        _number = number;
        _capacity = capacity;
        _movieSession = movieSession;
        _dateTime = dateTime;
    }

    public int Number { get => _number; set => _number = value; }
    public int Capacity { get => _capacity; set => _capacity = value; }
    public Guid CurrentMovieSessionId { get => _currentMovieSessionId; set => _currentMovieSessionId = value; }

    public bool TryEnter(Ticket ticket)
    {
        // Assuming people don't get let into the theatre after the movie started
        if((_movieSession.StartsAt.AddMinutes(-15) <= _dateTime.Now) &&
           (_movieSession.StartsAt >= _dateTime.Now) &&
           _movieSession.TicketValid(ticket) && 
           _movieSession.ScanTicket(ticket))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
