using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel.DataAnnotations;

namespace HomeLib.Models
{
    public class Ksiazka
    {
        public int Id { get; set; }
        public string Tytul { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int RokWydania { get; set; }
    }
}
