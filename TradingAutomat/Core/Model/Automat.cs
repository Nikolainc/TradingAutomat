using App.Core.Service;

namespace App.Core.Model
{
    public class Automat<T> : IAutomat<T> where T : Drink
    {

        private List<T> _products;

        public Automat()
        {
            _products = new List<T>();
        }

        public List<T> Products { get => _products; private set => _products = value; }

        public bool AddProduct(T product)
        {
            if (_products.Contains(product))
            {
                return false;
            }
            else
            {
                _products.Add(product);
            }

            return true;
        }

        public bool AddProducts(List<T> productFeed)
        {
            foreach (var prod in productFeed)
            {
                if (!AddProduct(prod))
                {
                    continue;
                }
            }

            return true;
        }

        public List<T> GetProducts()
        {
            return _products;
        }

        List<T> IAutomat<T>.GetProducts(List<IRequest<T>> request)
        {
            List<T> requestList = new List<T>();
            requestList.AddRange(_products);

            foreach (var req in request)
            {
                requestList = req.Filter(requestList);
            }

            return requestList;
        }
    }
}
