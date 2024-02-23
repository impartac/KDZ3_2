
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Libruary
{
    public class Record
    {
        public event EventHandler<PriceEventArgs> PriceRaise;

        private string? _recordId;
        [JsonPropertyName("recordId")]
        public string? RecordId { get => _recordId; }


        private string? _productName;
        [JsonPropertyName("productName")]
        public string? ProductName { get => _productName; set => _productName = value; }


        private int? _quantity;
        [JsonPropertyName("quantity")]
        public int? Quantity 
        { 
            get => _quantity;
            set
            {
                _quantity = value > 0 ? value : throw new ArgumentOutOfRangeException();
            }
        }
        private double? _price;
        [JsonPropertyName("price")]
        public double? Price 
        {
            get => _price;
            set 
            {
                _price = value > 0 ? value : throw new ArgumentOutOfRangeException();
                
            }
        }

        internal double Cost =>_price??0 * _quantity ?? 0;


        private DateTime? _orderDate;
        [JsonPropertyName("orderDate")]
        public DateTime? OrderDate { get => _orderDate; set => _orderDate = value; }


        private List<Customer?>? _customerDetails;
        [JsonPropertyName("customerDetails")]
        public List<Customer?>? CustomerDetails { get => _customerDetails; }


        [JsonConstructor]
        public Record(string? recordId,
                      string? productName,
                      int? quantity,
                      double? price,
                      DateTime? orderDate,
                      List<Customer?>? customerDetails)
        {
            _recordId = recordId;
            _productName = productName;
            _quantity = quantity;
            _price = price;
            _orderDate = orderDate;
            _customerDetails = customerDetails;

        }
        public Record() { }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
        public void UpdateHandler(object sender, PriceEventArgs args) 
        {
            //Console.WriteLine($"Изменения в объекте с полем {_recordId} : {args.Dt}");
        }

        // Метод для изменения кол-ва. Пораждает событие изменения в стоимости.
        internal void SetQuantity(List<Record?>? records,int? value) 
        {
            PriceRaise?.Invoke(this, 
                new PriceEventArgs((value ?? 0 - _price ?? 0) * _quantity ?? 0, 
                this,
                records));
            _quantity = value > 0 ? value : throw new ArgumentOutOfRangeException();
        }

        // Метод для изменения цены. Пораждает событие изменения cтоимости.
        internal void SetPrice(List<Record?>? records, double? value) 
        {
            PriceRaise?.Invoke(this, 
                new PriceEventArgs((value ?? 0 - _price ?? 0) * _quantity ?? 0, 
                this,
                records
                ));
            _price = value > 0 ? value : throw new ArgumentOutOfRangeException();
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