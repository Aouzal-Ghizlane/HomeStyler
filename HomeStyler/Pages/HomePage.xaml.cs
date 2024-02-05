using HomeStyler.ViewModels;

namespace HomeStyler.Pages;

public partial class HomePage : ContentPage
{
    private readonly HomePageViewModel _viewModel;

    // Parameterless constructor
    public HomePage()
    {
        InitializeComponent();
        _viewModel = new HomePageViewModel();
        BindingContext = _viewModel;
    }

    // Constructor with ViewModel parameter
    public HomePage(HomePageViewModel viewModel) : this()
    {
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    // Rest of the class...
}
