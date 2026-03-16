E-sports Betting Application

This project is an ASP.NET Core MVC web application that simulates a simple esports betting platform. Users can register, log in, view upcoming matches, place bets, and manage their profile. The application uses Entity Framework Core with SQL Server for data storage and ASP.NET Identity for authentication.

The current version of the project is a functional skeleton intended to demonstrate the core structure of the system. It includes the basic flow of viewing matches, placing bets, editing bets, deleting bets, and tracking wallet balance. The project is not feature‑complete and will require additional development to reach its intended final form.

--Features--
1. User System
Register, log in, and log out using ASP.NET Identity.

Profile page showing user information, wallet balance, and all placed bets.

2. Matches
Matches are stored in the database.

Users can view upcoming matches and place bets on them.

3. Betting (CRUD)
Create: Place a bet on a match.

Read: View all bets in the profile page.

Update: Edit an existing bet (team or amount).

Delete: Remove a bet and refund the amount.

4. Teams
Teams are stored in the database and displayed on the Teams page.


--Technologies Used--

ASP.NET Core MVC

Entity Framework Core

SQL Server

ASP.NET Identity

Razor Views

Custom CSS


--How to Run the Project--

1. Clone the repository.

2. Open the solution in Visual Studio 2022 or later.

3. Update the connection string in appsettings.json to point to your SQL Server instance.

4. Run the following command in Package Manager Console:
update-database

5. Start the application.
