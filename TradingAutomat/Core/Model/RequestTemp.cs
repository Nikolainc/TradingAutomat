using App.Core.Service;
using System.Xml.Linq;

namespace App.Core.Model
{
    public class RequestTemp<T> : IRequest<T> where T : HotDrink
    {

        private int _temp;

        public RequestTemp() => _temp = -1;

        public List<T> Filter(List<T> request)
        {
            if (_temp == -1)
            {

                return request;

            }
            else
            {

                return request.Where(element => element._temp.Equals(_temp)).ToList();

            }
        }

        public void SetRequest(string value)
        {
            if (!int.TryParse(value, out _temp))
            {
                Console.WriteLine("Error input");
            }
        }

        public override string ToString()
        {
            return String.Format("Запрос по температуре: ");
        }
    }
}
