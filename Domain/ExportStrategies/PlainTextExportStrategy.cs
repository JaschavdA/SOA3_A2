using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExportStrategies
{
    public class PlainTextExportStrategy : ExportStrategy
    {
        public PlainTextExportStrategy() { }

        public void Export(Order order)
        {
            const string folder = "C:\\export";
            const string url = $"{folder}\\test.txt";
            Directory.CreateDirectory(folder);
            File.WriteAllText(url, JsonConvert.SerializeObject(order));
        }
    }
}
