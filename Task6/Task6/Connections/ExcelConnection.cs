using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Connections
{
    public class ExcelConnection
    {
        private string _path;
        public void SetFilePath(string path)
        {
            _path = path;
        }
        public string ConnectionString
        {
            get
            {
                return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_path};Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
            }
        }
    }
}
