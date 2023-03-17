using App.Core.Service;
using System.Xml.Linq;

namespace App.Core.Model
{
    public class RequestVolume<T> : IRequest<T> where T : Drink
    {

        private int _reqVolume;

        public RequestVolume() => _reqVolume = -1;

        public List<T> Filter(List<T> request)
        {
            if (_reqVolume == -1)
            {

                return request;

            }
            else
            {

                return request.Where(element => element.Volume.Equals(_reqVolume)).ToList();

            }
        }

        public void SetRequest(string value)
        {
            if (!int.TryParse(value, out _reqVolume))
            {
                Console.WriteLine("Error input");
            }
        }

        public override string ToString()
        {
            return String.Format("Запрос по объему: ");
        }
    }
}
