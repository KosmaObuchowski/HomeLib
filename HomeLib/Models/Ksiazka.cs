using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HomeLib.Models
{
    public class Ksiazka
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Tytul { get; set; }
        public string Autor { get; set; }
        public int RokWydania { get; set; }
    }
}
