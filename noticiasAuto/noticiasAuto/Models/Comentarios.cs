using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace noticiasAuto.Models
{
    public class Comentarios
    {
        [Key]
        public int IdComentario { get; set; }

        public string Conteudo { get; set; }

        [ForeignKey("Noticia")]
        public int NoticiaFK { get; set; }
        public virtual Noticias Noticia { get; set; }

        [ForeignKey("Utilizador")]
        public int UserFK { get; set; }
        public virtual utilizadores Utilizador { get; set; }



    }
}