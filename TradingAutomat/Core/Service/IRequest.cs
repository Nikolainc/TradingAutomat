using App.Core.Model;

namespace App.Core.Service
{
    public interface IRequest<T> where T : Drink
    {
        public List<T> Filter(List<T> request);

        public void SetRequest(String value);
    }
}
