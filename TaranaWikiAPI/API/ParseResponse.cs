using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaranaWikiAPI.API
{
    public class ParseResponse
    {
        public Parse Parse { get; set; }
    }

    public class Parse
    {
        public Text Text { get; set; }
    }

    public class Text
    {
        public string[] Keys { get; set; }
        public string this[string key] => Keys.FirstOrDefault(k => k == key);
    }
}
