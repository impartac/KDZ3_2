using System.Reflection;

namespace Libruary
{
    // Класс взаимодействия с консолью.
    public class Menu
    {
        private FieldInfo[] fields = typeof(Record).GetFields(BindingFlags.Instance | 
                                                                                BindingFlags.NonPublic);
        public void ChooseAction() 
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1) Отсортировать по одному из полей");
             // Console.WriteLine("2) Отфильтровать по одному из полей");
            Console.WriteLine("2) Отредактировать поле одного из объектов.");
        }
        // Метод позволяющий достать нужные имена полей.
        // Условия внутри - костыли, чтобы убрать лишние поля. Они были сделаны
        // с целью отработки рефлексии. В идеале можно будет заменить editor на enum,
        // а условия на константные наборы полей.
        public void СhooseField(bool editor) 
        {
            Console.WriteLine("Выберите поле");
            int i = 0;
            foreach (var v in fields) 
            {
                if (editor)
                {
                    if (!v.Name.Contains("Id") && !v.Name.Contains("Raise"))
                    {
                        Console.WriteLine($"{i+1}) {v.Name[1..]}");
                        i++;
                    }
                }
                else 
                {
                    if (!v.Name.Contains("customerDetails") && !v.Name.Contains("Raise"))
                    {
                        Console.WriteLine($"{i + 1}) {v.Name[1..]}");
                        i++;
                    }
                }
            }
        }
        public void Restart(ConsoleKey key) 
        {
            Console.WriteLine($"Нажмите кнопку {key}, чтобы повторить решение.");
        }
        public void ReadFile() 
        {
            Console.WriteLine("Введите путь до файла.");
        }
        public void Exception(Exception exception) 
        {
            Console.WriteLine($"Произошла ошибка : {exception.Message}");
        }
        public void WriteDataInConsole(List<Record?>? data) 
        {
            foreach (var v in data) 
            {
                Console.WriteLine(v.ToJson());
            }
        }
        public void Value() 
        {
            Console.WriteLine("Введите новое значение поля.");
        }
        public void ID() 
        {
            Console.WriteLine("Введите поле идентификатора объекта, значение в котором хотите поменять.");
        }
        public void Repeat() 
        {
            Console.WriteLine("Введенные данные некорректны.");
        }
        public void CustomerID() 
        {
            Console.WriteLine("Введите Id покупателя.");
        }
        public void ReadNewFile(ConsoleKey key) 
        {
            Console.WriteLine($"\nЧтобы прочитать новый файл нажмите {key}.\n");
        }
        public void Clear() 
        {
            Console.Clear();
        }
        public void SaveFile() 
        {
            Console.WriteLine("Введите путь до файла сохранения.");
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
