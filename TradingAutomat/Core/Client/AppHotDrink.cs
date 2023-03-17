using App.Core.Model;
using App.Core.Presenter;
using App.Core.Service;
using App.Core.View;
using static System.Net.Mime.MediaTypeNames;

namespace App.Core.Client
{
    public class AppHotDrink
    {

        public static void ButtonClick()
        {
            IView view = new ConsoleView();
            List<IRequest<HotDrink>> req = new List<IRequest<HotDrink>>
            {
                new RequestName<HotDrink>(),
                new RequestVolume<HotDrink>(),
                new RequestTemp<HotDrink>()
            };
            IAutomat<HotDrink> automat = new Automat<HotDrink>();
            IDataProvider<HotDrink> provider = new FileProvider<HotDrink>("C:\\Users\\Nikolai\\source\\repos\\GB\\TradingAutomat\\TradingAutomat\\Data.txt");
            Presenter<HotDrink> presenter = new Presenter<HotDrink>(view, automat, provider, req);
            presenter.loadFeed();

            while (true)
            {
                Console.WriteLine(" 1 - Запрос  2 - Вывести все товары 3 - Выход");
                var key = Console.ReadLine();
                Console.Clear();
                switch (key)
                {
                    case "1":
                        presenter.getProduct();
                        break;
                    case "2":
                        presenter.getAllProduct();
                        break;
                    case "3":
                        Console.WriteLine("Приложение закрыто");
                        presenter.saveData();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Такой команды нет");
                        break;
                }
            }

        }

    }
}
