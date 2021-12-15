using MemberClub.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace MemberClub.DAL;

public class MemberClubDBContext : DbContext
{
    public MemberClubDBContext(DbContextOptions<MemberClubDBContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
}