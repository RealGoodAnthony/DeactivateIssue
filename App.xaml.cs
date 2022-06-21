namespace DeactivateIssue;

public partial class App : Application
{
    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
        this.InitializeComponent();
        
        this.NavigateMain();
    }
    
    /// <summary>
    /// Navigate to the home screen, re-creating the navigation stack.
    /// </summary>
    private void NavigateMain()
    {
        var page = new MainPage();
        NavigationPage.SetHasNavigationBar(page, false);

        // Uncomment this line to not infinite loop anymore:
        //   this.MainPage?.SendDisappearing();

        this.MainPage = new NavigationPage(page);
    }

    public static void NavigateCurrentToMain()
    {
        var app = App.Current as App;
        app?.NavigateMain();
    }
}
