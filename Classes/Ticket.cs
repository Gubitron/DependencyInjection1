namespace DependencyInjection1.Classes;

public class Ticket
{
    private readonly Guid _id;

    public Ticket()
    {
        _id = Guid.NewGuid();
    }

    public Guid Id => _id;
}