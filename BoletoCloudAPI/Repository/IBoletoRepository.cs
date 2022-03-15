using BoletoCloudAPI.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoletoCloudAPI.Repository
{
  public interface IBoletoRepository
  {
    Task<IEnumerable<Boleto>> Get();
    Task<Boleto> Get(int Id);
    Task<Boleto> Create(Boleto boleto);

    [Post("/boleto/{boleto}")]
    Task<Boleto> PostAdressAsync(Boleto boleto);    
  }
}
