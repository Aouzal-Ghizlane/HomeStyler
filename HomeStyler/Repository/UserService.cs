using Homestyler.Models;
using Newtonsoft.Json;
using System.Text;



namespace HomeStyler.Repository
{
    public class UserService : IUserRepository
    {
        private readonly HttpClient _client;



        public async Task<User> Login(string email, string password)
        {
            var client = new HttpClient();
            //string url = "http://192.168.1.100/HomeStyler/User/" + email + "/" + password;
            string url = "http://localhost/HomeStyler/User/" + email + "/" + password;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                User user = JsonConvert.DeserializeObject<User>(content);
                return await Task.FromResult(user);
            }
            return null!;
        }

        public async Task<User> SignUp(string username, string email, string password)
        {
            var client = new HttpClient();
            //string url = "http://192.168.1.100/HomeStyler/User/";
            string url = "http://localhost/HomeStyler/User/"; // URL pour l'inscription
            client.BaseAddress = new Uri(url);

            // Créez un nouvel objet User pour l'inscription
            User newUser = new User
            {
                FullName = username,
                Email = email,
                Password = password
            };

            // Convertissez l'objet User en JSON
            string jsonUser = JsonConvert.SerializeObject(newUser);

            // Créez le contenu de la requête
            HttpContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

            // Envoyez la requête POST pour l'inscription
            HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);

            if (response.IsSuccessStatusCode)
            {
                // L'inscription a réussi, retournez l'utilisateur créé
                string responseContent = await response.Content.ReadAsStringAsync();
                User registeredUser = JsonConvert.DeserializeObject<User>(responseContent);
                return registeredUser;
            }

            // L'inscription a échoué, retournez null
            return null;
        }
    }
}
