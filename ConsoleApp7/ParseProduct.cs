using AngleSharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class ParseProduct
    {
        public async Task ParseProd() {

            


            await TakeInfoAsync("h1.detail-name");

            await TakeInfoAsync("span.price");

            await TakeInfoAsync("span.ok");

            
           


          

            //var titles = cells.Select(m => m.TextContent);
            //Console.WriteLine(titles.ToString());

        }

        public void AddToList (ref List<String> listOfPage, ref String cells) {

            listOfPage.Add(cells);
        }

        public async Task TakeInfoAsync (string cellSelector) {

            List<String> listOfPage = new List<string>();
            var config = Configuration.Default.WithDefaultLoader();   //парсинг имени
            var address = "https://www.toy.ru/catalog/mashinki_iz_multfilmov/fortnite_fnt0163_mashina_quadcrasher/";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);

            var cells = document.QuerySelector(cellSelector).TextContent;
            AddToList(ref listOfPage, ref cells);


            foreach (var i in listOfPage) {
                Console.WriteLine(i);
            }
        }


    }

        
}

