using PLTest.Controllers;
using PLTest.Models.ML;
using PLTest.Models.Objects;
namespace PLTest.Models
{
    struct QuestionData 
    {
        public string Question;
        public string[] Answers;
    }
    public class QuestionTempModel
    {
        public class CmpL : IComparer<Lang>
        {
            public static Dictionary<string, float>? ML_res;
            public int Compare(Lang x, Lang y)
            {
                if (ML_res is null) throw new Exception("Крайне неожиданная ошибка!!!");
                return ML_res[langIdDict[x.Title]] < ML_res[langIdDict[y.Title]] ? 1 : -1;
                //return (distance_x - distance_y)<0?-1:1;
            }
        }
        Lang[] languages;
        public static Dictionary<string, string> langIdDict = new Dictionary<string, string> 
        { 
            {"C#", "cs"},
            {"C++", "cpp"},
            {"VisualBasic", "vb"},
            {"Python", "python"},
            {"JavaScript", "js"},
            {"TypeScript", "ts"},
            {"Java", "java"},
            {"Kotlin", "kotlin"},
            {"PHP", "php"},
            {"C", "c"},
            {"Go", "go"},
            {"Ruby", "ruby"},
            {"Assembler", "asm"},
            {"Swift", "swift"}
        };
        public QuestionTempModel() 
        {
            languages = new Lang[]
            {
                LangController.__model.get_lang("cs"),
                LangController.__model.get_lang("cpp"),
                LangController.__model.get_lang("vb"),
                LangController.__model.get_lang("python"),
                LangController.__model.get_lang("js"),
                LangController.__model.get_lang("ruby"),
                LangController.__model.get_lang("asm"),
                LangController.__model.get_lang("ts"),
                LangController.__model.get_lang("c"),
                LangController.__model.get_lang("go"),
                LangController.__model.get_lang("swift"),
                LangController.__model.get_lang("php"),
                LangController.__model.get_lang("kotlin"),
                LangController.__model.get_lang("java")
            };
        }
        QuestionData[] arr = new QuestionData[]
        {
            new QuestionData
            {
                Question="Что, по вашему мнению, самое главное в работе языка программирования?",
                Answers=new string[]{"Скорость","Эффективность","Многофункциональность", "Мультиплатформенность"}
            },
            new QuestionData
            {
                Question="Готовы ли вы потратить большое количество времени на изучение сложного языка программирования и поиск документации по нему?",
                Answers=new string[]{"Да","Я предпочту изучить популярный язык с большим количеством документации","Определенно, нет","Я хочу потратить время на обучение языкам программирования более эфективно" }
            },
            new QuestionData
            {
                Question="Что вы выберете: многофункциональный язык программирования или который может выполнить одну, крайне интересную для меня, задачу(например создание скриптов на сайте)?",
                Answers=new string[]{ "Многофункциональность, мне хочется стать профессионалом в одном универсальном языке программирования", "Это не важно","Что-то среднее","Я хочу быть специалистом в определённой сфере" }
            },
            new QuestionData
            {
                Question="Насколько вам важен размер сообщества и количество документации для языка программирования?",
                Answers=new string[]{"Большой размер сообщество - очень удобно","Мне это не важно","Я готов потрудиться и поискать информацию","Размер сообщества играет ключевую роль" }
            },
            new QuestionData
            {
                Question="Какое направление в программировании вас превлекает больше всего?",
                Answers=new string[]{ "Сервера и Сайты(Web)", "Мобильные приложения","Игры","Приложения для Windows","Приложения для продукции Apple","Настройка офисных программ(Microsoft Office,1C)","Работа напрямую с \"железом компьютера\"","Абсолютно всё!" }
            }
        };
        public string get_question(int id) 
        {
            try
            {
                return arr[id].Question;
            }
            catch
            {
                return "No_INFO!";
            }
        }
        public string get_answer(int q_id, int id) 
        {
            try
            {
                return arr[q_id].Answers[id];
            }
            catch 
            {
                return "No_INFO!";
            }
        }
        public int get_count(int q_id) 
        {
            return arr[q_id].Answers.Length;
        }
        
