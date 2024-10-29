using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelCellFinder.Core.Result.Interface
{
    public interface IResultFile
    {
        FileInfo FileInfo { get; protected set; }

        IList<IFoundCell> FoundCells { get; protected set; }
    }
}
