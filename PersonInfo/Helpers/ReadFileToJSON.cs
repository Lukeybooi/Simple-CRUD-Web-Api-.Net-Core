using System.IO;
using System.Text.Json;

namespace PersonInfo.Helpers
{
    public static class ReadFileToJSON
    {
        public static string[] ReadFile(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files", fileName);
            string file = File.ReadAllText(path);

            string[] list = JsonSerializer.Deserialize<string[]>(file);

            return list;
        }
    }
}
