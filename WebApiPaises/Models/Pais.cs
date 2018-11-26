using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPaises.Models
{
    public class Pais
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Nombre { get; set; }

        public List<Provincia> Provincias { get; set; }

        public Pais()
        {
            Provincias = new List<Provincia>();
        }

    }
}
