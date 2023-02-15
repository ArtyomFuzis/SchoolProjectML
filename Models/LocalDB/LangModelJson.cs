using PLTest.Models.Interfaces;
using PLTest.Models.Objects;
using System.Text.Json;
using static PLTest.Models.PLTestConfiguration;

namespace PLTest.Models.LocalDB
{
    public class LangModelJson : ILangModel
    {
        static Dictionary<string, Lang>? _database = null;
        [Serializable]
        private struct SerItem
        {
            public string id { get; set; }
            public Lang value { get; set; }
            public SerItem(string key,Lang val) 
            {
                id= key;
                value = val;
            }
        }
        public LangModelJson() 
        {
            if (_database != null) return;
            _database = new Dictionary<string, Lang>();
            try
            {
                SerItem[] PreSerArr;
                using (var fs = new FileStream(Data.lang_db_path, FileMode.OpenOrCreate))
                    PreSerArr = JsonSerializer.Deserialize<SerItem[]>(fs) ?? new SerItem[0];
                foreach (var item in PreSerArr)
                {
                    _database.Add(item.id, item.value);
                }
            }
            catch (JsonException)
            {
                _database = new Dictionary<string, Lang>();
            }
        }

        public Lang get_lang(string id)
        {
            Lang value;
            if (_database == null) throw new Exception("Что-то пошло явно не так...");
            if (_database.TryGetValue(id, out value))
                return value;
            return new Lang("No language", "...", new Uri("https://www.youtube.com/watch?v=dQw4w9WgXcQ"), new Uri("https://www.youtube.com/watch?v=dQw4w9WgXcQ"),"");
        }
        
        public void SaveModel() 
        {
            if (_database == null) throw new Exception("Что-то пошло явно не так...");
            SerItem[] PostSerArr = new SerItem[_database.Keys.Count];
            int i = 0;
            foreach (var el in _database.Keys)
            {
                PostSerArr[i++] = new SerItem(el, _database[el]);
            }
            File.Delete(Data.lang_db_path);
            using (var sw = new FileStream(Data.lang_db_path, FileMode.Create))
                JsonSerializer.Serialize(sw, PostSerArr);
        }
    }
}
