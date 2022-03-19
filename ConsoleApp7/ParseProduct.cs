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
        public async Task ParseProd() {

            List<IElement> listOfPage = new List<IElement>();


            await TakeInfoAsync("nav.breadcrumb");
            await TakeInfoAsync("h1.detail-name");
            await TakeInfoAsync("span.old-price");
            await TakeInfoAsync("span.price");
            await TakeInfoAsync("span.ok");
            await TakeInfoAsync("div.col-12.select-city-link");
            await TakeInfoAsync("div.col-12.col-md-10.col-lg-7");


            foreach (var i in listOfPage) {
                Console.WriteLine(i.TextContent.Trim());
            }



            void AddToList (ref List<IElement> listOfPage, ref IElement cells) {

                listOfPage.Add(cells);
            }

            async Task TakeInfoAsync (string cellSelector) {


                var config = Configuration.Default.WithDefaultLoader();   //парсинг имени
                var address = "https://www.toy.ru/catalog/mashinki_iz_multfilmov/fortnite_fnt0163_mashina_quadcrasher/";
                var context = BrowsingContext.New(config);
                var document = await context.OpenAsync(address);



                var cells = document.QuerySelector(cellSelector);

                if (cells != null) {
                    AddToList(ref listOfPage, ref cells);
                }


                


               
            }


           


        }

       


    }

        
}

