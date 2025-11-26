using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosSmartGrid
{
    // Копия интерфейса IDataTree из библиотеки Tools для работы функционала грида, связанного с построением иерархии
    public interface ITreeData
    {
        [DefaultValue(0)]
        int Id { get; set; }

        [DefaultValue(0)]
        int ParentId { get; set; }

        [DefaultValue("")]
        string Name { get; set; }
    }
}
