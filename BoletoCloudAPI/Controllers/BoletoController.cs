using BoletoCloudAPI.Model;
using BoletoCloudAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using System.Diagnostics;

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


    [HttpGet("{Id}")]
    public async Task<ActionResult<Boleto>> GetBoletos(int Id)
    {
      try
      {
        var data = await _boletoRepository.Get(Id);
        //chamada para abrir navegador com link de download do pdf
        Process myProcess = new Process();
        myProcess.StartInfo.UseShellExecute = true;
        myProcess.StartInfo.FileName = data.Token;
        myProcess.Start();
        return data;
      }
      catch (Exception ex)
      {

        throw;
      }
      
    }

    [HttpPost]
    public async Task<ActionResult<Boleto>> PostBoleto([FromBody] Boleto boleto)
      { 

      try
      {
        var data = await _boletoRepository.PostAdressAsync(boleto);
        var newBoleto = await _boletoRepository.Create(data);
        //chamada para abrir navegador com link de download do pdf
        Process myProcess = new Process();
        myProcess.StartInfo.UseShellExecute = true;
        myProcess.StartInfo.FileName = newBoleto.Token;
        myProcess.Start();
        return newBoleto;


      }
      catch (Exception ex)
      {

        throw;
      }



    }


  }
}
