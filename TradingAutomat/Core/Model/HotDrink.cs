namespace App.Core.Model
{
    public class HotDrink : Drink
    {

        private int _temp;

        public int Temp { get => _temp; private set => _temp = value; }

        public HotDrink(string name, int volume, int temp) : base(name, volume)
        {
            _temp = temp;
        }

        public override string ToString()
        {
            return String.Format($"{base.ToString()}, Temperture: {Temp} C");
        }

        public override bool Equals(object? obj)
        {
            return obj is HotDrink drink &&
                   base.Equals(obj) &&
                   Temp == drink.Temp;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Temp);
        }
    }
}
