using Homestyler.Models;
using HomeStyler.Repository;

namespace HomeStyler.Pages;

public partial class SignUpPage : ContentPage
{
    private readonly IUserRepository _userRepository;
    public SignUpPage()
    {
        InitializeComponent();
        _userRepository = new UserService();
    }
    private async void MyButtonSignIn_Clicked(object sender, EventArgs e)
    {
        string username = MyEntryFullname.Text;
        string email = EmailEntry.Text;
        string password = MyEntryPassword.Text;

        // Vérifiez que les champs ne sont pas vides
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }

        // Appelez votre méthode SignUp du UserRepository
        User newUser = await _userRepository.SignUp(username, email, password);

        if (newUser != null)
        {
            // L'inscription a réussi, faites quelque chose comme naviguer vers une autre page
            await DisplayAlert("Success", "Registration successful!", "OK");
            // Vous pouvez ajouter ici le code pour naviguer vers une autre page
        }
        else
        {
            // L'inscription a échoué, affichez un message d'erreur
            await DisplayAlert("Error", "Registration failed. Please try again.", "OK");
        }
    }


    private async void SignIn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new LoginPage());
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
}