using System.Reactive.Subjects;

namespace DeactivateIssue;

public static class NavigatorService
{
    private static Subject<string> navigationTarget = new();

    public static IObservable<string> NavigationTarget => navigationTarget;
    
    public static void Navigate(string newTarget)
    {
        Console.WriteLine("Navigating to: " + newTarget);
        navigationTarget.OnNext(newTarget);
    }
}
