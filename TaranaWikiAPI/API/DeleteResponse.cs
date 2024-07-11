using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaranaWikiAPI.API
{
    public class DeleteResponse
    {
        public Delete Delete {  get; set; }
    }

    public class Delete
    {
        public string Result { get; set; }
    }
}
