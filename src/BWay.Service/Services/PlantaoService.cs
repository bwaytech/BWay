using BWay.Infra.Exceptions;
using BWay.Repository.Interfaces;
using BWay.Service.Converters;
using BWay.Service.DTOs;
using BWay.Service.Interfaces;
using System.Net;

namespace BWay.Service.Services
{
    public class PlantaoService : IPlantaoService
    {
        private readonly IPlantaoRepository _plantaoRepository;

        public PlantaoService(IPlantaoRepository plantaoRepository)
        {
            _plantaoRepository = plantaoRepository;
        }

        public PlantaoDTO ObterPlantao(int id)
        {
            var plantao = PlantaoConverter.PlantaoModelToDTO(_plantaoRepository.ObterPlantao(id));

            if (plantao == null) throw new HttpImobException(HttpStatusCode.NotFound, "Plantão não encontrado.");

            return plantao;
        }

        public List<PlantaoDTO> ObterTodos()
        {
            var plantoes = _plantaoRepository.ObterTodos();

            List<PlantaoDTO> plantoesDTO = new List<PlantaoDTO>();

            plantoes.ForEach(plantao => plantoesDTO.Add(PlantaoConverter.PlantaoModelToDTO(plantao)));

            return plantoesDTO;
        }

        public PlantaoDTO Inserir(PlantaoDTO plantao)
        {
            var plantaoCriado = _plantaoRepository.Inserir(PlantaoConverter.PlantaoDTOToModel(plantao));
            return PlantaoConverter.PlantaoModelToDTO(plantaoCriado);
        }

        public void Deletar(int id)
        {
            var plantao = ObterPlantao(id);
            _plantaoRepository.Deletar(PlantaoConverter.PlantaoDTOToModel(plantao));
        }
    }
}
