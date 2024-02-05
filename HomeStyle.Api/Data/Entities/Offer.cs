using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeStyler.Api.Data.Entities
{
    [Table(nameof(Offer))]
    public class Offer
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Image { get; set; }



        public Offer(int id, string image) : this()
        {
            Id = id;
            Image = image;

        }

        public Offer()
        {
        }


        public static IEnumerable<Offer> GetInitialData() =>
            new List<Offer>
            {
                new Offer(1,"salons.png"),
                new Offer(2, "deco.jpg"),
                new Offer(3, "salleamanger.jp"),
                new Offer(4, "chambre.jpg")
            };
    }
}
