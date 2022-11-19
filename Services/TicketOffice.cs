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

    public IEnumerable<Ticket> BuyTickets(MovieSession movieSession, int count)
    {
        if (movieSession.SessionFullyBooked())
        {
            throw new Exception("The movie is fully booked!");
        }

        if (movieSession.CheckRemainingTicketCount() >= count)
        {
            List<Ticket> tickets = new List<Ticket>();
            for (int i = 0; i < count; i++)
            {
                tickets.Add(movieSession.BookTicket());
                movieSession.SetTicketAsBooked(tickets[i].Id);
            }
            return tickets;
        }
        else
        {
            throw new Exception("Not enough tickets remain!");
        }
    }
}
