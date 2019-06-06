using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace noticiasAuto.Models
{
    public class Pilotos
    {
        [Key]
        public int IdPiloto { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Nacionalidade { get; set; }

        public string Categoria { get; set; }

        public string Fotografia { get; set; }

        [ForeignKey("Equipa")]
        public int EquipaFK { get; set; }
        public virtual Equipas Equipa { get; set; }


    }
}