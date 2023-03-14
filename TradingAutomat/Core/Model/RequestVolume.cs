using App.Core.Service;
using System.Xml.Linq;

namespace App.Core.Model
{
    public class RequestVolume<T> : IRequest<T> where T : Drink
    {

        private int _volume;

        public RequestVolume() => _volume = -1;

        public List<T> Filter(List<T> request)
        {
            if (_volume == -1)
            {

                return request;

            }
            else
            {

                return request.Where(element => element._volume.Equals(_volume)).ToList();

            }
        }

        public void SetRequest(string value)
        {
            if (!int.TryParse(value, out _volume))
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
