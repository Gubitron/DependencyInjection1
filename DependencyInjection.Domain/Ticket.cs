namespace DependencyInjection.Domain;

public class Ticket
{
    public Guid Id { get; }

    public Ticket()
    {
        Id = Guid.NewGuid();
    }
}