Console.WriteLine("Welcome to the Totally Not Overpriced Cinema!");

var serviceProvider = new ServiceCollection()
    .AddSingleton<CinemaApplicationService>()
    .AddSingleton<TicketOffice>()
    .AddSingleton<MovieSessionRepository>()
    .AddSingleton<AuditoriumRepository>()
    .BuildServiceProvider();

var applicationService = serviceProvider.GetRequiredService<CinemaApplicationService>();

IEnumerable<MovieSession> movies = applicationService.GetMovieListings();
IEnumerable<Ticket> tickets;

while (true)
{
    Console.WriteLine("\nPress `M` to list the available movies.");
    Console.WriteLine("Press `B` to buy tickets for a movie.");
    Console.WriteLine("Press `E` to enter the auditorium for a movie");
    Console.WriteLine("Press `Q` to exit...\n");

    var input = Console.ReadLine();

    switch (input.ToUpper())
    {
        case "M":
            movies = applicationService.GetMovieListings();
            foreach (MovieSession movie in movies)
            {
                Console.WriteLine($"{movie.MovieName,-30} showing in Auditorium {movie.AuditoriumNumber} at {movie.StartsAt}. Seats available: {movie.CheckRemainingTicketCount()}");
            }
            break;
        case "B":
            Console.WriteLine($"\nWhich movie would you like to buy tickets for? ({0} - {movies.Count()})");
            input = Console.ReadLine();

            int movieNumber;
            if (movies.Count() < int.Parse(input) || int.Parse(input) < 0)
            {
                Console.WriteLine("\nNo such movie!");
                break;
            }

            Console.WriteLine($"\nHow many tickets would you like?");
            input = Console.ReadLine();
            tickets = applicationService.BuyTickets(movies.ToArray()[1].SessionId, int.Parse(input));

            break;
        case "E":
            Console.WriteLine($"\nWhich movie would you");
            break;
        case "Q":
            return;
        default:
            Console.WriteLine("Invalid options!");
            break;
    }
}
