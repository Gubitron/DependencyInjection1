Console.WriteLine("Hello, World!");

var serviceProvider = new ServiceCollection()
    .AddSingleton<CinemaApplicationService>()
    .AddSingleton<TicketOffice>()
    .AddSingleton<MovieSessionRepository>()
    .AddSingleton<AuditoriumRepository>()
    .AddTransient<IDateTime, StandardDateTime>()
    .AddTransient<Auditorium>()
    .AddTransient<MovieSession>()
    .AddTransient<Ticket>()
    .BuildServiceProvider();

var application = serviceProvider.GetRequiredService<CinemaApplicationService>();

_ = Console.ReadLine();
