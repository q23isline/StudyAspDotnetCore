using Microsoft.EntityFrameworkCore;
namespace StudyAspDotnetCore.Models;
public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) { }
}
