
using System.Data;

namespace Libruary
{
    // Класс работы с базой данных.
    public static class DataProcessing
    {
        static Menu menu = new Menu();
        public static List<Record?>? Sort(List<Record?>? records, string field) 
        {
            return field switch
            {
                "recordId" => records?.OrderBy(x => x?.RecordId).ToList(),
                "productName" => records?.OrderBy(x => x?.ProductName).ToList(),
                "quantity" => records?.OrderBy(x => x?.Quantity).ToList(),
                "price" => records?.OrderBy(x => x?.Price).ToList(),
                "orderDate" => records?.OrderBy(x => x?.OrderDate).ToList(),
                // "customerDetails" => records?.OrderBy(x => x?.CustomerDetails).ToList(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        public static List<Record?>? Sample(List<Record?>? records, string field,string sample) 
        {
            sample = sample.Replace('T',' ');
            return field switch
            {
                "recordId" => records?.Where(x=> x?.RecordId == sample).ToList(),
                "productName" => records?.Where(x => x?.ProductName == sample).ToList(),
                "quantity" => records?.Where(x => x?.Quantity.ToString() == sample).ToList(),
                "price" => records?.Where(x => x?.Price.ToString() == sample).ToList(),
                "orderDate" => records?.Where(x => x?.OrderDate.ToString() == sample).ToList(),
                 // "customerDetails" => records?.OrderBy(x => x?.CustomerDetails).ToList(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        public static List<Record?>? Edit(List<Record?>? records, string id, string field, string value) 
        {
            Record edit = records.Where(x => x.RecordId == id).ToList()[0];
            if (edit is null) 
            {
                throw new ArgumentNullException();
            }
            switch (field)
            {
                case ("productName") : 
                    { 
                        edit.ProductName = value; 
                        break; 
                    };
                case ("quantity"): 
                    {
                        edit.SetQuantity(records,int.Parse(value));
                        //edit.Quantity = int.Parse(value); 
                        break; 
                    };
                case ("price"): 
                    { 
                        edit.SetPrice(records,double.Parse(value));
                        break; 
                    };
                case ("orderDate"):
                    { 
                        edit.OrderDate= DateTime.Parse(value); 
                        break; 
                    };
                case ("customerDetails"):
                    {
                        menu.CustomerID();
                        string custId = Console.ReadLine();
                        foreach (var v in edit.CustomerDetails) 
                        {
                            if (v.CustomerId == custId) 
                            {
                                v.Name = value; 
                                break;
                            }
                        }
                        break;
                    }
                default: throw new ArgumentOutOfRangeException();
            };
            return new List<Record?>(records);
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