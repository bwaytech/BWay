using AutoMapper;
using BWay.Infra.Exceptions;
using BWay.Infra.Interfaces;
using BWay.Repository.Enums;
using BWay.Repository.Interfaces;
using BWay.Repository.Models;
using BWay.Service.DTOs;
using BWay.Service.Interfaces;
using System.Net;

namespace BWay.Service.Services
{
    public class RoletaService: IRoletaService
    {
        private readonly IRoletaRepository _roletaRepository;
        private readonly IMapper _mapper;
        private readonly IUtil _util;
        
        public RoletaService(IRoletaRepository roletaRepository, IMapper mapper, IUtil util)
        {
            _roletaRepository = roletaRepository;
            _mapper = mapper;
            _util = util;
        }

        public LinkedList<CorretorRoletaDto> MontarRoleta(OperacaoCorretorDTO operacaoCorretorDto, List<CorretorDTO> corretoresElegiveisSorteio, List<CorretorDTO> corretoresSomenteAtendimento)
        {
            var roletaExistente = _roletaRepository.ObterRoletaPorOperacao(operacaoCorretorDto.IdOperacao);
            if(roletaExistente.Any()) throw new HttpImobException(HttpStatusCode.BadRequest, "Já existe uma roleta criada para esta operação.");

            // Chamar o mapping para converter de DTO para Model
            List<CorretorRoletaDto> roleta = GirarRoleta(corretoresElegiveisSorteio);

            // Chamar o mapping para converter de DTO para Model
            AdicionarCorretoresAtendimento(roleta, corretoresSomenteAtendimento);

            var roletaCriada = _roletaRepository.SalvarRoleta(_mapper.Map<List<CorretorRoletaModel>>(roleta));

            return _mapper.Map<LinkedList<CorretorRoletaDto>>(roletaCriada);
        }

        public LinkedList<CorretorRoletaDto> ObterRoleta(Guid id)
        {
            var roletaModel = _roletaRepository.ObterRoleta(id);

            if(!roletaModel.Any()) throw new HttpImobException(HttpStatusCode.NotFound, "Não existe nenhuma roleta para o id informado.");

            return _mapper.Map<LinkedList<CorretorRoletaDto>>(roletaModel);
        }

        public CorretorRoletaDto ObterCorretorSeEstiverDisponivel(Guid idRoleta, int idCorretor)
        {
            var corretor = _roletaRepository.ObterCorretorSeEstiverDisponivel(idRoleta, idCorretor);

            if(corretor == null) throw new HttpImobException(HttpStatusCode.NotFound, "O corretor não está disponível.");

            return _mapper.Map<CorretorRoletaDto>(corretor);
        }

        public CorretorRoletaDto ObterCorretorEmAtendimento(Guid idRoleta, int idCorretor)
        {
            var corretor = _roletaRepository.ObterCorretorEmAtendimento(idRoleta, idCorretor);

            if(corretor == null) throw new HttpImobException(HttpStatusCode.NotFound, "O corretor não está em atendimento.");

            return _mapper.Map<CorretorRoletaDto>(corretor);
        }

        public CorretorRoletaDto ObterCorretorEmPausa(Guid idRoleta, int idCorretor)
        {
            var corretor = _roletaRepository.ObterCorretorEmPausa(idRoleta, idCorretor);

            if(corretor == null) throw new HttpImobException(HttpStatusCode.NotFound, "O corretor não está em pausa.");

            return _mapper.Map<CorretorRoletaDto>(corretor);
        }

        public List<CorretorRoletaDto> Mover(Guid idRoleta)
        {
            LinkedList<CorretorRoletaDto> roleta = ObterRoleta(idRoleta);

            roleta = AlterarUltimoAtendimento(roleta);

            var roletaDto = AtualizarPosicoes(roleta.ToList());
            var roletaModel = _mapper.Map<List<CorretorRoletaModel>>(roletaDto);
            _roletaRepository.AtualizarRoleta(roletaModel);

            return roletaDto;
        }

        public void AtualizarRoleta(List<CorretorRoletaDto> roleta)
        {
            _roletaRepository.AtualizarRoleta(_mapper.Map<List<CorretorRoletaModel>>(roleta));
        }

        public void AtualizarRoleta(CorretorRoletaDto corretor)
        {
            _roletaRepository.AtualizarRoleta(_mapper.Map<CorretorRoletaModel>(corretor));
        }

        private List<CorretorRoletaDto> GirarRoleta(List<CorretorDTO> corretores)
        {
            List<CorretorRoletaDto> roleta = _mapper.Map<List<CorretorRoletaDto>>(corretores);
            var ordemSorteio = 1;

            roleta = _util.Embaralhar(roleta);

            roleta.ForEach(corretor => 
            {
                corretor.StatusCorretor = StatusCorretorEnum.Disponivel;
                corretor.Ordem = ordemSorteio++;
            });

            roleta = AtualizarPosicoes(roleta);

            return roleta;
        }

        private List<CorretorRoletaDto> AdicionarCorretoresAtendimento(List<CorretorRoletaDto> roleta, List<CorretorDTO> corretoresSomenteAtendimento)
        {
            CorretorRoletaDto corretorRoleta;
            var ordem = roleta.Count + 1;

            foreach (var corretorAtendimento in corretoresSomenteAtendimento)
            {
                corretorRoleta = new CorretorRoletaDto(corretorAtendimento.IdCorretor, corretorAtendimento.IdOperacao, ordem++); 
                roleta.Add(corretorRoleta);              
            }

            return roleta;
        }

        private List<CorretorRoletaDto> AtualizarPosicoes(List<CorretorRoletaDto> roleta){
            int posicao = 1;
            roleta.ForEach(corretor => corretor.PosicaoAtual = posicao++);
            
            return roleta;
        }
        
        private LinkedList<CorretorRoletaDto> AlterarUltimoAtendimento(LinkedList<CorretorRoletaDto> roleta){
            if(roleta.FirstOrDefault(corretor => corretor.StatusCorretor.Equals(StatusCorretorEnum.Disponivel)) == null)
            {
                throw new HttpImobException(HttpStatusCode.NotFound, "Nenhum corretor está disponível para atendimento.");
            }

            var atualPrimeiroDaFila = roleta.Last();
            atualPrimeiroDaFila.UltimoAtendimento = false;

            while(roleta.First().StatusCorretor.Equals(StatusCorretorEnum.Disponivel).Equals(false)){
                roleta.AddLast(roleta.First());
                roleta.RemoveFirst();
            }

            var novoPrimeiroDaFila = roleta.First();
            novoPrimeiroDaFila.StatusCorretor = StatusCorretorEnum.EmAtendimento;
            novoPrimeiroDaFila.UltimoAtendimento = true;
            roleta.AddLast(novoPrimeiroDaFila);
            roleta.RemoveFirst();

            return roleta;
        }
    }
}
