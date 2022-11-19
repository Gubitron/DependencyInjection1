namespace DependencyInjection1.Classes;

public class Auditorium : IDateTime
{
    private int _number;
    private int _capacity;
    private Guid _currentMovieSessionId;
    private readonly MovieSession _movieSession;

    public Auditorium(int number, int capacity, Guid movieSessionId, MovieSession movieSession)
    {
        _currentMovieSessionId = movieSessionId;
        _number = number;
        _capacity = capacity;
        _movieSession = movieSession;
    }

    public int Number { get => _number; set => _number = value; }
    public int Capacity { get => _capacity; set => _capacity = value; }
    public Guid CurrentMovieSessionId { get => _currentMovieSessionId; set => _currentMovieSessionId = value; }

    public DateTime Now { get => DateTime.Now;}

    public bool TryEnter(Ticket ticket)
    {
        // Assuming people don't get let into the theatre after the movie started
        if((_movieSession.StartsAt.AddMinutes(-15) >= this.Now) && 
           (_movieSession.StartsAt <= this.Now) && 
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
