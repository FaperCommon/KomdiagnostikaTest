using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public string Img { get; set; }
        public string Desc { get; set; }
    }
}
