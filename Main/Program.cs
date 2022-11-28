ServiceProvider Services = new ServiceCollection()
            .AddSingleton<CinemaApplicationService>()
            .AddSingleton<IAuditoriumRepository, AuditoriumRepository>()
            .AddSingleton<IMovieSessionRepository, MovieSessionRepository>()
            .AddSingleton<TicketOffice>()
            .AddSingleton<IDateTime, StandardDateTime>()
            .BuildServiceProvider();