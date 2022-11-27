namespace DependencyInjection.Domain.Interfaces;

public interface IAuditoriumRepository
{
    List<Auditorium> Auditoriums { get; }

    void Add(Auditorium auditorium);
    bool Delete(Auditorium auditorium);
    IEnumerable<Auditorium> GetByMovieId(Guid movieId);
    IEnumerable<Auditorium> GetByNumber(int auditoriumNumber);
}