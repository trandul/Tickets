using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ConnectionSettings
{
    public class ConnectionSettingsModel
    {
        public string ConnectionString { get;}
        public ConnectionSettingsModel(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
