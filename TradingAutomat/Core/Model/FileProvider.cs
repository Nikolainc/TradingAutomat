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

            foreach (var line in file.Select((value, i) => (value, i)))
            {
                
                try
                {
                    var data = line.value.Split("#");
                    list.Add(new HotDrink(data[0], int.Parse(data[1]), int.Parse(data[2])) as T);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Error read data in line: {line.i + 1}\n{line.value}\n");
                    continue;
                }
                
            }
            
            return list;

        }

        public bool saveFeed(List<T> data)
        {
            try
            {
                var writer = File.CreateText(_fileName);

                foreach (var prod in data)
                {
                    writer.WriteLine($"{prod.Name}#{prod.Volume}#{prod.Temp}");
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
