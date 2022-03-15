using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoletoCloudAPI.Model
{
  public class Boleto
  {

    //boleto
    public int Id { get; set; }
    public string Token { get; set; }



    [JsonProperty("boleto.titulo")]
    public string titulo { get; set; }

    [JsonProperty("boleto.aceite")]
    public bool aceite { get; set; }

    [JsonProperty("boleto.documento")]
    public string documento { get; set; }

    [JsonProperty("boleto.documento")]
    public string numero { get; set; }

    [JsonProperty("boleto.sequencial")]
    public int sequencial { get; set; }

    [JsonProperty("boleto.emissao	")]
    public DateTime emissao { get; set; }

    [JsonProperty("boleto.vencimento")]
    public DateTime vencimento { get; set; }

    [JsonProperty("boleto.valor")]
    public decimal valor { get; set; }

    [JsonProperty("boleto.juros")]
    public decimal juros { get; set; }

    [JsonProperty("boleto.multa")]
    public decimal multa { get; set; }
   

    //boleto.beneficiario
    [JsonProperty("boleto.beneficiario.nome")]
    public string nomebeneficiario { get; set; }

    [JsonProperty("boleto.beneficiario.cprf")]
    public string cprfbeneficiario { get; set; }

    [JsonProperty("boleto.beneficiario.endereco.cep")]
    public string cepbeneficiario { get; set; }

    [JsonProperty("boleto.beneficiario.endereco.uf")]
    public string ufbeneficiario { get; set; }

    [JsonProperty("boleto.beneficiario.endereco.localidade")]
    public string localidadebeneficiario { get; set; }

    [JsonProperty("boleto.beneficiario.endereco.bairro")]
    public string bairrobeneficiario { get; set; }

    [JsonProperty("boleto.beneficiario.endereco.logradouro")]
    public string logradourobeneficiario { get; set; }

    [JsonProperty("boleto.beneficiario.endereco.numero")]
    public string numerobeneficiario { get; set; }

    [JsonProperty("boleto.beneficiario.endereco.complemento")]
    public string complementobeneficiario { get; set; }


    //boleto.pagador
    [JsonProperty("boleto.pagador.nome")]
    public string nomepagador { get; set; }

    [JsonProperty("boleto.pagador.cprf")]
    public string cprfpagador { get; set; }

    [JsonProperty("boleto.pagador.endereco.cep")]
    public string ceppagador { get; set; }

    [JsonProperty("boleto.pagador.endereco.uf")]
    public string ufpagador { get; set; }

    [JsonProperty("boleto.pagador.endereco.localidade")]
    public string localidadepagador { get; set; }

    [JsonProperty("boleto.pagador.endereco.bairro")]
    public string bairropagador { get; set; }

    [JsonProperty("boleto.pagador.endereco.logradouro")]
    public string logradouropagador { get; set; }

    [JsonProperty("boleto.pagador.endereco.numero")]
    public string numeropagador { get; set; }

    [JsonProperty("boleto.pagador.endereco.complemento")]
    public string complementopagador { get; set; }

    

    //boleto.banco
    [JsonProperty("boleto.conta.banco")]
    public string bancoconta { get; set; }

    [JsonProperty("boleto.conta.agencia")]
    public string agenciaconta { get; set; }

    [JsonProperty("boleto.conta.numero")]
    public string numeroconta { get; set; }

    [JsonProperty("boleto.conta.carteira")]
    public int carteiraconta { get; set; }

    



  }
}
