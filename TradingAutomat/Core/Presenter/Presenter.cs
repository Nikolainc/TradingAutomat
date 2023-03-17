using App.Core.Model;
using App.Core.Service;

namespace App.Core.Presenter
{
    public class Presenter<T> where T : Drink
    {
        private IView _view;
        private IAutomat<T> _automat;
        private List<IRequest<T>> _requests;
        private IDataProvider<T> _provider;

        public Presenter(IView view, IAutomat<T> automat, IDataProvider<T> provider, List<IRequest<T>> requests)
        {

                _view = view;
                _automat = automat;
                _provider = provider;
                _requests = requests;

        }

        public void loadFeed()
        {

            _automat.AddProducts(this._provider.loadFeed());

        }

        public void saveData()
        {

            _provider.saveFeed(_automat.GetProducts());

        }

        public void getProduct()
        {

            foreach (var req in _requests)
            {
                Console.WriteLine(req);
                req.SetRequest(_view.Get());
            }

            var products = _automat.GetProducts(_requests);
            Console.Clear();

            foreach (var prod in products)
            {
                _view.Set(prod.ToString());
            }

        }

        public void getAllProduct()
        {

            var products = _automat.GetProducts();

            foreach (var prod in products)
            {
                _view.Set(prod.ToString());
            }

        }

    }
}
