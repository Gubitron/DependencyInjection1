namespace DependencyInjection1.Repositories;

public class AuditoriumRepository
{
    public List<Auditorium> Auditoriums { get; }

    public AuditoriumRepository()
    {
        Auditoriums = new List<Auditorium>();
    }

    public void Add(Auditorium auditorium)
    {
        Auditoriums.Add(auditorium);
    }

    public bool Delete(Auditorium auditorium)
    {
        return Auditoriums.Remove(auditorium);
    }

    public IEnumerable<Auditorium> GetByMovieId(Guid movieId)
    {
        return Auditoriums.Where(x => x.CurrentMovieSessionId == movieId);
    }

    public IEnumerable<Auditorium> GetByNumber(int auditoriumNumber)
    {
        return Auditoriums.Where(x => x.Number == auditoriumNumber);
    }
}
