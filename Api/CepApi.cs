using Newtonsoft.Json;
using RestSharp;

namespace FilmesAPI.Api
{
    public static class CepApi
    {
       public static EnderecoApi GetResponse(string cep)
       {
            //var client = new RestClient("https://viacep.com.br/ws/01001000/json/");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);


            var client = new RestClient($"https://viacep.com.br/ws/{cep}/json/");

            client.Timeout = -1;

            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);

            var endereco = JsonConvert.DeserializeObject<EnderecoApi>(response.Content);

            return endereco;
       }
    }
}
