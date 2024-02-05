using CommunityToolkit.Mvvm.ComponentModel;

namespace HomeStyler.Shared.Dtos
{
    public partial class ProductDto : ObservableObject
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        [ObservableProperty]
        private string? image;

        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }

        [ObservableProperty]
        private int _cartQuantity;

        public ProductDto(int id, string name, string image, double price, int quantity, short categoryId)
        {
            Id = id;
            Name = name;
            this.image = image;
            Quantity = quantity;
            CategoryId = categoryId;
        }
    }
}
