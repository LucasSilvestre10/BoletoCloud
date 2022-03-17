using BoletoCloudAPI.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Refit;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
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
     
    
    //ultilizado para converter a strings do token em base64
    public static string Base64Encode(string textToEncode)
    {
      byte[] textAsBytes = Encoding.UTF8.GetBytes(textToEncode);
      return Convert.ToBase64String(textAsBytes);
    }
    public async Task<Boleto> PostAdressAsync(Boleto boleto)
    {


      try
      {
        //Onde é Gerado as informações do boleto 
        var data = new Dictionary<string, string>();

        data.Add("boleto.conta.banco", boleto.bancoconta);
        data.Add("boleto.documento", boleto.documento);
        data.Add("boleto.numero", boleto.numero);
        data.Add("boleto.valor", boleto.valor.ToString("0.00", CultureInfo.InvariantCulture));        
        if (boleto.juros > 0){data.Add("boleto.juros", boleto.juros.ToString("0.00", CultureInfo.InvariantCulture));}
        if (boleto.multa > 0){data.Add("boleto.multa", boleto.multa.ToString("0.00", CultureInfo.InvariantCulture));}
        data.Add("boleto.conta.agencia", boleto.agenciaconta);
        data.Add("boleto.conta.numero", boleto.numeroconta);
        data.Add("boleto.conta.carteira", boleto.carteiraconta.ToString());
        data.Add("boleto.titulo", boleto.titulo);
        data.Add("boleto.emissao", boleto.emissao.ToString("yyyy-MM-dd"));
        data.Add("boleto.vencimento", boleto.vencimento.ToString("yyyy-MM-dd"));
       
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
        data.Add("boleto.pagador.endereco.logradouro", boleto.logradouropagador);
        data.Add("boleto.pagador.endereco.numero", boleto.numeropagador);

        
        //inicia minha sessão http
        using (var cliente = new HttpClient())
        {
          //onde as informações são convertidas para application/x-www-form-urlencoded
          var conteudo = new FormUrlEncodedContent(data);
          //criado o token de Authorization
          String userName = "api-key_FsS9GOa57VPIU4EyWgTO_p3ut1tGkd3cHcUY_Ed799s=";
          String passWord = "";
          //configurado o tipo de Authorization
          cliente.DefaultRequestHeaders.Add($"Authorization", $"Basic {Base64Encode($"{userName}:{passWord}")}");
          // onde é feito o request em minha sessão
          var response = await cliente.PostAsync("https://sandbox.boletocloud.com/api/v1/boletos", conteudo);
          //armazenando o retorno do request em uma variavel para verificar erros e afins
          string responseBody = await response.Content.ReadAsStringAsync();
          //armazenando o token gerado em variavel para armazenamento no BD
          string responseToken = response.Headers.Location.OriginalString.ToString();
          string[] newToken = responseToken.Split("/api/v1/boletos/");
          boleto.Token = "https://sandbox.boletocloud.com/boleto/2via/atualizada/download/" + newToken[1];

          //retorno de dados com token preenchido
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
