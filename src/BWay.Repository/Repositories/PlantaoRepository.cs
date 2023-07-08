using BWay.Infra.Data;
using BWay.Infra.DTOs;
using BWay.Infra.Models;
using BWay.Repository.Interfaces;
using Dapper;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace BWay.Repository.Repositories
{
    public class PlantaoRepository : IPlantaoRepository
    {
        private IUnitOfWork _unitOfWork;
        private DbSession _session;

        public PlantaoRepository(IUnitOfWork unitOfWork, DbSession session)
        {
            _unitOfWork = unitOfWork;
            _session = session;
        }

        #region LocalizacaoPlantao
        public List<LocalizacaoPlantaoDTO> ListarLocalizacaoPlantao()
        {
            try
            {
                return _session.Connection.Query<LocalizacaoPlantaoDTO>(@"
                    SELECT
                        ID AS Id
                    ,   LOGRADOURO AS Logradouro
                    ,   NUMERO AS Numero
                    ,   COMPLEMENTO AS Complemento
                    ,   CIDADE AS Cidade
                    ,   ESTADO AS Estado
                    ,   PAIS AS Pais
                    ,   CEP AS Cep
                    ,   GEOLOCALIZACAO AS Geolocalizacao
                    ,   ID_USUARIO_ALTERACAO AS IdUsuarioAlteracao
                    ,   DT_ULTIMA_ALTERACAO AS DataUltimaAlteracao
                    FROM LOCALIZACAO_PLANTAO"
                , null
                , commandType: CommandType.Text, transaction: _session.Transaction).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LocalizacaoPlantaoDTO BuscarLocalizacaoPlantaoPorId(string idLocalizacaoPlantao)
        {
            try
            {
                return _session.Connection.QueryFirstOrDefault<LocalizacaoPlantaoDTO>(@"
                    SELECT
                        ID AS Id
                    ,   LOGRADOURO AS Logradouro
                    ,   NUMERO AS Numero
                    ,   COMPLEMENTO AS Complemento
                    ,   CIDADE AS Cidade
                    ,   ESTADO AS Estado
                    ,   PAIS AS Pais
                    ,   CEP AS Cep
                    ,   GEOLOCALIZACAO AS Geolocalizacao
                    ,   ID_USUARIO_ALTERACAO AS IdUsuarioAlteracao
                    ,   DT_ULTIMA_ALTERACAO AS DataUltimaAlteracao
                    FROM LOCALIZACAO_PLANTAO
                    WHERE ID = @idLocalizacaoPlantao"
                , new
                {
                    idLocalizacaoPlantao = idLocalizacaoPlantao
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CadastrarLocalizacaoPlantao(LocalizacaoPlantaoModel localizacaoPlantao)
        {
            try
            {
                var localizacaoPlantaoCadastrado = ValidaLocalizacaoPlantao(localizacaoPlantao.Logradouro);

                if (localizacaoPlantaoCadastrado)
                    throw new Exception("Localização de plantão já cadastrada.");

                var idlocalizacaoPlantaoCadastrado = _session.Connection.QuerySingle<Guid>(@"
                    INSERT INTO LOCALIZACAO_PLANTAO(
                        LOGRADOURO
                    ,   NUMERO
                    ,   COMPLEMENTO
                    ,   CIDADE
                    ,   ESTADO
                    ,   PAIS
                    ,   CEP
                    ,   GEOLOCALIZACAO
                    ,   ID_USUARIO_ALTERACAO
                    ,   DT_ULTIMA_ALTERACAO
                    )
                    OUTPUT INSERTED.ID
                    VALUES(
                        @logradouro
                    ,   @numero
                    ,   @complemento
                    ,   @cidade
                    ,   @estado
                    ,   @pais
                    ,   @cep
                    ,   @geolocalizacao
                    ,   @IdUsuarioAlteracao
                    ,   GETDATE())"
                , new
                {
                    logradouro = localizacaoPlantao.Logradouro,
                    numero = localizacaoPlantao.Numero,
                    complemento = localizacaoPlantao.Complemento,
                    cidade = localizacaoPlantao.Cidade,
                    estado = localizacaoPlantao.Estado,
                    pais = localizacaoPlantao.Pais,
                    cep = localizacaoPlantao.Cep,
                    geolocalizacao = localizacaoPlantao.Geolocalizacao,
                    IdUsuarioAlteracao = localizacaoPlantao.IdUsuarioAlteracao
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                return $"Loacalização Plantão: {idlocalizacaoPlantaoCadastrado}";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AtualizarLocalizacaoPlantao(string idLocalizacaoPlantao, LocalizacaoPlantaoModel localizacaoPlantao)
        {
            try
            {
                var linhasAfetadas = _session.Connection.Execute(@"
                    UPDATE 
                        LOCALIZACAO_PLANTAO
                    SET
                        LOGRADOURO = @logradouro
                    ,   NUMERO = @numero
                    ,   COMPLEMENTO = @complemento
                    ,   CIDADE = @cidade
                    ,   ESTADO = @estado
                    ,   PAIS = @pais
                    ,   CEP = @cep
                    ,   GEOLOCALIZACAO = @geolocalizacao
                    ,   ID_USUARIO_ALTERACAO = @IdUsuarioAlteracao
                    ,   DT_ULTIMA_ALTERACAO = GETDATE()
                    WHERE ID = @IdLocalizacaoPlantao"
                , new
                {
                    logradouro = localizacaoPlantao.Logradouro,
                    numero = localizacaoPlantao.Numero,
                    complemento = localizacaoPlantao.Complemento,
                    cidade = localizacaoPlantao.Cidade,
                    estado = localizacaoPlantao.Estado,
                    pais = localizacaoPlantao.Pais,
                    cep = localizacaoPlantao.Cep,
                    geolocalizacao = localizacaoPlantao.Geolocalizacao,
                    IdUsuarioAlteracao = localizacaoPlantao.IdUsuarioAlteracao,
                    IdLocalizacaoPlantao = Guid.Parse(idLocalizacaoPlantao)
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                return linhasAfetadas > 0 ? "Localização do plantão atualizada com sucesso." : throw new Exception("Falha ao atualizar localização do plantão.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ExcluirLocalizacaoPlantao(string idLocalizacaoPlantao)
        {
            try
            {
                var plantaoVinculado = ExisteLocalizacaoPlantaoPorId(idLocalizacaoPlantao);
                if (!string.IsNullOrEmpty(plantaoVinculado))
                    throw new Exception($"Não é possível excluir a localização de plantão, pois o plantão de endereço: {plantaoVinculado}, está vinculado.");

                var linhasAfetadas = _session.Connection.Execute(@"
                    DELETE FROM  
                        LOCALIZACAO_PLANTAO
                    WHERE ID = @IdLocalizacao"
                , new
                {
                    IdLocalizacao = Guid.Parse(idLocalizacaoPlantao)
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                return linhasAfetadas > 0 ? "Localização do plantão excluída com sucesso." : throw new Exception("Falha ao excluir localização do plantão");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ValidaLocalizacaoPlantao(string logaradouro)
        {
            try
            {
                var localizacaoPlantao = _session.Connection.Query<string>(@"
                    SELECT
                        LOGRADOURO
                    FROM LOCALIZACAO_PLANTAO
                    WHERE LOGRADOURO = @logaradouro"
                , new
                {
                    logaradouro = logaradouro
                }
                , commandType: CommandType.Text, transaction: _session.Transaction).FirstOrDefault();

                return !String.IsNullOrEmpty(localizacaoPlantao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string ExisteLocalizacaoPlantaoPorId(string idLocalizacaoPlantao)
        {
            try
            {
                var nomePlantao = _session.Connection.Query<string>(@"
                    SELECT
                        NOME_PLANTAO
                    FROM PLANTAO
                    WHERE ID_LOCALIZACAO_PLANTAO = @idLocalizacaoPlantao"
                , new
                {
                    idLocalizacaoPlantao = idLocalizacaoPlantao
                }
                , commandType: CommandType.Text, transaction: _session.Transaction).FirstOrDefault();

                return nomePlantao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion



        #region Plantao
        public List<PlantaoDTO> ListarPlantao()
        {
            try
            {
                return _session.Connection.Query<PlantaoDTO>(@"
                    SELECT
                        P.ID AS Id
                    ,   P.ID_LOCALIZACAO_PLANTAO AS IdLocalizacaoPlantao
                    ,   P.ID_USUARIO_RESPONSAVEL AS IdUsuarioResponsavel
                    ,   P.NOME_PLANTAO AS NomePlantao
                    ,   P.HORARIO_ABERTURA AS HorarioAbertura
                    ,   P.HORARIO_FECHAMENTO AS HorarioFechamento
                    ,   PP.ID_PROJETO AS IdProjeto
                    ,   P.ID_USUARIO_ALTERACAO AS IdUsuarioAlteracao
                    ,   P.DT_ULTIMA_ALTERACAO AS DataUltimaAlteracao
                    FROM PLANTAO P
                        LEFT JOIN PROJETO_PLANTAO PP
                            ON P.ID = PP.ID_PLANTAO"
                , null
                , commandType: CommandType.Text, transaction: _session.Transaction).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PlantaoDTO BuscarPlantaoPorId(string idPlantao)
        {
            try
            {
                return _session.Connection.QueryFirstOrDefault<PlantaoDTO>(@"
                    SELECT
                        P.ID AS Id
                    ,   P.ID_LOCALIZACAO_PLANTAO AS IdLocalizacaoPlantao
                    ,   P.ID_USUARIO_RESPONSAVEL AS IdUsuarioResponsavel
                    ,   P.NOME_PLANTAO AS NomePlantao
                    ,   P.HORARIO_ABERTURA AS HorarioAbertura
                    ,   P.HORARIO_FECHAMENTO AS HorarioFechamento
                    ,   PP.ID_PROJETO AS IdProjeto
                    ,   P.ID_USUARIO_ALTERACAO AS IdUsuarioAlteracao
                    ,   P.DT_ULTIMA_ALTERACAO AS DataUltimaAlteracao
                    FROM PLANTAO P
                        LEFT JOIN PROJETO_PLANTAO PP
                            ON P.ID = PP.ID_PLANTAO
                    WHERE P.ID = @idPlantao"
                , new
                {
                    idPlantao = idPlantao
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CadastrarPlantao(PlantaoModel plantao)
        {
            try
            {
                var plantaoCadastrado = ValidaPlantao(plantao.NomePlantao);
                if (plantaoCadastrado)
                    throw new Exception("Plantão já cadastrado.");

                var projetoCadastrado = ValidaProjeto(plantao.IdProjeto);
                if (!projetoCadastrado)
                    throw new Exception("Projeto informado não encontrado.");

                var localizacaoPlantaoCadastrado = ValidaLocalizacaoPlantaoPorId(plantao.IdLocalizacaoPlantao);
                if (!localizacaoPlantaoCadastrado)
                    throw new Exception("Localização do plantão informado não encontrada.");
                

                var idPlantaoCadastrado = _session.Connection.QuerySingle<Guid>(@"
                    INSERT INTO PLANTAO(
                        ID_LOCALIZACAO_PLANTAO
                    ,   ID_USUARIO_RESPONSAVEL
                    ,   NOME_PLANTAO
                    ,   HORARIO_ABERTURA
                    ,   HORARIO_FECHAMENTO
                    ,   ID_USUARIO_ALTERACAO
                    ,   DT_ULTIMA_ALTERACAO
                    )
                    OUTPUT INSERTED.ID
                    VALUES(
                        @idLocalizacaoPlantao
                    ,   @idUsuarioResponsavel
                    ,   @nomePlantao
                    ,   @horarioAbertura
                    ,   @horarioFechamento
                    ,   @IdUsuarioAlteracao
                    ,   GETDATE())"
                , new
                {
                    idLocalizacaoPlantao = plantao.IdLocalizacaoPlantao,
                    idUsuarioResponsavel = plantao.IdUsuarioResponsavel,
                    nomePlantao = plantao.NomePlantao,
                    horarioAbertura = plantao.HorarioAbertura,
                    horarioFechamento = plantao.HorarioFechamento,                   
                    IdUsuarioAlteracao = plantao.IdUsuarioAlteracao
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                if (string.IsNullOrEmpty(idPlantaoCadastrado.ToString()))
                    throw new Exception("Falha ao incluir plantão");

                var idProjetoPlantaoCadastrado = _session.Connection.QuerySingle<Guid>(@"
                    INSERT INTO PROJETO_PLANTAO(
                        ID_PROJETO
                    ,   ID_PLANTAO                    
                    )
                    OUTPUT INSERTED.ID
                    VALUES(
                        @idProjeto
                    ,   @idPlantao)"
                , new
                {
                    idProjeto = plantao.IdProjeto,
                    idPlantao = idPlantaoCadastrado,
                    
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

               
                if (string.IsNullOrEmpty(idProjetoPlantaoCadastrado.ToString()))
                    throw new Exception("Falha ao incluir PROJETO_PLANTAO");
                

                return $"Plantão: {idPlantaoCadastrado}";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string AtualizarPlantao(string idPlantao, PlantaoModel plantao)
        {
            try
            {
                var plantaoCadastrado = ValidaPlantaoPorId(idPlantao);
                if (!plantaoCadastrado)
                    throw new Exception("Plantão informado não encontrado.");

                var projetoCadastrado = ValidaProjeto(plantao.IdProjeto);
                if (!projetoCadastrado)
                    throw new Exception("Projeto informado não encontrado.");

                var localizacaoPlantaoCadastrado = ValidaLocalizacaoPlantaoPorId(plantao.IdLocalizacaoPlantao);
                if (!localizacaoPlantaoCadastrado)
                    throw new Exception("Localização do plantão informada não encontrada.");

                var linhasAfetadas = _session.Connection.Execute(@"
                    UPDATE 
                        PLANTAO
                    SET
                        ID_LOCALIZACAO_PLANTAO = @idLocalizacaoPlantao
                    ,   ID_USUARIO_RESPONSAVEL = @idUsuarioResponsavel
                    ,   NOME_PLANTAO = @nomePlantao
                    ,   HORARIO_ABERTURA = @horarioAbertura
                    ,   HORARIO_FECHAMENTO = @horarioFechamento
                    ,   ID_USUARIO_ALTERACAO = @idUsuarioAlteracao
                    ,   DT_ULTIMA_ALTERACAO = GETDATE()                   
                    WHERE ID = @idPlantao"
                , new
                {
                    idLocalizacaoPlantao = Guid.Parse(plantao.IdLocalizacaoPlantao),
                    idUsuarioResponsavel = Guid.Parse(plantao.IdUsuarioResponsavel),
                    nomePlantao = plantao.NomePlantao,
                    horarioAbertura = plantao.HorarioAbertura,
                    horarioFechamento = plantao.HorarioFechamento,
                    idUsuarioAlteracao = Guid.Parse(plantao.IdUsuarioAlteracao),
                    idPlantao = idPlantao
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                return linhasAfetadas > 0 ? "Plantão atualizado com sucesso." : throw new Exception("Falha ao atualizar plantão.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ExcluirPlantao(string idPlantao)
        {
            try
            {
                var linhasAfetadasProjeto = _session.Connection.Execute(@"
                    DELETE FROM  
                        PROJETO_PLANTAO
                    WHERE ID_PLANTAO = @idPlantao"
                , new
                {
                    idPlantao = Guid.Parse(idPlantao)
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                if (linhasAfetadasProjeto == 0)
                    throw new Exception("Falha ao excluir PROJETO_PLANTAO");

                var linhasAfetadasPlantao = _session.Connection.Execute(@"
                    DELETE FROM  
                        PLANTAO
                    WHERE ID = @idPlantao"
                , new
                {
                    idPlantao = Guid.Parse(idPlantao)
                }
                , commandType: CommandType.Text, transaction: _session.Transaction);

                return linhasAfetadasPlantao > 0 ? "Plantão excluído com sucesso." : throw new Exception("Falha ao excluir plantão.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ValidaPlantao(string nomePlantao)
        {
            try
            {
                var plantao = _session.Connection.Query<string>(@"
                    SELECT
                        NOME_PLANTAO
                    FROM PLANTAO
                    WHERE NOME_PLANTAO = @nomePlantao"
                , new
                {
                    nomePlantao = nomePlantao
                }
                , commandType: CommandType.Text, transaction: _session.Transaction).FirstOrDefault();

                return !String.IsNullOrEmpty(plantao);
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
                    idPlantao = idPlantao
                }
                , commandType: CommandType.Text, transaction: _session.Transaction).FirstOrDefault();

                return !String.IsNullOrEmpty(plantao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ValidaProjeto(string idProjeto)
        {
            try
            {
                var plantao = _session.Connection.Query<string>(@"
                    SELECT
                        NOME
                    FROM PROJETO
                    WHERE ID = @idProjeto"
                , new
                {
                    idProjeto = idProjeto
                }
                , commandType: CommandType.Text, transaction: _session.Transaction).FirstOrDefault();

                return !String.IsNullOrEmpty(plantao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ValidaLocalizacaoPlantaoPorId(string idLoclaizacaoPlantao)
        {
            try
            {
                var localizacaoPlantao = _session.Connection.Query<string>(@"
                    SELECT
                        LOGRADOURO
                    FROM LOCALIZACAO_PLANTAO
                    WHERE ID = @idLoclaizacaoPlantao"
                , new
                {
                    idLoclaizacaoPlantao = idLoclaizacaoPlantao
                }
                , commandType: CommandType.Text, transaction: _session.Transaction).FirstOrDefault();

                return !String.IsNullOrEmpty(localizacaoPlantao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion



    }
}
