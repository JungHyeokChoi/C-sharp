using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace eBookManager.Engine
{
    public static class DeweyDecimal
    {
        private static string _jsonPath = Path.Combine(Application.StartupPath, "Classification.txt");
        public static Dictionary<string, string> Classification = new Dictionary<string, string>();

        public static void WriteToClassfication()
        {
            JsonSerializer json = new JsonSerializer();
            json.Formatting = Formatting.Indented;
            using (StreamWriter sw = new StreamWriter(_jsonPath, false))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    json.Serialize(writer, Classification);
                }
            }
        }

        public static Dictionary<string, string> ReadToClassfication()
        {
            JsonSerializer json = new JsonSerializer();
            if (!File.Exists(_jsonPath))
            {
                var newFile = File.Create(_jsonPath);
                newFile.Close();
            }

            using (StreamReader sr = new StreamReader(_jsonPath))
            {
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    var retVal = json.Deserialize<Dictionary<string, string>>(reader);
                    if (retVal is null)
                        retVal = new Dictionary<string, string>();

                    return retVal;
                }
            }
        }
    }
}
