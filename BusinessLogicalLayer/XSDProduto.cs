using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
namespace BusinessLogicalLayer
{
    public class XSDProduto
    {
        public bool validaXML(string path)
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            try
            {
                schemas.Add("", @"C:\Users\moc\Desktop\Econo+\BudgShopAPP\BusinessLogicalLayer\XSD\XML SCHEMA MODEL.xsd");
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    XDocument doc = XDocument.Load(fs);
                    string msg = "";
                    doc.Validate(schemas, (o, e) =>
                                {
                                    msg += e.Message + Environment.NewLine;
                                });
                    if (string.IsNullOrEmpty(msg)){ return true; } else { return false; }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
