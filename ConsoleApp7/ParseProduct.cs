using AngleSharp;
using AngleSharp.Dom;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class ParseProduct
    {
        public async Task ParseProd(string adress) {

            List<IElement> listOfPage = new List<IElement>();

            adress = "https://www.toy.ru" + adress;

            //var adress = "https://www.toy.ru/catalog/mashinki_iz_multfilmov/fortnite_fnt0163_mashina_quadcrasher/";


            var config = Configuration.Default.WithDefaultLoader();   //парсинг имени
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(adress);

            await TakeInfoAsync("nav.breadcrumb", adress);
            await TakeInfoAsync("h1.detail-name", adress);
            await TakeInfoAsync("span.old-price", adress);
            await TakeInfoAsync("span.price", adress);
            await TakeInfoAsync("span.ok", adress);
            await TakeInfoAsync("div.col-12.select-city-link a", adress);
            await TakeInfoAsync("div.col-12.col-md-10.col-lg-7", adress);
            await TakePngAsync("img.img-fluid", adress);

            foreach (var i in listOfPage) {
                Console.WriteLine(i.TextContent.Trim());
            }

            void AddToList (ref List<IElement> listOfPage, ref IElement cells) {
                listOfPage.Add(cells);
            }

            async Task TakeInfoAsync (string cellSelector, string address) {
                var cells = document.QuerySelector(cellSelector);

                if (cells != null) {
                    AddToList(ref listOfPage, ref cells);
                }               
            }

            async Task TakePngAsync (string cellSelector, string address) {
                
                var cells = document.QuerySelectorAll(cellSelector);
                 
                foreach (var i in cells) { 
                    var pngLink = i.Attributes["src"].Value; 
                    Console.WriteLine(pngLink); 
                }

            }
        }
    }
}

