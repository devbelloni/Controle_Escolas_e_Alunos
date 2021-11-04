using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controle_Escolas_e_Alunos.Models
{
    [Table("Alunos")]

    public class Alunos
    {
        public int AlunosId { get; set; }
        public int EscolasId { get; set; }
        public string Nome { get; set; }
        public string Escola { get; set; }
        public virtual Escolas Escolas { get; set; }

    }
}
