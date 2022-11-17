namespace DependencyInjection1.Repositories;

public class MovieSessionRepository
{
    private List<MovieSession> _movieSessions;
    public MovieSessionRepository(IServiceProvider services)
    {
        _movieSessions = new List<MovieSession>();
        var auditoriums = services.GetRequiredService<AuditoriumRepository>();

        MovieSessions.Add(ActivatorUtilities.CreateInstance<MovieSession>(services,
                                                                          "Die Harder!",
                                                                          1,
                                                                          auditoriums.Auditoriums[0].Capacity,
                                                                          new DateTime(2022, 11, 20, 15, 30, 00)));

        MovieSessions.Add(ActivatorUtilities.CreateInstance<MovieSession>(services,
                                                                          "Home and NOT Alone...",
                                                                          2,
                                                                          auditoriums.Auditoriums[1].Capacity,
                                                                          new DateTime(2022, 11, 20, 19, 00, 00)));

        MovieSessions.Add(ActivatorUtilities.CreateInstance<MovieSession>(services,
                                                                          "Schindler's Lift  ¯\\_(ツ)_/¯",
                                                                          3,
                                                                          auditoriums.Auditoriums[2].Capacity,
                                                                          new DateTime(2022, 11, 21, 13, 30, 00)));
    }

    public List<MovieSession> MovieSessions { get => _movieSessions; }
}
