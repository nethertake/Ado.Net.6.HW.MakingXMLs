using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoXML_hw1.MCS;
using System.IO;
using System.Xml.Linq;

namespace AdoXML_hw1
{
    class Program
    {
       public static Model1 db = new Model1();
        static void Main(string[] args)
        {
            Task1();
        }

        static void Task1()
        {

            var query = db.Area.Where(w => w.PavilionId == 1);

            foreach(Area item in query)
            {
                XDocument xDoc = new XDocument(
                    new XElement("Area",
                new XElement("AreaId", item.AreaId),
                new XElement("Name", item.Name),
                new XElement("ParentId", item.ParentId)));
                xDoc.Save(item.AreaId + ".xml");
            }

        }

        static void Task2()
        {
            foreach(var item in db.Area)
            {
                DirectoryInfo dir = new DirectoryInfo(@"area\" + item.Name + "(" + item.AreaId + ")");
                dir.Create();
                XDocument xDoc = new XDocument(
                   new XElement("Area",
               new XElement("AreaId", item.AreaId),
               new XElement("Name", item.Name),
               new XElement("ParentId", item.ParentId)));
                xDoc.Save(dir + ".xml");
            }


        }

    }
}
