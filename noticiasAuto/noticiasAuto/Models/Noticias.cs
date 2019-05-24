using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace noticiasAuto.Models
{
    public class Noticias
    {
        public Noticias()
        {
            ListaDeEquipas = new HashSet<Equipas>();
            ListaDeComentarios = new HashSet<Comentarios>();
        }

        [Key]
        public int IdNoticia { get; set; }

        public string Fotografia { get; set; }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        [ForeignKey("Utilizadores")]
        public int UserFK { get; set; }
        public virtual utilizadores Utilizadores { get; set; }

        public virtual ICollection<Equipas> ListaDeEquipas{ get; set; }

        public virtual ICollection<Comentarios> ListaDeComentarios { get; set; }


    }
}