namespace Libruary
{
    /// <summary>
    /// Класс для данных о событии изменения в стоимости продукта.
    /// _cost - новая стоимость
    /// _sender - объект, продукт которого притерпел изменения.
    /// _records - новая база данных. Передается с целью переподписки покупателя на новый товар.
    /// </summary>
    public class PriceEventArgs : EventArgs
    {
        private double _cost;
        private Record _sender;
        private List<Record?>? _records;
        public PriceEventArgs() { }
        public PriceEventArgs(double cost, Record sender, List<Record?>? records)
        {
            _cost = cost;
            _sender = sender;
            _records = records;
        }
        internal double Cost => _cost;
        internal Record Sender => _sender;

        internal List<Record?>? Data => _records;
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
