using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace SequenceStudio
{
    public partial class NcbiMethods
    {

        public static XDocument ReadFastAXml(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new SequenceException(string.Format("The input Path {0} is not a valid File Path.", path));

            if (!File.Exists(path))
                throw new SequenceException(string.Format("The specified File {0} does not exist in the Path.", path));

            var sf = File.ReadAllText(path);
            return XDocument.Parse(sf);
        }

    }
}
