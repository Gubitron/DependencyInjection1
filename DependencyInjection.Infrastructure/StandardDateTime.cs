namespace DependencyInjection.Infrastructure;

public class StandardDateTime : IDateTime
{
    public DateTime Now => DateTime.Now;
}
