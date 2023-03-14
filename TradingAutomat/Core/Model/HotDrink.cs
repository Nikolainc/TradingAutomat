namespace App.Core.Model
{
    public class HotDrink : Drink
    {

        public int _temp;

        public HotDrink(string name, int volume, int temp) : base(name, volume)
        {
            _temp = temp;
        }

        public override string ToString()
        {
            return String.Format($"{base.ToString()}, Temperture: {this._temp} C");
        }

        public override bool Equals(object? obj)
        {
            return obj is HotDrink drink &&
                   base.Equals(obj) &&
                   _temp == drink._temp;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), _temp);
        }
    }
}
