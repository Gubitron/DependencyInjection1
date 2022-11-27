namespace DependencyInjection.Domain.Interfaces;

public interface IMovieSessionRepository
{
    List<MovieSession> MovieSessions { get; }

    void Add(MovieSession session);
    bool Delete(MovieSession session);
    IEnumerable<MovieSession> GetByAuditoriumNumber(int auditoriumNumber);
    IEnumerable<MovieSession> GetById(Guid id);
    IEnumerable<MovieSession> GetByName(string movieName);
}