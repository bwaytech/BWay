using BWay.Service.DTOs;

namespace BWay.Service.Interfaces
{
    public interface IAutenticacaoService
    {
        TokenDTO AutenticarUsuario(string login, string senha);
    }
}
