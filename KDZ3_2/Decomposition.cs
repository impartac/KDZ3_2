using Libruary;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace KDZ3_2
{

    internal class Decomposition
    {
        public static Menu menu = new Menu();
        static Publisher publisher = new Publisher();
        static AutoSaver autoSaver = new AutoSaver();
        static JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
        static string[] EditFields = { 
            "productName",
            "quantity",
            "price",
            "orderDate",
            "customerDetails"
        };
        static string[] FieldsToSort = { 
            "recordId",
            "productName",
            "quantity",
            "price",
            "orderDate",
        };
        // Первый этап - считывание и проверка файла.
        internal void Start(ref List<Record?>? records) 
        {
            bool check = false;
            do
            {
                try
                {
                    menu.ReadFile();
                    string href = Console.ReadLine();
                    StreamReader temp = new StreamReader(href.Trim('"'));
                    string json = temp.ReadToEnd();
                    records = JsonSerializer.Deserialize<List<Record?>?>(json);
                    temp.Dispose();
                    check = true;
                }
                catch (Exception ex)
                {
                    menu.Exception(ex);
                }
            }
            while (!check);
        }

        // Подписка всех покупателей на их товары.
        private void Subscribe(ref List<Record?>? records) 
        {
            for (int i = 0; i < records.Count; i++)
            {
                foreach (var customer in records[i].CustomerDetails)
                {
                    records[i].PriceRaise += customer.UpdateCosteHandler;
                }
            }
        }
        
        // Выбор действия в меню.
        private int ChooseAction(Action action,int count) 
        {
            int temp;
            do
            {
                action.Invoke();
            }
            while (!(int.TryParse(Console.ReadLine(), out temp) && (0 < temp && temp <= count)));
            return temp;
        }
        // Выбор поля в меню.
        private string ChooseField(string[] fields,bool edit) 
        {
            int temp;
            do
            {
                menu.СhooseField(edit);
            }
            while (!(int.TryParse(Console.ReadLine(), out temp) && (0 < temp && temp <= fields.Length)));
            return fields[temp-1];
        }
        // Считывание идентификатора экземпляра класса, данные которого будут изменены.
        private string IdEdit(List<Record?>? data) 
        {
            string id;
            menu.ID();
            id = Console.ReadLine().Trim('"');
            var sample = DataProcessing.Sample(data, "recordId", id);
            while (sample is null || sample.Count<1 ) 
            {
                menu.Repeat();
                menu.ID();
                id = Console.ReadLine().Trim('"');
                sample = DataProcessing.Sample(data, "recordId", id);
            }
            return id;
        }
        private string ValueEdit() 
        {
            menu.Value();
            return Console.ReadLine();
        }
        // Работа с базой данных.
        private List<Record?>? DoAction(int action, ref List<Record?>? data,string field) 
        {
            List<Record?>? temp = new List<Record?>(); 
            switch (action)
            {
                case 1: 
                    {
                        data = DataProcessing.Sort(data, field);
                        var update = new UpdateEventArgs(DateTime.Now, ref data);
                        publisher.Update(this, update);
                        break;
                    }
                case 2: 
                    {
                        string id = IdEdit(data);
                        string value;
                        bool check = false;
                        do
                        {
                            try 
                            {
                                value = ValueEdit();
                                temp = DataProcessing.Edit(data, id, field, value);
                                var update = new UpdateEventArgs(DateTime.Now,ref temp);
                                publisher.Update(this, update);
                                check = true;
                            }
                            catch (Exception ex) { }
                        }
                        while (!check);
                        break;
                    }
                //case 3: 
                //    {
                //        menu.Value();
                //        string sample = Console.ReadLine();
                //        return DataProcessing.Sample(data, field, sample);
                //    }
                default : 
                    {
                        throw new ArgumentOutOfRangeException(); 
                    }
            }

            return temp;
        }
        // Получения корректного пути для вывода данных.
        private string GetPath() 
        {
            bool check = false;
            string href = "";
            do
            {
                try
                {
                    menu.SaveFile();
                    href = Console.ReadLine();
                    StreamWriter temp = new StreamWriter(href.Trim('"')) { };
                    
                    temp.Close();
                    temp.Dispose();
                    check = true;
                }
                catch (Exception ex)
                {
                    menu.Exception(ex);
                }
            }
            while (!check);
            return href;
        }
        // Метод сохранения данных в файл.
        internal void SaveFile(ref List<Record?>? records)
        {
            bool check = false;
            do
            {
                try
                {
                    string href = GetPath();
                    using (StreamWriter sw = new StreamWriter(href.Trim('"')))
                    {
                        string data = JsonSerializer.Serialize(records, jsonSerializerOptions);
                        sw.WriteLine(data);
                    }
                    check = true;
                }
                catch (Exception ex)
                {
                    menu.Exception(ex);
                }
            }
            while (!check);
        }
        // Вторая часть - обработка и сохранение данных.
        internal void Solution(ref List<Record?>? records) 
        {
            Subscribe(ref records);
            publisher.Updated += autoSaver.PriceHandler;

            int action = ChooseAction(menu.ChooseAction, 2);
            string field = ChooseField(action == 2  ? EditFields : FieldsToSort,action==2);
            List<Record?>? temp = DoAction(action, ref records, field);
            //menu.WriteDataInConsole(temp);
            Console.WriteLine(JsonSerializer.Serialize(records, jsonSerializerOptions));
            menu.Restart(ConsoleKey.Enter);
        }
    }
}
/*
░░░░░░░░░░░░░░░░░░░░
░░░░░ЗАПУСКАЕМ░░░░░░░
░ГУСЯ░▄▀▀▀▄░РАБОТЯГИ░░
▄███▀░◐░░░▌░░░░░░░░░
░░░░▌░░░░░▐░░░░░░░░░
░░░░▐░░░░░▐░░░░░░░░░
░░░░▌░░░░░▐▄▄░░░░░░░
░░░░▌░░░░▄▀▒▒▀▀▀▀▄
░░░▐░░░░▐▒▒▒▒▒▒▒▒▀▀▄
░░░▐░░░░▐▄▒▒▒▒▒▒▒▒▒▒▀▄
░░░░▀▄░░░░▀▄▒▒▒▒▒▒▒▒▒▒▀▄
░░░░░░▀▄▄▄▄▄█▄▄▄▄▄▄▄▄▄▄▄▀▄
░░░░░░░░░░░▌▌░▌▌░░░░░
░░░░░░░░░░░▌▌░▌▌░░░░░
░░░░░░░░░▄▄▌▌▄▌▌░░░░░
*/
