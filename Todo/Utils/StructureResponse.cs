using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todo.Utils
{
    public class StructureResponse
    {
        public string code { get; set; }
        public string message { get; set; }
        public string messageTitle { get; set; }
        public dynamic payload { get; set; }
    }
}