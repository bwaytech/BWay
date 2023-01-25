using BWay.Infra.Data;
using BWay.Infra.DTOs;
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

        public List<UsuarioDTO> ListarUsuarios()
        {
            try
            {
                return _session.Connection.Query<UsuarioDTO>(@"
                    SELECT
                        ID AS Id
                    ,   ID_PERFIL_USUARIO AS IdPerfilUsuario
                    ,   NOME AS Nome
                    ,   EMAIL AS Email
                    ,   ID_STATUS_USUARIO AS StatusUsuario
                    ,   DT_CRIACAO AS DataCriacao
                    FROM USUARIO"
                , null
                , commandType: CommandType.Text, transaction: _session.Transaction).ToList();               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CadastrarUsuario(UsuarioModel usuario)
        {
            try
            {
                var emailCadastrado = ValidaEmailUsuario(usuario.Email);

                if (emailCadastrado)
                    throw new Exception("Usuário já cadastrado.");
                
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

        public string AtualizarUsuario(string idUsuario, UsuarioModel usuario)
        {
            try
            {
                var emailCadastrado = ValidaEmailUsuario(usuario.Email);

                if (!emailCadastrado)
                    throw new Exception("Usuário não encontrado.");

                var linhasAfetadas = _session.Connection.Execute(@"
                    UPDATE 
                        USUARIO
                    SET
                        ID_PERFIL_USUARIO = @IdPerfilUsuario
                    ,   NOME = @Nome
                    ,   EMAIL = @Email
                    ,   SENHA = @Senha
                    ,   ID_STATUS_USUARIO = @IdStatusUsuario
                    ,   DT_CRIACAO = GETDATE()
                    WHERE ID = @IdUsuario"
                , new
                {
                    IdPerfilUsuario = usuario.IdPerfilUsuario,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    IdStatusUsuario = usuario.IdStatusUsuario,
                    IdUsuario = Guid.Parse(idUsuario)
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                return linhasAfetadas > 0 ? "Usuário atualizado com sucesso." : throw new Exception("Falha ao atualizar usuário");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ExcluirUsuario(string idUsuario)
        {
            try
            {
                var linhasAfetadas = _session.Connection.Execute(@"
                    DELETE FROM  
                        USUARIO
                    WHERE ID = @IdUsuario"
                , new
                {
                    IdUsuario = Guid.Parse(idUsuario)
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                return linhasAfetadas > 0 ? "Usuário excluído com sucesso." : throw new Exception("Falha ao excluir usuário");
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
    