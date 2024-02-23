using System.Text.Json;
namespace Libruary
{
    public class AutoSaver
    {
        private DateTime? _lastUpdate;
        private JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true };
        public void PriceHandler(object sender, UpdateEventArgs args)
        {
            if (_lastUpdate is null)
            {
                _lastUpdate = args.Dt;
            }
            else 
            {
                if ((args.Dt.Value - _lastUpdate.Value).Seconds >= 15) 
                {
                    using (StreamWriter sr = new StreamWriter(Directory.GetCurrentDirectory() + $"\\dataJson_tmp.json")) 
                    {
                        string jsonString = JsonSerializer.Serialize(args.Data,_options);
                        sr.WriteLine(jsonString);
                    }
                }
                _lastUpdate = args.Dt;
            }
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

