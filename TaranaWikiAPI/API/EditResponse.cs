using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaranaWikiApi;

namespace TaranaWikiAPI.API
{
    public class EditResponse
    {
        public Edit Edit { get; set; }
    }

    public class Edit
    {
        public string Result { get; set; }
    }
}
