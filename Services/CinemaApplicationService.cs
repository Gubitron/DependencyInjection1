namespace DependencyInjection1.Services;
public class CinemaApplicationService
{
    private readonly IServiceProvider _services;
    private readonly MovieSessionRepository _movieRepository;
    private readonly AuditoriumRepository _auditoriumRepository;
    private readonly TicketOffice _ticketOffice;

    public CinemaApplicationService(IServiceProvider services)
    {
        _services = services;
        _auditoriumRepository = _services.GetRequiredService<AuditoriumRepository>();
        _movieRepository = _services.GetRequiredService<MovieSessionRepository>();
        _ticketOffice = _services.GetRequiredService<TicketOffice>();
    }

    public IEnumerable<MovieSession> GetMovieListings()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Ticket> BuyTickets(Guid movieSessionGuid, int count)
    {
        throw new NotImplementedException();
    }

    public void EnterAuditorium(int auditoriumNumber, Guid ticketId)
    {
        throw new NotImplementedException();
    }
}
