namespace DependencyInjection.Infrastructure;
public class CinemaServiceProvider
{
    public ServiceProvider Services { get; }

    public CinemaServiceProvider()
    {
        Services = new ServiceCollection()
                .AddSingleton<CinemaApplicationService>()
                .AddSingleton<IAuditoriumRepository, AuditoriumRepository>()
                .AddSingleton<IMovieSessionRepository, MovieSessionRepository>()
                .AddSingleton<TicketOffice>()
                .AddSingleton<IDateTime, StandardDateTime>()
                .BuildServiceProvider();
    }
}
