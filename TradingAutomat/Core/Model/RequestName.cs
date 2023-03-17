using App.Core.Service;
using System.Xml.Linq;

namespace App.Core.Model
{
    public class RequestName<T> : IRequest<T> where T : Drink
    {

        private String _reqName;

        public RequestName() => _reqName = string.Empty;

        public List<T> Filter(List<T> request)
        {
            if (_reqName == string.Empty)
            {

                return request;

            }
            else
            {

                return request.Where(element => element.Name.Equals(_reqName)).ToList();

            }
        }

        public void SetRequest(string value)
        {
            _reqName = value;
        }

        public override string ToString()
        {
            return String.Format("Запрос по имени: ");
        }
    }
}
