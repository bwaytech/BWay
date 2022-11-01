using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BWay.Repository.Models
{
    public class ProjetoModel
    {
        [Key]
        public int Id { get; set; }

        [Column("nomeProjeto")]
        public string NomeProjeto { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        public ProjetoModel()
        {

        }

        public ProjetoModel(string nomeProjeto, string descricao)
        {
            NomeProjeto = nomeProjeto;
            Descricao = descricao;
        }
    }
}
