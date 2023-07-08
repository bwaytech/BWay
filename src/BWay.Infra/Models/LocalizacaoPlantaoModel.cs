namespace BWay.Infra.Models
{
    public class LocalizacaoPlantaoModel
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }
        public string Geolocalizacao { get; set; }
        public string IdUsuarioAlteracao { get; set; }

        public LocalizacaoPlantaoModel(string logradouro, int numero, string? complemento, string cidade, string estado, string pais, string cep, string geolocalizacao, string idUsuarioAlteraca)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            Cep = cep;
            Geolocalizacao = geolocalizacao;
            IdUsuarioAlteracao = idUsuarioAlteraca;
        }
    }
}
