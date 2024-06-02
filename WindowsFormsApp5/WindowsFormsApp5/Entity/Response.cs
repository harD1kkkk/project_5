using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    public class Response<T>
    {
        public T Obj { get; set; }

        public string errorMessage { get; set; }
    }
}
