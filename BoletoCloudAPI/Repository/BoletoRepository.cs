using BoletoCloudAPI.Model;
using Microsoft.EntityFrameworkCore;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace BoletoCloudAPI.Repository
{
  public class BoletoRepository : IBoletoRepository
  {

    public readonly BoletoContext _context;
    public BoletoRepository(BoletoContext context)
    {
      _context = context;
    }
    public async Task<Boleto> Create(Boleto boleto)
    {
      _context.Boletos.Add(boleto);
      await _context.SaveChangesAsync();
      return boleto;
    }
    public async Task<IEnumerable<Boleto>> Get()
    {
      var data = await _context.Boletos.ToListAsync();
      return data;
    }

    public async Task<Boleto> Get(int Id)
    {
      var data = await _context.Boletos.FindAsync(Id);
      return data;
    }

    //public async Task<Boleto> PostAdressAsync(Boleto boleto)
    //{

    //  var boletoCloud = RestService.For<IBoletoRepository>("https://sandbox.boletocloud.com/api/v1/");
    //  var result = await boletoCloud.PostAdressAsync(boleto);
    //  return result;
    //}

    //public async Task<Boleto> PostAdressAsync(Boleto boleto)
    //{

    //  string endPoint = "https://sandbox.boletocloud.com/api/v1/boletos";
    //  var client = new HttpClient();
    //  var data = await client.PostAsync(endPoint, new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)boleto));
    //  if (data.IsSuccessStatusCode == true)
    //  {
    //    boleto.Token = data.Headers.ToString();

    //  }
    //  return boleto;


    //}

    public async Task<Boleto> PostAdressAsync2(Boleto boleto)
    {
      try
      {
        string URI = "https://sandbox.boletocloud.com/api/v1/boletos";
        string myParameters = $"boleto.conta.banco={boleto.bancoconta}&boleto.conta.agencia={boleto.agenciaconta}&boleto.conta.numero={boleto.numeroconta}" +
          $"&boleto.conta.carteira={boleto.carteiraconta}&";

        using (WebClient wc = new WebClient())
        {

          String userName = "api-key_FsS9GOa57VPIU4EyWgTO_p3ut1tGkd3cHcUY_Ed799s=";
          String passWord = "";
          string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + ":" + passWord));

          wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
          wc.Headers[HttpRequestHeader.Authorization] = "Basic" + credentials;
          string HtmlResult = wc.UploadString(URI, myParameters);
          Console.WriteLine(HtmlResult);
        }
      }
      catch (Exception ex)
      {

        throw;
      }


      return boleto;


    }


    public static string Base64Encode(string textToEncode)
    {
      byte[] textAsBytes = Encoding.UTF8.GetBytes(textToEncode);
      return Convert.ToBase64String(textAsBytes);
    }
    public async Task<Boleto> PostAdressAsync(Boleto boleto)
    {


      try
      {

        var data = new Dictionary<string, string>();
        data.Add("boleto.conta.banco", boleto.bancoconta);
        data.Add("boleto.valor", boleto.valor.ToString());
        data.Add("boleto.conta.agencia", boleto.agenciaconta);
        data.Add("boleto.conta.numero", boleto.numeroconta);
        data.Add("boleto.conta.carteira", boleto.carteiraconta.ToString());
        data.Add("boleto.emissao", boleto.emissao.ToString());
        data.Add("boleto.vencimento", boleto.vencimento.ToString());
        data.Add("boleto.numero", boleto.numero);

        //beneficiario
        data.Add("boleto.beneficiario.nome", boleto.nomebeneficiario);
        data.Add("boleto.beneficiario.cprf", boleto.cprfbeneficiario);
        data.Add("boleto.beneficiario.endereco.cep", boleto.cepbeneficiario);
        data.Add("boleto.beneficiario.endereco.uf", boleto.ufbeneficiario);
        data.Add("boleto.beneficiario.endereco.localidade", boleto.localidadebeneficiario);
        data.Add("boleto.beneficiario.endereco.bairro", boleto.bairrobeneficiario);
        data.Add("boleto.beneficiario.endereco.logradouro", boleto.bairrobeneficiario);
        data.Add("boleto.beneficiario.endereco.numero", boleto.numerobeneficiario);
        data.Add("boleto.beneficiario.endereco.complemento", boleto.complementobeneficiario);
        //pagador
        data.Add("boleto.pagador.nome", boleto.nomepagador);
        data.Add("boleto.pagador.cprf", boleto.cprfpagador);
        data.Add("boleto.pagador.endereco.cep", boleto.ceppagador);
        data.Add("boleto.pagador.endereco.uf", boleto.ufpagador);
        data.Add("boleto.pagador.endereco.localidade", boleto.localidadepagador);
        data.Add("boleto.pagador.endereco.bairro", boleto.bairropagador);
        data.Add("boleto.pagador.endereco.numero", boleto.numeropagador);
        data.Add("boleto.pagador.endereco.logradouro", boleto.logradouropagador);

        using (var cliente = new HttpClient())
        {
          var conteudo = new FormUrlEncodedContent(data);

          // ServicePointManager.SecurityProtocol =  SecurityProtocolType.Tls | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;

          String userName = "api-key_FsS9GOa57VPIU4EyWgTO_p3ut1tGkd3cHcUY_Ed799s=";
          String passWord = "";
          cliente.DefaultRequestHeaders.Add($"Authorization", $"Basic {Base64Encode($"{userName}:{passWord}")}");

          //cliente.DefaultRequestHeaders.Authorization =
          //new AuthenticationHeaderValue("Basic ", "api-key_FsS9GOa57VPIU4EyWgTO_p3ut1tGkd3cHcUY_Ed799s=");            
          //conteudo.Headers.Clear();
          //conteudo.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

          var response = await cliente.PostAsync("https://sandbox.boletocloud.com/api/v1/boletos", conteudo);
          return boleto;


        }
      }

      catch (Exception ex)
      {

        throw;
      } 

    }
  }
}
