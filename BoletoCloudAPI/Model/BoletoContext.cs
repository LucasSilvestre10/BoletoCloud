using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoletoCloudAPI.Model
{
  public class BoletoContext : DbContext
  {
    public BoletoContext(DbContextOptions<BoletoContext> options) : base(options)
    {
      Database.EnsureCreated();
    }
    public DbSet<Boleto> Boletos { get; set; } 

  }
}
