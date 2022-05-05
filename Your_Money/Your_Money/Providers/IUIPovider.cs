using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Your_Money.Providers
{
    public interface IUIPovider
    {
        public void RunUserInterface();
        public void DisplayTable<T>(List<T> entry) where T : Entry;
        public void Display(string text);
        public string? GetUserLine();
    }
}
