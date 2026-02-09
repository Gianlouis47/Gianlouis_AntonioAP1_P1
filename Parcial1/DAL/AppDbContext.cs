namespace Parcial1.DAL;
using Microsoft.EntityFrameworkCore;
using Parcial1.Models;


public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
   
}