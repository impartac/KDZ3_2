
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Libruary
{
    public class Customer : IComparer<Customer>
    {
        private static Random rnd = new Random();

        private string? _customerId;
        [JsonPropertyName("customerId")]
        public string? CustomerId => _customerId;

        private string? _name;
        [JsonPropertyName("name")]
        public string? Name { get => _name; set => _name = value; }
        internal Customer() : base() { }

        [JsonConstructor]
        public Customer(string customerId,string name) 
        {
            _customerId = customerId;
            _name = name;
        }
        public string ToJson() 
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
        public void UpdateCosteHandler(object? sender, PriceEventArgs args)
        {
            if (args.Cost >= 0 && rnd.Next(0, 2) == 1)
            {
                 // Console.WriteLine($"{Name} отписался от {args.Sender.ProductName}");
                args.Sender.PriceRaise -= UpdateCosteHandler;
                double mn = args.Data.Min(x => x.Cost);
                foreach (var v in args.Data)
                {
                    if (v.Cost == mn)
                    {

                        v.PriceRaise += UpdateCosteHandler;
                        // Console.WriteLine($"{Name} подписался на {v.ProductName}");
                        break;
                    }
                }
            }
        }

        public int Compare(Customer? x, Customer? y)
        {
            return x.Name.CompareTo(y.Name);
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
