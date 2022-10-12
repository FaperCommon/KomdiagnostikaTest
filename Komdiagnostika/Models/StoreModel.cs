using System;
using System.Collections.Generic;
using System.Text;

namespace Komdiagnostika.Models
{
    public class StoreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public string Img { get; set; }
        public string Desc { get; set; }
    }
}
