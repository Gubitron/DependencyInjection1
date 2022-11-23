namespace DependencyInjection1.Services;

// TODO: Use clean architecture
public class CinemaApplicationService
{
    private readonly MovieSessionRepository _movieRepository;
    private readonly AuditoriumRepository _auditoriumRepository;
    private readonly TicketOffice _ticketOffice;

    public CinemaApplicationService(AuditoriumRepository auditoriumRepository,
                                    MovieSessionRepository movieSessionRepository,
                                    TicketOffice ticketOffice)
    {
        _movieRepository = movieSessionRepository;
        _auditoriumRepository = auditoriumRepository;
        _ticketOffice = ticketOffice;
    }

    public IEnumerable<MovieSession> GetMovieListings()
    {
        return _movieRepository.MovieSessions;
    }

    public IEnumerable<Ticket> BuyTickets(Guid movieSessionGuid, int count)
    {
        return TicketOffice.BuyTickets(_movieRepository.GetById(movieSessionGuid).First(), count);
    }

    public void EnterAuditorium(int auditoriumNumber, Ticket ticket)
    {
        if (!_auditoriumRepository.GetByNumber(auditoriumNumber).First().TryEnter(ticket))
        {
            throw new Exception("No such auditorium exists!");
        }
    }
}
