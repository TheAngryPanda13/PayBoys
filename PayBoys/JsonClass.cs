using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayBoys
{
    class JsonClass
    {
        public string user { get; set; }
        public int totalSum { get; set; }
        public DateTime localDateTime { get; set; }
        public JsonItems[] items { get; set; }

        public string nameTable;
        public string NameTable()
        {
            if (this.user.Contains("Агроторг") || this.user.Contains("АГРОТОРГ"))
            {
                this.nameTable = "Пятёрочка " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            if (this.user.Contains("Прайс") || this.user.Contains("ПРАЙС"))
            {
                this.nameTable = "ФиксПрайс " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            if (this.user.Contains("Лента") || this.user.Contains("ЛЕНТА"))
            {
                this.nameTable = "Лента " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            if (this.user.Contains("Перекресток") || this.user.Contains("ПЕРЕКРЕСТОК"))
            {
                this.nameTable = "Перекресток " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            if (this.user.Contains("Магнит") || this.user.Contains("МАГНИТ"))
            {
                this.nameTable = "Магнит " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            if (this.user.Contains("Дикси") || this.user.Contains("ДИКСИ"))
            {
                this.nameTable = "Дикси " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            else
                return "Error";
        }
    }
}
