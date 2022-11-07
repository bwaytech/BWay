using BWay.Repository.Interfaces;
using BWay.Service.Converters;
using BWay.Service.DTOs;
using BWay.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWay.Service.Services
{
    public class OperacaoCorretorService : IOperacaoCorretorService
    {
        private readonly IOperacaoCorretorRepository _operacaoCorretorRepository;
        private readonly IOperacaoService _operacaoService;

        public OperacaoCorretorService(IOperacaoCorretorRepository operacaoCorretorRepository, IOperacaoService operacaoService)
        {
            _operacaoCorretorRepository = operacaoCorretorRepository;
            _operacaoService = operacaoService;
        }

        public OperacaoCorretorDTO CheckIn(OperacaoCorretorDTO operacaoCorretorDTO)
        {
            var operacaoCorretorModel = OperacaoCorretorConverter.OperacaoCorretorDTOToModel(operacaoCorretorDTO);

            operacaoCorretorModel.CheckIn = DateTime.Now;
            operacaoCorretorModel.ElegivelAtendimento = false;
            operacaoCorretorModel.ElegivelSorteio = false;

            var operacaoCorretorExistente = _operacaoCorretorRepository.ObterOperacaoCorretor(operacaoCorretorModel.IdCorretor, operacaoCorretorModel.IdOperacao, operacaoCorretorModel.CheckIn);

            if (operacaoCorretorExistente != null) return null;

            var operacao = _operacaoService.ObterOperacaoAberta(operacaoCorretorDTO.IdOperacao);

            if (operacao == null) return null;

            if (FezCheckingAntesDoHorarioPosBarra(operacaoCorretorModel.CheckIn, operacao.HorarioPosBarra))
            {
                operacaoCorretorModel.ElegivelAtendimento = true;

                if (FezCheckinAntesDoHorarioBarra(operacaoCorretorModel.CheckIn, operacao.HorarioBarra))
                {
                    operacaoCorretorModel.ElegivelSorteio = true;
                }
            }

            _operacaoCorretorRepository.CheckIn(operacaoCorretorModel);

            return OperacaoCorretorConverter.OperacaoCorretorModelToDTO(operacaoCorretorModel);
        }

        private bool FezCheckinAntesDoHorarioBarra(DateTime horarioCheckIn, string horarioBarra)
        {
            TimeSpan horaBarraConvertida = new TimeSpan(Convert.ToInt32(horarioBarra.Split(':')[0]), Convert.ToInt32(horarioBarra.Split(':')[1]), 0);
            TimeSpan horaCheckInConvertida = new TimeSpan(horarioCheckIn.Hour, horarioCheckIn.Minute, horarioCheckIn.Second);

            int comparacao = TimeSpan.Compare(horaCheckInConvertida, horaBarraConvertida);

            return comparacao != 1;
        }

        private bool FezCheckingAntesDoHorarioPosBarra(DateTime horarioCheckIn, string horarioPosBarra)
        {
            TimeSpan horaPosBarraConvertida = new TimeSpan(Convert.ToInt32(horarioPosBarra.Split(':')[0]), Convert.ToInt32(horarioPosBarra.Split(':')[1]), 0);
            TimeSpan horaCheckInConvertida = new TimeSpan(horarioCheckIn.Hour, horarioCheckIn.Minute, horarioCheckIn.Second);

            int comparacao = TimeSpan.Compare(horaCheckInConvertida, horaPosBarraConvertida);

            return comparacao != 1;
        }

        public OperacaoCorretorDTO CheckOut(int id)
        {
            var operacaoCorretorModel = _operacaoCorretorRepository.CheckOut(id);

            return OperacaoCorretorConverter.OperacaoCorretorModelToDTO(operacaoCorretorModel);
        }

        public List<OperacaoCorretorDTO> ObterOperacaoCorretores()
        {
            var listaOperacaoCorretores = _operacaoCorretorRepository.ObterOperacaoCorretores();
            List<OperacaoCorretorDTO> listaDTO = new List<OperacaoCorretorDTO>();

            listaOperacaoCorretores.ForEach(operacaoCorretor => listaDTO.Add(OperacaoCorretorConverter.OperacaoCorretorModelToDTO(operacaoCorretor)));

            return listaDTO;
        }

        public OperacaoCorretorDTO ObterOperacaoCorretor(int id)
        {
            var operacaoCorretor = _operacaoCorretorRepository.ObterOperacaoCorretor(id);

            if (operacaoCorretor == null) return null;

            return OperacaoCorretorConverter.OperacaoCorretorModelToDTO(operacaoCorretor);
        }

        public List<CorretorDTO> ObterCorretoresElegiveisSorteio(int idOperacao)
        {
            var elegiveis = _operacaoCorretorRepository.ObterCorretoresElegiveisSorteio(idOperacao);

            List<CorretorDTO> corretores = new List<CorretorDTO>();

            elegiveis.ForEach(corretor => corretores.Add(new CorretorDTO(corretor.IdOperacao, corretor.IdCorretor)));

            return corretores;
        }

        public List<CorretorDTO> ObterCorretoresElegiveisAtendimento(int idOperacao)
        {
            var elegiveis = _operacaoCorretorRepository.ObterCorretoresElegiveisAtendimento(idOperacao);

            List<CorretorDTO> corretores = new List<CorretorDTO>();

            elegiveis.ForEach(corretor => corretores.Add(new CorretorDTO(corretor.IdOperacao, corretor.IdCorretor)));

            return corretores;
        }
    }
}
