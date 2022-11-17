namespace DependencyInjection1.Repositories;

public class AuditoriumRepository
{
    private List<Auditorium> _auditoriums;

    public AuditoriumRepository(IServiceProvider services)
    {
        _auditoriums = new List<Auditorium>();

        Auditoriums.Add(ActivatorUtilities.CreateInstance<Auditorium>(services, 1, 5));
        Auditoriums.Add(ActivatorUtilities.CreateInstance<Auditorium>(services, 2, 10));
        Auditoriums.Add(ActivatorUtilities.CreateInstance<Auditorium>(services, 3, 13));
    }

    public List<Auditorium> Auditoriums { get => _auditoriums; set => _auditoriums = value; }
}
