namespace DependencyInjection1.Classes;

public class StandardDateTime : IDateTime
{
    public DateTime Now => DateTime.Now;
}
