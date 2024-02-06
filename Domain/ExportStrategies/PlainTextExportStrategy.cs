﻿using System;
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
            File.WriteAllText("C:\\Temp\\test.txt", this.ToString());
        }
    }
}
