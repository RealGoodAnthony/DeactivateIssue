using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using DynamicData.Alias;
using ReactiveUI;
using ReactiveUI.Maui;

namespace DeactivateIssue;

public partial class DashboardPage : ReactiveContentPage<DashboardViewModel>
{
    public DashboardPage()
    {
        InitializeComponent();
        this.ViewModel = new DashboardViewModel();

        this.WhenActivated(disposables =>
        {
            NavigatorService.NavigationTarget
                .SelectMany(this.NavigateAsync)
                .Subscribe()
                .DisposeWith(disposables);
            
            this.BindCommand(
                    this.ViewModel,
                    viewModel => viewModel.LogoutCommand,
                    view => view.LogoutButton)
                .DisposeWith(disposables);
            
            Console.WriteLine("Dashboard appearing...");
            
            Disposable.Create(() =>
            {
                Console.WriteLine("Dashboard disappearing...");
            }).DisposeWith(disposables);
        });
    }

    private async Task<Unit> NavigateAsync(string navigationTarget)
    {
        if (navigationTarget != "Login")
        {
            return Unit.Default;
        }
        
        App.NavigateCurrentToMain();

        return Unit.Default;
    }
}
