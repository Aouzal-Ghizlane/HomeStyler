namespace HomeStyler.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        public int Qunatity { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
