var applicationService = new ServiceCollection()
    .AddSingleton<CinemaApplicationService>()
    .AddSingleton<AuditoriumRepository>()
    .AddSingleton<MovieSessionRepository>()
    .AddSingleton<TicketOffice>()
    .AddSingleton<IDateTime, StandardDateTime>()
    .BuildServiceProvider();

_ = Console.ReadLine();