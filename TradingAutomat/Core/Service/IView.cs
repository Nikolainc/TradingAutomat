namespace App.Core.Service
{
    public interface IView
    {
        public string Get();
        public void Set(string value);
    }
}
