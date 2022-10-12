namespace BLL.DTOs
{
    public class StoreDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public string Img { get; set; }
        public string Desc { get; set; }
    }
}