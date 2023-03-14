namespace App.Core.Model
{
    public abstract class Drink
    {
        public String _name;
        public int _volume;

        public Drink(String name, int volume)
        {
            _name = name;
            _volume = volume;
        }

        public override string ToString()
        {
            return String.Format($"Name: {this._name}, Volume: {this._volume} ml");
        }

        public override int GetHashCode()
        {
            return 13 * HashCode.Combine(_volume,   _name);
        }
        public override bool Equals(object? obj)
        {
            return obj is Drink drink &&
                   _name == drink._name &&
                   _volume == drink._volume;
        }

    }
}
