using App.Core.Service;
using System.Xml.Linq;

namespace App.Core.Model
{
    public class RequestTemp<T> : IRequest<T> where T : HotDrink
    {

        private int _reqTemp;

        public RequestTemp() => _reqTemp = -1;

        public List<T> Filter(List<T> request)
        {
            if (_reqTemp == -1)
            {

                return request;

            }
            else
            {

                return request.Where(element => element.Temp.Equals(_reqTemp)).ToList();

            }
        }

        public void SetRequest(string value)
        {
            if (!int.TryParse(value, out _reqTemp))
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
