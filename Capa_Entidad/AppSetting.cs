using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class AppSetting
    {
        public StorageConfiguration StorageConfiguration { get; set; }
    }

    public class StorageConfiguration
    {
        public string Path { get; set; }
        public string PublicUrl { get; set; }
    }
}
