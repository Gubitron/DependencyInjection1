namespace DependencyInjection1.Repositories;

public class MovieSessionRepository
{
    private List<MovieSession> _movieSessions;

    public MovieSessionRepository()
    {
        _movieSessions = new List<MovieSession>();
    }

    public List<MovieSession> MovieSessions { get => _movieSessions; }

    public void Add(MovieSession session)
    {
        _movieSessions.Add(session);
    }

    public bool Delete(MovieSession session)
    {
        return _movieSessions.Remove(session);
    }

    public MovieSession Get(int index)
    {
        return _movieSessions[index];
    }
}
