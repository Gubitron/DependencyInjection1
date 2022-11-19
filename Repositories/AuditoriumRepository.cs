namespace DependencyInjection1.Repositories;

public class AuditoriumRepository
{
    private List<Auditorium> _auditoriums;
    private MovieSessionRepository _movieSessionRepository;

    public AuditoriumRepository(MovieSessionRepository movieSessionRepository)
    {
        _movieSessionRepository = movieSessionRepository;

        _auditoriums = new List<Auditorium>();

        _auditoriums.Add(new Auditorium(1, _movieSessionRepository.MovieSessions[0].Tickets.Count, _movieSessionRepository.MovieSessions[0].SessionId, _movieSessionRepository.MovieSessions[0]));
        _auditoriums.Add(new Auditorium(2, _movieSessionRepository.MovieSessions[1].Tickets.Count, _movieSessionRepository.MovieSessions[1].SessionId, _movieSessionRepository.MovieSessions[1]));
        _auditoriums.Add(new Auditorium(3, _movieSessionRepository.MovieSessions[2].Tickets.Count, _movieSessionRepository.MovieSessions[2].SessionId, _movieSessionRepository.MovieSessions[2]));
    }

    public List<Auditorium> Auditoriums { get => _auditoriums; set => _auditoriums = value; }
}
