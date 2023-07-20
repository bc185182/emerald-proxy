using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmeraldProxyManager
{
    public class Operation
    {
        public string ServiceName { get; set; }

        public RtiType RtiType { get; set; }

        public OperationType OperationType { get; set; }

        public string XPath { get; set; }

        public string Content { get; set; }

    }

}
