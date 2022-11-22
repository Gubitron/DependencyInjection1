namespace DependencyInjection1.Repositories;

public class AuditoriumRepository
{
    private List<Auditorium> _auditoriums;

    public AuditoriumRepository()
    {
        _auditoriums = new List<Auditorium>();
    }

    public List<Auditorium> Auditoriums { get => _auditoriums; set => _auditoriums = value; }

    public void Add(Auditorium auditorium)
    {
        _auditoriums.Add(auditorium);
    }

    public bool Delete(Auditorium auditorium)
    {
        return _auditoriums.Remove(auditorium);
    }

    public Auditorium Get(int index)
    {
        return _auditoriums[index];
    }
}
