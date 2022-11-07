using BWay.Integracao.Interface;
using BWay.Integracao.Model;
using System.Net;

namespace BWay.Integracao.Service
{
    public class OperacaoCorretorIntegracao : IOperacaoCorretorIntegracao
    {

        public OperacaoCorretorIntegracao()
        {
        }

        public async Task<List<CorretorIntegracaoModel>> ObterCorretoresSorteio(int idOperacao)
        {
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var corretores = JsonConvert.DeserializeObject<Envelope<List<CorretorIntegracaoModel>>>(response.Content).Data;
                return corretores;
            }

            return new List<CorretorIntegracaoModel>();
        }

        public async Task<List<CorretorIntegracaoModel>> ObterCorretoresAtendimento(int idOperacao)
        {
            var request = new RestRequest($"{idOperacao}/elegiveisAoAtendimento", Method.Get);
            var response = await _clientHttp.GetAsync(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var corretores = JsonConvert.DeserializeObject<Envelope<List<CorretorIntegracaoModel>>>(response.Content).Data;
                return corretores;
            }

            return new List<CorretorIntegracaoModel>();
        }
    }
}
