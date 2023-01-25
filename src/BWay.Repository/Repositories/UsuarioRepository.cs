using BWay.Infra.Data;
using BWay.Infra.Models;
using BWay.Repository.Interfaces;
using Dapper;
using System.Data;

namespace BWay.Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IUnitOfWork _unitOfWork;
        private DbSession _session;

        public UsuarioRepository(IUnitOfWork unitOfWork, DbSession session)
        {
            _unitOfWork = unitOfWork;
            _session = session;
        }

        public string CadastrarUsuario(UsuarioModel usuario)
        {
            try
            {
                var emailCadastrado = ValidaEmailUsuario(usuario.Email);

                if (emailCadastrado)
                    throw new Exception("Email já cadastrado.");
                
                var idUsuario = _session.Connection.QuerySingle<Guid>(@"
                    INSERT INTO USUARIO(
                        ID_PERFIL_USUARIO
                    ,   NOME
                    ,   EMAIL
                    ,   SENHA
                    ,   ID_STATUS_USUARIO
                    ,   DT_CRIACAO
                    )
                    OUTPUT INSERTED.ID
                    VALUES(
                        @IdPerfilUsuario
                    ,   @Nome
                    ,   @Email
                    ,   @Senha
                    ,   @IdStatusUsuario
                    ,   GETDATE())"
                , new
                {
                    IdPerfilUsuario = usuario.IdPerfilUsuario,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    IdStatusUsuario = usuario.IdStatusUsuario
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                return $"Usuario: {idUsuario}";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ValidaEmailUsuario(string email)
        {
            try
            {
                var emailUsuario = _session.Connection.Query<string>(@"
                    SELECT
                        EMAIL
                    FROM USUARIO
                    WHERE EMAIL = @email"
                , new
                {
                    email = email
                }
                , commandType: CommandType.Text, transaction: _session.Transaction).FirstOrDefault();

                return !String.IsNullOrEmpty(emailUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

    }
}
    