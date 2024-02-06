using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExportStrategies
{
    public class JSONExportStrategy: ExportStrategy
    {
        public JSONExportStrategy() { }

        public void Export(Order order)
        {
            const string url = "C:\\Temp\\test.json";
            File.WriteAllText(url, JsonConvert.SerializeObject(order));
        }
    }
}