        public string get_result(string data) 
        {
            CmpL.ML_res = MlController.get_prediction_result(data);
            Array.Sort(languages,new CmpL());
            int last;
            if (data[data.Length - 1] == '8') 
            {
                last = 0;
            }
            else last =  data[data.Length - 1]-'0';
            string res = "";
            string? used_language = null;
            //Дополнительный фильтр по последнему вопросу
            switch (last) 
            {
                case 1:
                    foreach (var el in languages)
                    {
                        if (el.Title == "JavaScript" || el.Title == "TypeScript" || el.Title == "PHP" || el.Title == "Go" || el.Title == "Ruby") 
                        {
                            res = $"<a href=\"/lang/{langIdDict[el.Title]}\">{el.Title}<a/>";
                            used_language = el.Title;
                        }
                    }
                    break;
                case 2:
                    foreach (var el in languages)
                    {
                        if (el.Title == "Kotlin" || el.Title == "Java")
                        {
                            res = $"<a href=\"/lang/{langIdDict[el.Title]}\">{el.Title}<a/>";
                            used_language = el.Title;
                            break;
                        }
                    }
                    break;
                case 3:
                    foreach (var el in languages)
                    {
                        if (el.Title == "C++" || el.Title == "C#")
                        {
                            res = $"<a href=\"/lang/{langIdDict[el.Title]}\">{el.Title}<a/>";
                            used_language = el.Title;
                            break;
                        }
                    }
                    break;
                case 4:
                    foreach (var el in languages)
                    {
                        if (el.Title == "C#" || el.Title == "Java" || el.Title == "C++")
                        {
                            res = $"<a href=\"/lang/{langIdDict[el.Title]}\">{el.Title}<a/>";
                            used_language = el.Title;
                            break;
                        }
                    }
                    break;
                case 5:
                    res = $"<a href=\"/lang/swift\">Swift<a/>";
                    used_language = "Swift";
                    break;
                case 6:
                    foreach (var el in languages)
                    {
                        if (el.Title == "C#" || el.Title == "VisualBasic")
                        {
                            res = $"<a href=\"/lang/{langIdDict[el.Title]}\">{el.Title}<a/>";
                            used_language = el.Title;
                            break;
                        }
                    }
                    break;
                case 7:
                    foreach (var el in languages)
                    {
                        if (el.Title == "C++" || el.Title == "Assembler")
                        {
                            res = $"<a href=\"/lang/{langIdDict[el.Title]}\">{el.Title}<a/>";
                            used_language = el.Title;
                            break;
                        }
                    }
                    break;
            }
            if (last == 0)
            {
                res = $"<a href=\"/lang/{langIdDict[languages[0].Title]}\">{languages[0].Title}<a/>";
                used_language = languages[0].Title;
                res += "<br> А так же советую обратить внимание на следующие языки программирования:<br>";
                int cur_lang_ind = 0;
                if (languages[cur_lang_ind].Title == used_language) cur_lang_ind++;
                res += $"<a href=\"/lang/{langIdDict[languages[cur_lang_ind].Title]}\">{languages[cur_lang_ind++].Title}<a/> <br>";
                if (languages[cur_lang_ind].Title == used_language) cur_lang_ind++;
                res += $"<a href=\"/lang/{langIdDict[languages[cur_lang_ind].Title]}\">{languages[cur_lang_ind++].Title}<a/> <br>";
                if (languages[cur_lang_ind].Title == used_language) cur_lang_ind++;
                res += $"<a href=\"/lang/{langIdDict[languages[cur_lang_ind].Title]}\">{languages[cur_lang_ind++].Title}<a/> <br>";
            }
            else 
            {
                res += "<br> А так же советую обратить внимание на следующие языки программирования:<br>";
                int cur_lang_ind = 0;
                if(languages[cur_lang_ind].Title==used_language)cur_lang_ind++;
                res += $"<a href=\"/lang/{langIdDict[languages[cur_lang_ind].Title]}\">{languages[cur_lang_ind++].Title}<a/> <br>";
                if (languages[cur_lang_ind].Title == used_language) cur_lang_ind++;
                res += $"<a href=\"/lang/{langIdDict[languages[cur_lang_ind].Title]}\">{languages[cur_lang_ind++].Title}<a/> <br>";
                if (languages[cur_lang_ind].Title == used_language) cur_lang_ind++;
                res += $"<a href=\"/lang/{langIdDict[languages[cur_lang_ind].Title]}\">{languages[cur_lang_ind++].Title}<a/> <br>";
            }
            return res;
        }
    }
}
