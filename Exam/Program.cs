using Exam.Data;
using Exam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (!db.Matches.Any())
    {
        db.Matches.AddRange(
            new Match { TeamA = "LR", TeamB = "G2", Date = new DateTime(2024, 7, 15), Location = "Stadium A" },
            new Match { TeamA = "KC", TeamB = "MKOI", Date = new DateTime(2024, 7, 16), Location = "Stadium B" },
            new Match { TeamA = "LR", TeamB = "KC", Date = new DateTime(2024, 7, 17), Location = "Stadium C" },
            new Match { TeamA = "G2", TeamB = "MKOI", Date = new DateTime(2024, 7, 18), Location = "Stadium D" }
        );

        db.SaveChanges();
    }
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();

app.Run();
