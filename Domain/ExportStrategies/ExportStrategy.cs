using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExportStrategies
{
    public interface ExportStrategy
    {
        void Export(Order order);
    }
}
