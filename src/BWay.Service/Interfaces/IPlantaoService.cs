using BWay.Infra.DTOs;
using BWay.Infra.Models;

namespace BWay.Service.Interfaces
{
    public interface IPlantaoService
    {
        #region LocalizacaoPlantao
        List<LocalizacaoPlantaoDTO> ListarLocalizacaoPlantao();
        LocalizacaoPlantaoDTO BuscarLocalizacaoPlantaoPorId(string idLocalizacaoPlantao);
        string CadastrarLocalizacaoPlantao(LocalizacaoPlantaoModel localizacaoPlantao);
        string AtualizarLocalizacaoPlantao(string idLocalizacaoPlantao, LocalizacaoPlantaoModel localizacaoPlantao);
        string ExcluirLocalizacaoPlantao(string idLocalizacaoPlantao);
        #endregion

        #region Plantao
        List<PlantaoDTO> ListarPlantao();
        PlantaoDTO BuscarPlantaoPorId(string idPlantao);
        string CadastrarPlantao(PlantaoModel plantao);
        string AtualizarPlantao(string idPlantao, PlantaoModel plantao);
        string ExcluirPlantao(string idPlantao);
        #endregion


    }
}
