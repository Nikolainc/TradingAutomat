using App.Core.Service;
using System.Xml.Linq;

namespace App.Core.Model
{
    public class RequestName<T> : IRequest<T> where T : Drink
    {

        private String _name;

        public RequestName() => _name = string.Empty;

        public List<T> Filter(List<T> request)
        {
            if (_name == string.Empty)
            {

                return request;

            }
            else
            {

                return request.Where(element => element._name.Equals(_name)).ToList();

            }
        }

        public void SetRequest(string value)
        {
            _name = value;
        }

        public override string ToString()
        {
            return String.Format("Запрос по имени: ");
        }
    }
}
