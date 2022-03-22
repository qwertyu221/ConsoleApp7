using CsvHelper;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{

    class WriteCvs
    {

       
        static List<Product> alldata = new List<Product>();
        //static int cnt = 0;

        
       
        public void Writeinfile (List<string> getproduct, List<string> links, string link) {
           
            Product product = new Product(getproduct[0], getproduct[1], getproduct[2], getproduct[3], getproduct[4], getproduct[0], links[3] ,link);
           
            alldata.Add(product);
            Console.WriteLine(alldata.Count());
           

           
        }

        public void Push () {

            using (var writer = new StreamWriter("file.csv") )

            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)) {


                Console.WriteLine(alldata.Count());
                csv.WriteRecords(alldata);
                Process.GetCurrentProcess().Kill();

                writer.Close();
                writer.Dispose();

            }
        }
    }
}
