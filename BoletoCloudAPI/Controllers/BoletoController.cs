using BoletoCloudAPI.Model;
using BoletoCloudAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;

namespace BoletoCloudAPI.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class BoletoController
  {
    private readonly IBoletoRepository _boletoRepository;
    public BoletoController(IBoletoRepository boletoRepository)
    {
      _boletoRepository = boletoRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Boleto>> Get()
    {
      return await _boletoRepository.Get();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Boleto>> GetBoletos(int Id)
    {
      return await _boletoRepository.Get(Id);
    }

    [HttpPost]
    public async Task<ActionResult<Boleto>> PostBoleto([FromBody] Boleto boleto)
      {

      var data = await _boletoRepository.PostAdressAsync(boleto);
      
       var newBoleto = await _boletoRepository.Create(boleto);
        return newBoleto;
           
    }


  }
}
