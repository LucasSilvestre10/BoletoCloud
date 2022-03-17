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
    public string titulo { get; set; }    
    public bool aceite { get; set; }
    public string documento { get; set; }   
    public string numero { get; set; }
    public int sequencial { get; set; }
    public DateTime emissao { get; set; }
    public DateTime vencimento { get; set; }
    public double valor { get; set; }
    public double juros { get; set; }
    public double multa { get; set; }   


    //boleto.beneficiario
    public string nomebeneficiario { get; set; }
    public string cprfbeneficiario { get; set; }
    public string cepbeneficiario { get; set; }
    public string ufbeneficiario { get; set; }
    public string localidadebeneficiario { get; set; }
    public string bairrobeneficiario { get; set; }
    public string logradourobeneficiario { get; set; }
    public string numerobeneficiario { get; set; }
    public string complementobeneficiario { get; set; }


    //boleto.pagador    
    public string nomepagador { get; set; }
    public string cprfpagador { get; set; }
    public string ceppagador { get; set; }
    public string ufpagador { get; set; }
    public string localidadepagador { get; set; }
    public string bairropagador { get; set; }
    public string logradouropagador { get; set; }
    public string numeropagador { get; set; }
    public string complementopagador { get; set; }

    //boleto.banco    
    public string bancoconta { get; set; }
    public string agenciaconta { get; set; }
    public string numeroconta { get; set; }
    public int carteiraconta { get; set; }

  }

}
