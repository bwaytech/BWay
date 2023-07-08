using BWay.Infra.DTOs;
using BWay.Infra.Models;
using BWay.Repository.Interfaces;
using BWay.Service.Interfaces;

namespace BWay.Service.Services
{
    public class PlantaoService : IPlantaoService
    {
        private readonly IPlantaoRepository _plantaoRepository;

        public PlantaoService(IPlantaoRepository plantaoRepository)
        {
            _plantaoRepository = plantaoRepository;
        }


        #region LocalizacaoPlantao
        public List<LocalizacaoPlantaoDTO> ListarLocalizacaoPlantao()
        {
            try
            {
                return _plantaoRepository.ListarLocalizacaoPlantao();
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
                return _plantaoRepository.BuscarLocalizacaoPlantaoPorId(idLocalizacaoPlantao);
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
                return _plantaoRepository.CadastrarLocalizacaoPlantao(localizacaoPlantao);
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
                return _plantaoRepository.AtualizarLocalizacaoPlantao(idLocalizacaoPlantao, localizacaoPlantao);
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
                return _plantaoRepository.ExcluirLocalizacaoPlantao(idLocalizacaoPlantao);
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
                return _plantaoRepository.ListarPlantao();
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
                return _plantaoRepository.BuscarPlantaoPorId(idPlantao);
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
                return _plantaoRepository.CadastrarPlantao(plantao);
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
                return _plantaoRepository.AtualizarPlantao(idPlantao, plantao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ExcluirPlantao(string idplantao)
        {
            try
            {
                return _plantaoRepository.ExcluirPlantao(idplantao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
