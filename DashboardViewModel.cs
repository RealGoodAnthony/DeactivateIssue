using System.Reactive;
using ReactiveUI;
using static DeactivateIssue.NavigatorService;

namespace DeactivateIssue;

public class DashboardViewModel : ReactiveObject
{
    public DashboardViewModel()
    {
        LogoutCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await Task.Delay(1000);
            return Unit.Default;
        });

        LogoutCommand.Subscribe(_ =>
        {
            Navigate("Login");
        });
    }
    
    public ReactiveCommand<Unit, Unit> LogoutCommand { get; set; }
}
