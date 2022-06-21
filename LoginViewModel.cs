using System.Reactive;
using ReactiveUI;
using static DeactivateIssue.NavigatorService;

namespace DeactivateIssue;

public class LoginViewModel : ReactiveObject
{
    public LoginViewModel()
    {
        LoginCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await Task.Delay(1000);
            return Unit.Default;
        });

        LoginCommand.Subscribe(_ =>
        {
            Navigate("Dashboard");
        });
    }
    
    public ReactiveCommand<Unit, Unit> LoginCommand { get; set; }
}
