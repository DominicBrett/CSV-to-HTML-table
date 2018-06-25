using System;
using Bl = BusinessLayer.BusinessLayer;
namespace CSVTable
{
    class ApplicationControl
    {
        static void Main(string[] args)
        {
            Bl bl = new Bl();
            bl.makeTable(@"C:\Users\Novus\source\repos\CSVTable\DataLayer\test.csv");
        }
    }
}
