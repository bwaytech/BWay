using BWay.Repository.Enums;

namespace BWay.Service.DTOs
{
    public class CorretorRoletaDto
    {
        public Guid IdRoleta { get; set; }
        public int IdCorretor { get; set; }
        public int IdOperacacao { get; set; }
        public StatusCorretorEnum StatusCorretor { get; set; }
        public int Ordem { get; set; }
        public bool UltimoAtendimento { get; set; }
        public int PosicaoAtual { get; set; }

        public CorretorRoletaDto()
        {

        }

        public CorretorRoletaDto(int idCorretor, int idOperacacao, int ordem)
        {
            IdCorretor = idCorretor;
            IdOperacacao = idOperacacao;
            StatusCorretor = StatusCorretorEnum.Disponivel;
            Ordem = ordem;
            UltimoAtendimento = false;
        }
    }
}
