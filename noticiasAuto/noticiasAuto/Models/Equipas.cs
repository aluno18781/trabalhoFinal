using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace noticiasAuto.Models
{
    public class Equipas
    {
        public Equipas()
        {
            ListaDePilotos = new HashSet<Pilotos>();
            ListaDeNoticias = new HashSet<Noticias>();
        }

        [Key]
        public int IdEquipa { get; set; }

        public string Nome { get; set; }

        public DateTime DataFundacao { get; set; }

        public string Logo { get; set; }

        public string Fundador { get; set; }

        public string Nacionalidade { get; set; }

        public virtual ICollection<Pilotos> ListaDePilotos { get; set; }

        public virtual ICollection<Noticias> ListaDeNoticias{ get; set; }

    }
}