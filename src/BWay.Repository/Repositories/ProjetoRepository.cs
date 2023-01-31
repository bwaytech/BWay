using BWay.Infra.Data;
using BWay.Infra.DTOs;
using BWay.Infra.Models;
using BWay.Repository.Interfaces;
using Dapper;
using System.Data;

namespace BWay.Repository.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private IUnitOfWork _unitOfWork;
        private DbSession _session;

        public ProjetoRepository(IUnitOfWork unitOfWork, DbSession session)
        {
            _unitOfWork = unitOfWork;
            _session = session;
        }

        public List<ProjetoDTO> ListarProjetos()
        {
            try
            {
                return _session.Connection.Query<ProjetoDTO>(@"
                    SELECT
                        ID AS Id
                    ,   NOME AS Nome
                    ,   DESCRICAO AS Descricao
                    ,   ID_USUARIO_ALTERACAO AS IdUsuarioAlteracao
                    ,   DT_ULTIMA_ALTERACAO AS DataUltimaAlteracao
                    FROM PROJETO"
                , null
                , commandType: CommandType.Text, transaction: _session.Transaction).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ProjetoDTO BuscarProjetoPorId(string idProjeto)
        {
            try
            {
                return _session.Connection.QueryFirstOrDefault<ProjetoDTO>(@"
                    SELECT
                        ID AS Id
                    ,   NOME AS Nome
                    ,   DESCRICAO AS Descricao
                    ,   ID_USUARIO_ALTERACAO AS IdUsuarioAlteracao
                    ,   DT_ULTIMA_ALTERACAO AS DataUltimaAlteracao
                    FROM PROJETO
                    WHERE ID = @IdProjeto"
                , new
                {
                    IdProjeto = idProjeto
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CadastrarProjeto(ProjetoModel projeto)
        {
            try
            {
                var projetoCadastrado = ValidaProjeto(projeto.Nome);

                if (projetoCadastrado)
                    throw new Exception("Projeto já cadastrado.");

                var idProjeto = _session.Connection.QuerySingle<Guid>(@"
                    INSERT INTO PROJETO(
                        NOME
                    ,   DESCRICAO
                    ,   ID_USUARIO_ALTERACAO
                    ,   DT_ULTIMA_ALTERACAO
                    )
                    OUTPUT INSERTED.ID
                    VALUES(
                        @Nome
                    ,   @Descricao
                    ,   @IdUsuarioAlteracao
                    ,   GETDATE())"
                , new
                {
                    Nome = projeto.Nome,
                    Descricao = projeto.Descricao,
                    IdUsuarioAlteracao = projeto.IdUsuarioAlteracao
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                return $"Projeto: {idProjeto}";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AtualizarProjeto(string idProjeto, ProjetoModel projeto)
        {
            try
            {
                var projetoCadastrado = ValidaProjeto(projeto.Nome);

                if (!projetoCadastrado)
                    throw new Exception("Projeto não encontrado.");

                var linhasAfetadas = _session.Connection.Execute(@"
                    UPDATE 
                        PROJETO
                    SET
                        NOME = @Nome
                    ,   DESCRICAO = @Descricao
                    ,   ID_USUARIO_ALTERACAO = @IdUsuarioAlteracao
                    ,   DT_ULTIMA_ALTERACAO = GETDATE()
                    WHERE ID = @IdProjeto"
                , new
                {
                    Nome = projeto.Nome,
                    Descricao = projeto.Descricao,
                    IdUsuarioAlteracao = projeto.IdUsuarioAlteracao,
                    IdProjeto = Guid.Parse(idProjeto)
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                return linhasAfetadas > 0 ? "Projeto atualizado com sucesso." : throw new Exception("Falha ao atualizar projeto");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ExcluirProjeto(string idProjeto)
        {
            try
            {
                var linhasAfetadas = _session.Connection.Execute(@"
                    DELETE FROM  
                        PROJETO
                    WHERE ID = @IdProjeto"
                , new
                {
                    IdProjeto = Guid.Parse(idProjeto)
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                return linhasAfetadas > 0 ? "Projeto excluído com sucesso." : throw new Exception("Falha ao excluir projeto");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private bool ValidaProjeto(string nome)
        {
            try
            {
                var projeto = _session.Connection.Query<string>(@"
                    SELECT
                        NOME
                    FROM PROJETO
                    WHERE NOME = @Nome"
                , new
                {
                    Nome = nome
                }
                , commandType: CommandType.Text, transaction: _session.Transaction).FirstOrDefault();

                return !String.IsNullOrEmpty(projeto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
