namespace DependencyInjection1.Repositories;

public class MovieSessionRepository
{
    private List<MovieSession> _movieSessions;

    public MovieSessionRepository()
    {
        _movieSessions = new List<MovieSession>();

        _movieSessions.Add(new MovieSession("Die Harder!", 1, 10, new DateTime(2022, 11, 20, 15, 30, 00)));
        _movieSessions.Add(new MovieSession("Home and NOT Alone...", 3, 12, new DateTime(2022, 11, 20, 19, 00, 00)));
        _movieSessions.Add(new MovieSession("Schindler's Lift  ¯\\_(ツ)_/¯", 3, 15, new DateTime(2022, 11, 21, 13, 30, 00)));
    }

    public List<MovieSession> MovieSessions { get => _movieSessions; }
}
