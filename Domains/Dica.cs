using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Edux.Domains
{
    public partial class Dica
    {
        public Dica()
        {
            Curtida = new HashSet<Curtida>();
        }

        public int IdDica { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        public int IdUsuario { get; set; }

        //Usada para receber o arquivo
        [NotMapped]
        [JsonIgnore]
        public IFormFile Img { get; set; }


        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Curtida> Curtida { get; set; }
    }
}
