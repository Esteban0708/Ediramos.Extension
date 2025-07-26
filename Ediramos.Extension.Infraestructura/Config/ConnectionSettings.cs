using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ediramos.Extension.Infraestructura.Config
{
    public class ConnectionSettings
    {
        public string? OracleConnection { get; set; }
        public string? SqlServerConnection { get; set; }
        public string? MongoConnection { get; set; }
        public string? MongoDatabase { get; set; }
    }
}
