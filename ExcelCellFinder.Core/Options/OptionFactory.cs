using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelCellFinder.Core.Options.Interface;

namespace ExcelCellFinder.Core.Options
{
    public class OptionFactory
    {
        public static IFindCellOptions GetOption()
        {
            return new FindCellOptions();
        }
    }
}
