using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ConsoleProducer.Data.Context;

public class ApplicationDbContext : DbContext
{
    public readonly IDbConnection Connection;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Connection = Database.GetDbConnection();
    }
}