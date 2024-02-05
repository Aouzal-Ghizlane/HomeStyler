
/* Modification non fusionnée à partir du projet 'HomeStyler (net7.0-android)'
Avant :
using System;
Après :
using HomeStyler.Models;
using Microsoft.Maui.Controls;
using System;
*/

/* Modification non fusionnée à partir du projet 'HomeStyler (net7.0-windows10.0.19041.0)'
Avant :
using System;
Après :
using HomeStyler.Models;
using Microsoft.Maui.Controls;
using System;
*/

/* Modification non fusionnée à partir du projet 'HomeStyler (net7.0-maccatalyst)'
Avant :
using System;
Après :
using HomeStyler.Models;
using Microsoft.Maui.Controls;
using System;
*/
using HomeStyler.Models;
using System.Net.Http.Json;
/* Modification non fusionnée à partir du projet 'HomeStyler (net7.0-android)'
Avant :
using System.Threading.Tasks;
using HomeStyler.Models;
using Microsoft.Maui.Controls;
Après :
using System.Threading.Tasks;
*/

/* Modification non fusionnée à partir du projet 'HomeStyler (net7.0-windows10.0.19041.0)'
Avant :
using System.Threading.Tasks;
using HomeStyler.Models;
using Microsoft.Maui.Controls;
Après :
using System.Threading.Tasks;
*/

/* Modification non fusionnée à partir du projet 'HomeStyler (net7.0-maccatalyst)'
Avant :
using System.Threading.Tasks;
using HomeStyler.Models;
using Microsoft.Maui.Controls;
Après :
using System.Threading.Tasks;
*/


namespace HomeStyler.Repository
{
    public class ProductService : IProductRepository
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        //public string BaseAddress { get; set; } = "http://192.168.1.100/HomeStyler";
        public string BaseAddress { get; set; } = "http://localhost/HomeStyler";

        public List<ProductTem> Products { get; private set; } = new List<ProductTem>();

        public async Task<ServiceResponse> AddProductAsync(Product product)
        {
            var response = await httpClient.PostAsJsonAsync($"{BaseAddress}/api/Products", product);
            return await response.Content.ReadFromJsonAsync<ServiceResponse>();
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = await httpClient.GetAsync($"{BaseAddress}/api/Products/categories");
            return await categories.Content.ReadFromJsonAsync<List<Category>>();
        }

        public async Task<List<ProductTem>> LoadProductsAsync()
        {
            try
            {
                var products = await GetProductsAsync(); // Appeler GetProductsAsync au lieu de productService.GetProductsAsync
                if (products == null)
                    return new List<ProductTem>(); // Retourner une liste vide au lieu de null

                Products.Clear();

                foreach (var product in products)
                {
                    var img = Convert.FromBase64String(product.Image);
                    MemoryStream memoryStream = new(img);
                    string productDescription = product.Description.Count() > 40 ? product.Description.Substring(0, 40) + "..." : product.Description;

                    Products.Add(new ProductTem
                    {
                        Id = product.Id,
                        CategoryId = product.CategoryId,
                        //Image = product.Image, // Vous pouvez inclure cela si ProductTem a une propriété Image
                        Image = ImageSource.FromStream(() => memoryStream),
                        Name = product.Name,
                        Price = product.Price,
                        Quantity = product.Qunatity,
                        Description = productDescription
                    });
                }

                // Retourner la liste de produits
                return Products;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading products: {ex.Message}");
                return new List<ProductTem>(); // Retourner une liste vide en cas d'erreur
            }
        }

        public async Task<ServiceResponse> DeleteProductAsync(int productId)
        {
            var response = await httpClient.DeleteAsync($"{BaseAddress}/api/Products/{productId}");
            return await response.Content.ReadFromJsonAsync<ServiceResponse>();
        }

        private async Task<List<Product>> GetProductsAsync()
        {
            var productsResponse = await httpClient.GetAsync($"{BaseAddress}/api/Products");
            if (productsResponse.IsSuccessStatusCode)
            {
                return await productsResponse.Content.ReadFromJsonAsync<List<Product>>();
            }
            else
            {
                Console.WriteLine($"Error loading products: {productsResponse.StatusCode}");
                return null;
            }
        }

        /*  private string GetBase64StringFromStreamImageSource(ImageSource imageSource)
          {
              if (imageSource is StreamImageSource streamImageSource)
              {
                  // Use reflection to access the private Stream property
                  var streamField = streamImageSource.GetType().GetField("_stream", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                  var stream = streamField?.GetValue(streamImageSource) as Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<System.IO.Stream>>;

                  if (stream != null)
                  {
                      var token = System.Threading.CancellationToken.None;
                      var resultStream = stream.Invoke(token).Result;

                      using (var memoryStream = new MemoryStream())
                      {
                          resultStream.CopyTo(memoryStream);
                          return Convert.ToBase64String(memoryStream.ToArray());
                      }
                  }
              }

              return null; // or handle the case where it's not a StreamImageSource
          }*/


    }
}
