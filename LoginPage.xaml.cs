using System;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using ReactiveUI;
using ReactiveUI.Maui;

namespace DeactivateIssue;

public partial class LoginPage : ReactiveContentPage<LoginViewModel>
{
    public LoginPage()
    {
        InitializeComponent();
        this.ViewModel = new LoginViewModel();

        this.WhenActivated((CompositeDisposable disposables) =>
        {
            NavigatorService.NavigationTarget
                .SelectMany(this.NavigateAsync)
                .Subscribe()
                .DisposeWith(disposables);

            this.BindCommand(
                    this.ViewModel,
                    viewModel => viewModel.LoginCommand,
                    view => view.LoginButton)
                .DisposeWith(disposables);
            
            Console.WriteLine("Login appearing...");
            
            Disposable.Create(() =>
            {
                Console.WriteLine("Login disappearing...");
            }).DisposeWith(disposables);
        });
    }

    private async Task<Unit> NavigateAsync(string navigationTarget)
    {
        if (navigationTarget != "Dashboard")
        {
            return Unit.Default;
        }
        
        var dashboardPage = new DashboardPage();
        await this.Navigation.PushAsync(dashboardPage);
        this.Navigation.RemovePage(this);
        
        return Unit.Default;
    }
}
