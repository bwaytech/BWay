using BWay.Repository.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BWay.Repository.Models
{
    public class CorretorRoletaModel
    {
        [Column("id")]
        public Guid IdRoleta { get; set; }

        [Column("idCorretor")]
        public int IdCorretor { get; set; }

        [Column("idOperacao")]
        public int IdOperacacao { get; set; }

        [Column("statusCorretor")]
        public StatusCorretorEnum StatusCorretor { get; set; }

        [Column("ordem")]
        public int Ordem { get; set; }

        [Column("ultimoAtendimento")]
        public bool UltimoAtendimento { get; set; }

        [Column("posicaoAtual")]
        public int PosicaoAtual { get; set; }
    }
}
