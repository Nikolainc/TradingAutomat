using App.Core.Model;

namespace App.Core.Service
{
    public interface IDataProvider<T> where T : Drink
    {
        public List<T> loadFeed();

        public bool saveFeed(List<T> data);
    }
}
