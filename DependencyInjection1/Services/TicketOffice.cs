namespace DependencyInjection1.Services;

public class TicketOffice
{
    private AuditoriumRepository _auditoriumRepository;
    private MovieSessionRepository _movieSessionRepository;

    public TicketOffice(AuditoriumRepository auditoriumRepository, MovieSessionRepository movieSessionRepository)
    {
        _auditoriumRepository = auditoriumRepository;
        _movieSessionRepository = movieSessionRepository;
    }

    public static IEnumerable<Ticket> BuyTickets(MovieSession movieSession, int count)
    {
        if (movieSession.SessionFullyBooked())
        {
            throw new Exception("The movie is fully booked!");
        }

        if (movieSession.CheckRemainingTicketCount() < count)
        {
            throw new Exception("Not enough tickets remain!");
        }

        List<Ticket> tickets = new List<Ticket>();
        for (int i = 0; i < count; i++)
        {
            tickets.Add(movieSession.BookTicket().First());
        }

        return tickets;
    }
}
