using App.Core.Service;

namespace App.Core.Model
{
    public class FileProvider<T> : IDataProvider<T> where T : HotDrink
    {
        private String _fileName;

        public FileProvider(String fileName)
        {
            _fileName = fileName;
        }

        public List<T> loadFeed()
        {
            
            List<T> list = new List<T>();
            var file = File.ReadLines(_fileName);
            String temp = string.Empty;

            foreach (var line in file)
            {
                var data = line.Split("#");
                list.Add(new HotDrink(data[0], int.Parse(data[1]), int.Parse(data[2])) as T);
            }

            return list;

        }

        public bool saveFeed(List<T> data)
        {
            try
            {
                var writer = File.AppendText(_fileName);

                foreach (var prod in data)
                {
                    writer.WriteLine($"{prod._name}#{prod._volume}#{prod._temp}\n");
                }

                writer.Flush();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
