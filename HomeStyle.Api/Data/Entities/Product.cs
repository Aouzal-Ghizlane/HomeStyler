using HomeStyler.Shared.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace HomeStyler.Api.Data.Entities
{
    [Table(nameof(Product))]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }

        [Required, MaxLength(25)]
        public int Quantity { get; set; }

        public short CategoryId { get; set; }
        public Product(int id, string name, string description, string? image, double price, int quantity, short categoryId)
        {
            Id = id;
            Name = name;
            Image = image;
            Price = price;
            Quantity = quantity;
            CategoryId = categoryId;
            Description = description;
        }

        public static IEnumerable<Product> GetInitialData()
        {
            var products = new List<Product>();

            var Salon = new List<Product>
            {
                new(1, "Table","Cette Table Coffre EUGENIE Bleu Nuit est une merveille de l’ameublement. De couleur bleue, elle s’orne de motifs subtils qui rehaussent son design. Ce meuble peut également vous servir d’espace de rangement supplémentaire.","table.jpg",50.00, 50, 1)  };
            products.AddRange(Salon);
            return products;
        }



        public virtual Category Category { get; set; }
        internal static readonly Expression<Func<Product, ProductDto>> DtoSelector =
            p => new ProductDto(p.Id, p.Name, p.Image, p.Price, p.Quantity, p.CategoryId);



    }
}
