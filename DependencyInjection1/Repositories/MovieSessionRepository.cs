namespace DependencyInjection1.Repositories;

public class MovieSessionRepository
{
    public List<MovieSession> MovieSessions { get; }

    public MovieSessionRepository()
    {
        MovieSessions = new List<MovieSession>();
    }

    public void Add(MovieSession session)
    {
        MovieSessions.Add(session);
    }

    public bool Delete(MovieSession session)
    {
        return MovieSessions.Remove(session);
    }

    public IEnumerable<MovieSession> GetByName(string movieName)
    {

        return MovieSessions.Where(x => x.MovieName == movieName);
    }

    public IEnumerable<MovieSession> GetById(Guid id)
    {
        return MovieSessions.Where(x => x.SessionId == id);
    }

    public IEnumerable<MovieSession> GetByAuditoriumNumber(int auditoriumNumber)
    {
        return MovieSessions.Where(x => x.AuditoriumNumber == auditoriumNumber);
    }
}
