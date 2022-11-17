namespace DependencyInjection1.Classes;

public class Ticket
{
    private readonly Guid _id;

    public Ticket()
    {
        _id = new Guid();
    }

    public Guid Id { get; }
}