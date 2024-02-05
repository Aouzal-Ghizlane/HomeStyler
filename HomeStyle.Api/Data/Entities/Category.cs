using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeStyler.Api.Data.Entities
{
    [Table(nameof(Category))]
    public class Category
    {
        [Key]
        public short Id { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        [Required, MaxLength(150)]
        public string Image { get; set; }
        public Category(short id, string name, string image) : this()
        {
            Id = id;
            Name = name;
            Image = image;
           
        }
        public Category()
        {
        }
        public static IEnumerable<Category> GetInitialData() =>
            new List<Category>
            {
                new Category(1,"salons","home.jpg"),
                new Category(2, "Decor","cher.jpg"),
                new Category(3, "SalleaManger", "table.jpg"),
                new Category(4, "Chambre", "chambre.png")
            };


    }
}

