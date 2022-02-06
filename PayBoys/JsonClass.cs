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

        public string Buyer { get; set; }

        public string NameTable()
        {
            //список магазинов и их названий в чеках
            var shops = new Dictionary<string, string>()
            {
                {"Агроторг", "Пятерочка"},
                {"Прайс", "ФиксПрайс" },
                {"Лента", "Лента" },
                {"Перекресток", "Перекресток" },
                {"Магнит", "Магнит" },
                {"Дикси", "Дикси" }

            };

            foreach (var sh in shops)
            {
                if (this.user.Contains(sh.Key, StringComparison.OrdinalIgnoreCase))
                {
                    return $"{sh.Value}+{this.localDateTime.ToString("dd.MM-hh:mm")}";
                }
            }

            //заглушака. прописать try...catch
            return "Table Error";



            /*if (this.user.Contains("Агроторг", StringComparison.OrdinalIgnoreCase))
            {
                this.nameTable = "Пятёрочка " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            if (this.user.Contains("Прайс", StringComparison.OrdinalIgnoreCase))
            {
                this.nameTable = "ФиксПрайс " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            if (this.user.Contains("Лента", StringComparison.OrdinalIgnoreCase))
            {
                this.nameTable = "Лента " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            if (this.user.Contains("Перекресток", StringComparison.OrdinalIgnoreCase))
            {
                this.nameTable = "Перекресток " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            if (this.user.Contains("Магнит", StringComparison.OrdinalIgnoreCase))
            {
                this.nameTable = "Магнит " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            if (this.user.Contains("Дикси", StringComparison.OrdinalIgnoreCase))
            {
                this.nameTable = "Дикси " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            else
                return "Error";*/
        }
    }
}
