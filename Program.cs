Console.WriteLine("Welcome to the Totally Not Overpriced Cinema!");

var serviceProvider = new ServiceCollection()
    .AddSingleton<CinemaApplicationService>()
    .AddSingleton<TicketOffice>()
    .AddSingleton<MovieSessionRepository>()
    .AddSingleton<AuditoriumRepository>()
    .AddSingleton<IDateTime>
    .BuildServiceProvider();

var applicationService = serviceProvider.GetRequiredService<CinemaApplicationService>();

List<MovieSession> movies = applicationService.GetMovieListings().ToList();
List<Ticket> tickets = new List<Ticket>();

_ = Console.ReadLine();
