using System.Reactive;
using ReactiveUI;
using static DeactivateIssue.NavigatorService;

namespace DeactivateIssue;

public class MainViewModel : ReactiveObject
{
    public MainViewModel()
    {
        InitCommand = ReactiveCommand.Create(() =>
        {
            Navigate("Login");
            return Unit.Default;
        });
    }
    
    public ReactiveCommand<Unit, Unit> InitCommand { get; set; }
}
