namespace App.Core.Model
{
    public abstract class Drink
    {
        private String _name;
        private int _volume;

        public String Name { get => _name; private set => _name = value; }
        public int Volume { get => _volume; private set => _volume = value; }

        protected Drink(String name, int volume)
        {
            _name = name;
            _volume = volume;
        }

        public override string ToString()
        {
            return String.Format($"Name: {Name}, Volume: {Volume} ml");
        }

        public override int GetHashCode()
        {
            return 13 * HashCode.Combine(Volume, Name);
        }
        public override bool Equals(object? obj)
        {
            return obj is Drink drink &&
                   Name == drink.Name &&
                   Volume == drink.Volume;
        }

    }
}
