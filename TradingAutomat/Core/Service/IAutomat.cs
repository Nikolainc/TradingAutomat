using App.Core.Model;

namespace App.Core.Service
{
    public interface IAutomat<T> where T : Drink
    {
        public List<T> GetProducts();

        public List<T> GetProducts(List<IRequest<T>> request);

        public bool AddProducts(List<T> productFeed);

        public bool AddProduct(T product);

    }
}
