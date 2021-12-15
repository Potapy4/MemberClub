using MemberClub.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MemberClub.DAL;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new MemberClubDBContext(serviceProvider.GetRequiredService<DbContextOptions<MemberClubDBContext>>());

        if (context.Users.Any())
        {
            return;
        }

        context.Users.AddRange(
            new User
            {
                Id = 1,
                Name = "John Doe",
                Email = "johndo25@test.com",
                RegistrationDate = DateTime.UtcNow.AddDays(-7)
            },
            new User
            {
                Id = 2,
                Name = "Alex Wilsner",
                Email = "alexwil@test.com",
                RegistrationDate = DateTime.UtcNow.AddDays(-6)
            },
            new User
            {
                Id = 3,
                Name = "Jessica Stew",
                Email = "stew.jess@test.com",
                RegistrationDate = DateTime.UtcNow.AddDays(-5)
            },
            new User
            {
                Id = 4,
                Name = "Michael Ouran",
                Email = "ouranMich233@test.com",
                RegistrationDate = DateTime.UtcNow.AddDays(-4)
            },
            new User
            {
                Id = 5,
                Name = "Simon Flexop",
                Email = "simon@test.com",
                RegistrationDate = DateTime.UtcNow.AddDays(-3)
            },
            new User
            {
                Id = 6,
                Name = "Julia Ertovec",
                Email = "julertovec@test.com",
                RegistrationDate = DateTime.UtcNow.AddDays(-2)
            },new User
            {
                Id = 7,
                Name = "Nick Doffman",
                Email = "nickDoff@test.com",
                RegistrationDate = DateTime.UtcNow.AddDays(-1)
            }
        );

        context.SaveChanges();
    }
}