using App.Core.Service;

namespace App.Core.View
{
    public class ConsoleView : IView
    {
        public string Get() => Console.ReadLine();

        public void Set(string value) => Console.WriteLine(value);

    }
}
