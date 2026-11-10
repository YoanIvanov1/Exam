# E-sports Betting Application

This project is an ASP.NET Core MVC web application that simulates a simple esports betting platform. Users can register, log in, view upcoming matches and teams, place bets with virtual tokens, and manage their bets and profile. The application uses Entity Framework Core with SQL Server for data storage and ASP.NET Identity for authentication.

The current version of the project is the foundation of the system and will be extended during the ASP.NET Advanced course.

## --Features--
1. User System
- Register, log in, and log out using ASP.NET Identity.

- Every new user starts with 5000 tokens in their wallet.

- Profile page showing the user's email, wallet balance, and number of placed bets.

2. Matches
- Matches are stored in the database and listed on the Events page.

- Each match has a "Place Bet" button.

3. Betting (CRUD)
- Create: Place a bet on one of the two teams in a match.

- Read: View all of your bets on the "My Bets" page.

- Update: Edit an existing bet (team or amount). The wallet is charged or refunded with the difference.

- Delete: Remove a bet and get the full amount refunded.

4. Teams
- Teams are stored in the database and displayed on the Teams page, ordered by ranking.

5. Validation
- Client-side validation with jQuery Validation Unobtrusive.

- Server-side validation with data annotations on the view models and business checks in the services (valid team, enough tokens, bet ownership).


## --Project Structure--

- `Models` - entity models (`User`, `Match`, `Team`, `Bet`).

- `Data` - `ApplicationDbContext` and `Configurations` with the Fluent API entity configurations and seed data.

- `ViewModels` - models passed to the views, so entities are never exposed to the front-end.

- `Services` - business logic and data access (`MatchService`, `TeamService`, `BetService`, `AccountService`) with their interfaces in `Services/Contracts`, registered through Dependency Injection.

- `Controllers` - thin controllers, grouped by area: `Home`, `Matches`, `Teams`, `Bets` (all bet CRUD), `Account` (profile and logout).

- `Views` - Razor views with a shared layout, partial views (`_Navbar`, `_Footer`, `_BetFormFields`) and sections for scripts.


## --Technologies Used--

- ASP.NET Core MVC (.NET 10)

- Entity Framework Core

- SQL Server

- ASP.NET Identity

- Razor Views

- Bootstrap and custom CSS

- jQuery Validation


## --How to Run the Project--

1. Clone the repository.

2. Open the solution in Visual Studio 2022 or later.

3. Update the connection string `DefaultConnection` in `appsettings.json` to point to your SQL Server instance, for example:
`Server=.\SQLEXPRESS;Database=EsportsLeagueDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=true`

4. Run the following command in Package Manager Console:
`Update-Database`
(or `dotnet ef database update` from the `Exam` project folder).

5. Start the application.

Matches and teams are seeded automatically by the migrations, so no extra setup is needed. No other environment variables or credentials are required; register a new account from the Register page to start betting.
