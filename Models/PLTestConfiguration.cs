using System.Text.Json;
namespace PLTest.Models
{
    public static class PLTestConfiguration
    {
        public static string configuration_path="./Data/Configuration.json";
#pragma warning disable CS8618 
        private static PLTestConfigurationData _data;
#pragma warning restore CS8618 

        public static PLTestConfigurationData Data { get => _data; set => _data = value; }

        [Serializable]
        public class PLTestConfigurationData 
        {
            public string lang_db_path { get; set; } = "";
        } 
        public static void Init_Data()
        {
            using (var sw = new FileStream(configuration_path, FileMode.Open))
                _data = JsonSerializer.Deserialize<PLTestConfigurationData>(sw) ?? new PLTestConfigurationData();
        }
        public static void SaveConfig()
        {
            File.Delete(Data.lang_db_path);
            using (var sw = new FileStream(configuration_path,FileMode.Create))
                JsonSerializer.Serialize(sw,_data);
        }
    }
}
