using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Escolas_e_Alunos.Models
{
    [Table("Escolas")]
    public class Escolas
    {
        public int EscolasId { get; set; }
        public int Registro { get; set; }
        public string Escola { get; set; }
        public List<Alunos> Alunos { get; set; }

    }
}
