using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace cSharpConcepts
{
    public class linqToXml
    {
        // example, you might want a list, sorted by part number, of the items with a value greater than $100.
        // To obtain this information, you could run the following query:
        public void LinqToXml()
        {
            // Load the XML file from the project directory containing the purchase orders
            var filename = "PurchaseOrder.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);
            XElement purchaseOrder = XElement.Load(purchaseOrderFilepath);
            //IEnumerable<XElement> pricesByPartNos = from item in purchaseOrder.Descendants("Item")
            //                                        where (int)item.Element("Quantity") * (decimal)item.Element("USPrice") > 100
            //                                        orderby (string)item.Element("PartNumber")
            //                                        select item;

            // In C#, this can be rewritten in method syntax form:
            IEnumerable<XElement> pricesByPartNos = purchaseOrder.Descendants("Item")
                                        .Where(item => (int)item.Element("Quantity") * (decimal)item.Element("USPrice") > 100)
                                        .OrderBy(order => order.Element("PartNumber"));
            /*
             In addition to these LINQ capabilities, LINQ to XML provides an improved XML programming interface. Using LINQ to XML, you can:
                Load XML from files or streams.
                Serialize XML to files or streams.
                Create XML from scratch by using functional construction.
                Query XML using XPath-like axes.
                Manipulate the in-memory XML tree by using methods such as Add, Remove, ReplaceWith, and SetValue.
                Validate XML trees using XSD.
                Use a combination of these features to transform XML trees from one shape into another.
             */

            // One of the most significant advantages of programming with LINQ to XML is that it's easy to create XML trees. For example, to create a small XML tree, you can write code as follows:
            XElement contacts =
                new XElement("Contacts",
                    new XElement("Contact",
                        new XElement("Name", "Patrick Hines"),
                        new XElement("Phone", "206-555-0144",
                            new XAttribute("Type", "Home")),
                        new XElement("phone", "425-555-0145",
                            new XAttribute("Type", "Work")),
                        new XElement("Address",
                            new XElement("Street1", "123 Main St"),
                            new XElement("City", "Mercer Island"),
                            new XElement("State", "WA"),
                            new XElement("Postal", "68042")
                        )
                    )
                );
        }
    }
}
