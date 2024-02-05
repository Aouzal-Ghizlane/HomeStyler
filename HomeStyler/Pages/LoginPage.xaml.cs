
using Homestyler.Models;
using HomeStyler.Repository;

namespace HomeStyler.Pages;

public partial class LoginPage : ContentPage
{
    readonly IUserRepository userServer = new UserService();

    public LoginPage()
    {
        InitializeComponent();
        CheckStoredCredentials();
    }
    private async void CheckStoredCredentials()
    {
        // Vérifiez s'il existe des informations d'identification stockées
        string storedEmail = await SecureStorage.GetAsync("email");
        string storedPassword = await SecureStorage.GetAsync("password");

        if (!string.IsNullOrWhiteSpace(storedEmail) && !string.IsNullOrWhiteSpace(storedPassword))
        {
            // Appelez votre méthode de connexion avec ces informations d'identification
            // Assurez-vous de vérifier la validité des informations d'identification ici
            User user = await userServer.Login(storedEmail, storedPassword);

            if (user != null)
            {
                // Utilisateur connecté automatiquement, naviguez vers la page principale
                await Navigation.PushModalAsync(new MainPage());
            }
            else
            {
                // Les informations d'identification stockées ne sont plus valides, nettoyez le stockage
                SecureStorage.Remove("email");
                SecureStorage.Remove("password");
            }
        }
    }


    private async void MyButtonLogin_Clicked(object sender, EventArgs e)
    {
        try
        {
            string email = MyEntryUsername.Text;
            if (!email.Contains("@"))
            {
                await DisplayAlert("Error", "Invalid Email", "Ok");
                return;
            };

            string password = MyEntryPassword.Text;
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "All fields required", "Ok");
                return;
            }

            // Vérifiez si l'email est "admin@" et le mot de passe est "aze"
            if (email.ToLower() == "admin@gmail.com" && password == "123")
            {
                // Redirigez vers la page admin
                await Navigation.PushModalAsync(new Pages.AdminPage());
                await DisplayAlert("Login", "Welcome Admin!", "Ok");
                return;
            }

            User user = await userServer.Login(email, password);
            if (user == null)
            {
                await DisplayAlert("Error", "Credentials are incorrect", "Ok");
                return;
            }

            // Stockez les informations d'identification de l'utilisateur dans le stockage sécurisé
            await SecureStorage.SetAsync("email", email);
            await SecureStorage.SetAsync("password", password);

            //await Navigation.PushModalAsync(new MainPage());
            await Shell.Current.GoToAsync($"{nameof(MainPage)}");
            await DisplayAlert("Login", "Successfully logged in", "Ok");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Login", ex.Message, "Ok");
        }
    }
    private void TogglePasswordButton_Clicked(object sender, EventArgs e)
    {
        MyEntryPassword.IsPassword = !MyEntryPassword.IsPassword; // Toggle password visibility

        // Update the image source
        if (MyEntryPassword.IsPassword)
        {
            TogglePasswordButton.Source = "hide.png";

            // Change to the path of the show password image
        }
        else
        {
            TogglePasswordButton.Source = "view.png"; // Change to the path of the hide password image
        }
    }

    private async void SignUp_Clicked(object sender, EventArgs e)
    {
        // Naviguer vers la page d'inscription
        await Navigation.PushModalAsync(new SignUpPage());
    }
}