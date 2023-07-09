using BWay.Infra.Data;
using BWay.Infra.DTOs;
using BWay.Infra.Models;
using BWay.Repository.Interfaces;
using Dapper;
using System.Data;

namespace BWay.Repository.Repositories
{
    public class OperacaoRepository : IOperacaoRepository
    {
        private IUnitOfWork _unitOfWork;
        private DbSession _session;

        public OperacaoRepository(IUnitOfWork unitOfWork, DbSession session)
        {
            _unitOfWork = unitOfWork;
            _session = session;
        }

        #region Operacao
        public List<OperacaoDTO> ListarOperacao()
        {
            try
            {
                return _session.Connection.Query<OperacaoDTO>(@"
                    SELECT
                        OP.ID AS Id
                    ,   OP.ID_PLANTAO AS IdPlantao
                    ,   OP.DT_ABERTURA AS DataAbertura
                    ,   OP.DT_FECHAMENTO AS DataFechamento
                    ,   OP.HORARIO_BARRA AS HorarioBarra
                    ,   OP.HORARIO_POS_BARRA AS HorarioPosBarra
                    ,   OP.ID_USUARIO_ALTERACAO AS IdUsuarioAlteracao
                    ,   OP.DT_ULTIMA_ALTERACAO AS DataUltimaAlteracao
                    ,   CO.CODIGO  AS CodigoOperacao
                    FROM OPERACAO OP
                        LEFT JOIN CODIGO_OPERACAO CO
                            ON OP.ID = CO.ID_OPERACAO"
                , null
                , commandType: CommandType.Text, transaction: _session.Transaction).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public OperacaoDTO BuscarOperacaoPorId(string idOperacao)
        {
            try
            {
                return _session.Connection.QueryFirstOrDefault<OperacaoDTO>(@"
                    SELECT
                        OP.ID AS Id
                    ,   OP.ID_PLANTAO AS IdPlantao
                    ,   OP.DT_ABERTURA AS DataAbertura
                    ,   OP.DT_FECHAMENTO AS DataFechamento
                    ,   OP.HORARIO_BARRA AS HorarioBarra
                    ,   OP.HORARIO_POS_BARRA AS HorarioPosBarra
                    ,   OP.ID_USUARIO_ALTERACAO AS IdUsuarioAlteracao
                    ,   OP.DT_ULTIMA_ALTERACAO AS DataUltimaAlteracao
                    ,   CO.CODIGO  AS CodigoOperacao
                    FROM OPERACAO OP
                        LEFT JOIN CODIGO_OPERACAO CO
                            ON OP.ID = CO.ID_OPERACAO
                    WHERE OP.ID = @idOperacao"
                , new
                {
                    idOperacao = idOperacao
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CadastrarOperacao(OperacaoModel operacao)
        {
            try
            {
                var plantaoCadastrado = ValidaPlantaoPorId(operacao.IdPlantao);
                if (!plantaoCadastrado)
                    throw new Exception("Plantão não encontrado.");

                var idOperacaoCadastrada = _session.Connection.QuerySingle<Guid>(@"
                    INSERT INTO OPERACAO(
                        ID_PLANTAO
                    ,   DT_ABERTURA
                    ,   DT_FECHAMENTO
                    ,   HORARIO_BARRA
                    ,   HORARIO_POS_BARRA
                    ,   ID_USUARIO_ALTERACAO
                    ,   DT_ULTIMA_ALTERACAO
                    )
                    OUTPUT INSERTED.ID
                    VALUES(
                        @idPlantao
                    ,   @dataAbertura
                    ,   @dataFechamento
                    ,   @horarioBarra
                    ,   @horarioPosBarra
                    ,   @idUsuarioAlteracao
                    ,   GETDATE())"
                , new
                {
                    idPlantao = Guid.Parse(operacao.IdPlantao),
                    dataAbertura = DateTime.Parse(operacao.DataAbertura),
                    dataFechamento = DateTime.Parse(operacao.DataFechamento),
                    horarioBarra = operacao.HorarioBarra,
                    horarioPosBarra = operacao.HorarioPosBarra,
                    idUsuarioAlteracao = Guid.Parse(operacao.IdUsuarioAlteracao)
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                if (string.IsNullOrEmpty(idOperacaoCadastrada.ToString()))
                    throw new Exception("Falha ao incluir operação.");

                var idCodigoOperacaoCadastrado = _session.Connection.QuerySingle<Guid>(@"
                    INSERT INTO CODIGO_OPERACAO(
                        ID_OPERACAO
                    ,   CODIGO                    
                    )
                    OUTPUT INSERTED.ID
                    VALUES(
                        @idOperacao
                    ,   @codigo)"
                , new
                {
                    idOperacao = idOperacaoCadastrada,
                    codigo = operacao.CodigoOperacao
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                if (string.IsNullOrEmpty(idCodigoOperacaoCadastrado.ToString()))
                    throw new Exception("Falha ao incluir CODIGO_OPERACAO.");

                return $"Operação: {idOperacaoCadastrada}";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AtualizarOperacao(string idOperacao, OperacaoModel operacao)
        {
            try
            {
                var operacaoCadastrada = ValidaOperacaoPorId(idOperacao);
                if (!operacaoCadastrada)
                    throw new Exception("Operação informada não encontrada.");

                var plantaoCadastrado = ValidaPlantaoPorId(operacao.IdPlantao);
                if (!plantaoCadastrado)
                    throw new Exception("Plantão informado não encontrado.");                

                var linhasAfetadas = _session.Connection.Execute(@"
                    UPDATE 
                        OPERACAO
                    SET
                        ID_PLANTAO = @idPlantao
                    ,   DT_ABERTURA = @dataAbertura
                    ,   DT_FECHAMENTO = @dataFechamento
                    ,   HORARIO_BARRA = @horarioBarra
                    ,   HORARIO_POS_BARRA = @horarioPosBarra
                    ,   ID_USUARIO_ALTERACAO = @idUsuarioAlteracao
                    ,   DT_ULTIMA_ALTERACAO = GETDATE()           
                    WHERE ID = @idOperacao"
                , new
                {
                    idPlantao = Guid.Parse(operacao.IdPlantao),
                    dataAbertura = DateTime.Parse(operacao.DataAbertura),
                    dataFechamento = DateTime.Parse(operacao.DataFechamento),
                    horarioBarra = operacao.HorarioBarra,
                    horarioPosBarra = operacao.HorarioPosBarra,
                    idUsuarioAlteracao = Guid.Parse(operacao.IdUsuarioAlteracao),
                    idOperacao = Guid.Parse(idOperacao)
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                return linhasAfetadas > 0 ? "Operação atualizada com sucesso." : throw new Exception("Falha ao atualizar operação.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AtualizarCodigoOperacao(string idOperacao, string codigoOperacao)
        {
            try
            {
                var operacaoCadastrada = ValidaOperacaoPorId(idOperacao);
                if (!operacaoCadastrada)
                    throw new Exception("Operação informada não encontrada.");

                var linhasAfetadas = _session.Connection.Execute(@"
                    UPDATE 
                        CODIGO_OPERACAO
                    SET
                        CODIGO = @codigoOperacao           
                    WHERE ID_OPERACAO = @idOperacao"
                , new
                {
                    codigoOperacao = codigoOperacao,
                    idOperacao = Guid.Parse(idOperacao)
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                return linhasAfetadas > 0 ? "Código Operação atualizado com sucesso." : throw new Exception("Falha ao atualizar código operação.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ExcluirOperacao(string idOperacao)
        {
            try
            {
                var linhasAfetadasCodigo = _session.Connection.Execute(@"
                    DELETE FROM  
                        CODIGO_OPERACAO
                    WHERE ID_OPERACAO = @idOperacao"
                , new
                {
                    idOperacao = Guid.Parse(idOperacao)
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                if (linhasAfetadasCodigo == 0)
                    throw new Exception("Falha ao excluir CODIGO_OPERACAO");

                var linhasAfetadasOperacao = _session.Connection.Execute(@"
                    DELETE FROM  
                        OPERACAO
                    WHERE ID = @idOperacao"
                , new
                {
                    idOperacao = Guid.Parse(idOperacao)
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                return linhasAfetadasOperacao > 0 ? "Operação excluída com sucesso." : throw new Exception("Falha ao excluir operação.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ValidaPlantaoPorId(string idPlantao)
        {
            try
            {
                var plantao = _session.Connection.Query<string>(@"
                    SELECT
                        NOME_PLANTAO
                    FROM PLANTAO
                    WHERE ID = @idPlantao"
                , new
                {
                    idPlantao = Guid.Parse(idPlantao)
                }
                , commandType: CommandType.Text, transaction: _session.Transaction).FirstOrDefault();

                return !String.IsNullOrEmpty(plantao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ValidaOperacaoPorId(string idOperacao)
        {
            try
            {
                var plantao = _session.Connection.Query<string>(@"
                    SELECT
                        DT_ABERTURA
                    FROM OPERACAO
                    WHERE ID = @idOperacao"
                , new
                {
                    idOperacao = Guid.Parse(idOperacao)
                }
                , commandType: CommandType.Text, transaction: _session.Transaction).FirstOrDefault();

                return !String.IsNullOrEmpty(plantao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
