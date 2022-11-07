using BWay.Repository.Interfaces;
using BWay.Service.Converters;
using BWay.Service.DTOs;
using BWay.Service.Interfaces;

namespace BWay.Service.Services
{
    public class AtendimentoService : IAtendimentoService
    {
        public readonly IAtendimentoRepository _atendimentoRepository;

        public AtendimentoService(IAtendimentoRepository atendimentoRepository)
        {
            _atendimentoRepository = atendimentoRepository;
        }

        public List<AtendimentoDTO> ObterAtendimentos()
        {
            List<AtendimentoDTO> atendimentos = new List<AtendimentoDTO>();

            var atendimentosModel = _atendimentoRepository.ObterAtendimentos();

            atendimentosModel.ForEach(atendimento => atendimentos.Add(AtendimentoConverter.AtendimentoModelToDTO(atendimento)));

            return atendimentos;
        }

        public AtendimentoDTO ObterAtendimento(int id)
        {
            var atendimento = _atendimentoRepository.ObterAtendimento(id);

            if (atendimento == null) return null;

            return AtendimentoConverter.AtendimentoModelToDTO(atendimento);
        }

        public AtendimentoDTO IniciarAtendimento(AtendimentoDTO atendimentoDTO)
        {
            var atendimento = _atendimentoRepository.ObterAtendimento(atendimentoDTO.Id);
            if (atendimento != null) return null;

            var atendimentoModel = AtendimentoConverter.AtendimentoDTOToModel(atendimentoDTO);
            atendimentoModel.Inicio = DateTime.Now;
            _atendimentoRepository.IniciarAtendimento(atendimentoModel);

            return AtendimentoConverter.AtendimentoModelToDTO(atendimentoModel);
        }

        public AtendimentoDTO EncerrarAtendimento(int id)
        {
            var atendimento = _atendimentoRepository.ObterAtendimento(id);
            if (atendimento == null || !atendimento.Termino.Equals(DateTime.MinValue)) return null;

            atendimento.Termino = DateTime.Now;
            var atendimentoModel = _atendimentoRepository.EncerrarAtendimento(atendimento);

            return AtendimentoConverter.AtendimentoModelToDTO(atendimentoModel);
        }
    }
}
