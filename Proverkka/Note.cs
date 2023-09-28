using System;

namespace Proverkka
{
    internal class Note
    {
        public string name { get; }
        public string type { get; }
        public double money { get; }
        public DateTime date;

      
        public Note(string name, string type, double money, DateTime date)
        {
            this.name = name;
            this.type = type;
            this.money = money;
            this.date = date;
        }
    }
}
