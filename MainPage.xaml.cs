using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using DynamicData.Alias;
using ReactiveUI;
using ReactiveUI.Maui;

namespace DeactivateIssue;

public partial class MainPage : ReactiveContentPage<MainViewModel>
{
    public MainPage()
    {
        InitializeComponent();
        this.ViewModel = new MainViewModel();

        this.WhenActivated(disposables =>
        {
            NavigatorService.NavigationTarget
                .SelectMany(this.NavigateAsync)
                .Subscribe()
                .DisposeWith(disposables);
            
            this.HandleAppearing();

            Disposable.Create(() =>
            {
                Console.WriteLine("Main disappearing...");
            }).DisposeWith(disposables);
        });
    }

    private async void HandleAppearing()
    {
        Console.WriteLine("Main appearing...");

        await ExecuteAndIgnoreResultAsync(this.ViewModel.InitCommand);
    }
    
    private static async Task ExecuteAndIgnoreResultAsync<TResult>(ReactiveCommand<Unit, TResult> reactiveCommand)
    {
        try
        {
            await reactiveCommand.Execute();
        }
        catch (Exception)
        {
            // ignored
        }
    }
    
    private async Task<Unit> NavigateAsync(string navigationTarget)
    {
        if (navigationTarget != "Login")
        {
            return Unit.Default;
        }
        
        var loginPage = new LoginPage();
        await this.Navigation.PushAsync(loginPage);
        this.Navigation.RemovePage(this);
        
        return Unit.Default;
    }
}
