namespace DependencyInjection1.Services;

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
        foreach (MovieSession movieSession in _movieRepository.MovieSessions)
        {
            if (movieSession.SessionId == movieSessionGuid)
            {
                return _ticketOffice.BuyTickets(movieSession, count);
            }
        }

        throw new Exception("Movie doesn't exist!");
    }

    public void EnterAuditorium(int auditoriumNumber, Ticket ticket)
    {
        _auditoriumRepository.Auditoriums[auditoriumNumber].TryEnter(ticket);
    }
}
