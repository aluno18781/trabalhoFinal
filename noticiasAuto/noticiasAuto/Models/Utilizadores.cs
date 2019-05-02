using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace noticiasAuto.Models
{
    public class Utilizadores
    {
        public Utilizadores()
        {
            ListaDeComentarios = new HashSet<Comentarios>();
        }

        [Key]
        public int IdUser { get; set; }

        public string None { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Comentarios> ListaDeComentarios { get; set; }
        

    }
}