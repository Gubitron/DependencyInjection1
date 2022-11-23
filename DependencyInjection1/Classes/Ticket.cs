namespace DependencyInjection1.Classes;

public class Ticket
{
    public Guid Id { get; }

    public Ticket()
    {
        Id = Guid.NewGuid();
    }
}