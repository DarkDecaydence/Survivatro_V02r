using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Survivatron_v02r.FileUtilities
{
    public class BlockFileHandler
    {
        public bool LoadBlocksFromFile(string fileName)
        {
            return true;
        }
#if true
        public bool SaveBlock(string fileName)
        {
            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                writer.WriteStartElement("gmb");
                writer.WriteAttributeString("xmlns", "gamblo", null, "insertsomethingsmarthere");
            }
            return true;
        }
#endif
    }
}
