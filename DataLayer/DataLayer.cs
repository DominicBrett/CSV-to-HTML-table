using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataLayer
    {
        public List<string> readCSVHead(string filepath)
        {
            var headings = File.ReadLines(filepath).Take(1).Select(a => a.Split(','));

            List<string> head = new List<string>();

            foreach (string[] header in headings)
            {
                foreach (string heading in header)
                {
                    head.Add(heading);
                }

            }

            return head;

        }
        public List<List<string>> readCSVBody(string filepath)
        {
            
            List<List<string>> body = new List<List<string>>();
          
            var rows = File.ReadAllLines(filepath).Skip(1).Select(a => a.Split(','));
            foreach (string[] row in rows)
            {
                List<string> rowList = new List<string>();
                foreach (string cell in row)
                {
                    rowList.Add(cell);
                }
                body.Add(rowList);
            }
            return body;
        }
        public void writeHTML(string content)
        {
            File.WriteAllText(@"C:\Users\Novus\source\repos\CSVTable\DataLayer\table.html", content);
        }
    }
}
