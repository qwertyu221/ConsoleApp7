using AngleSharp;
using AngleSharp.Dom;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class ParseProduct
    {
        async public Task ParseProd(string adress) {

        

            List<string> listOfPage = new List<string>();

            List<string> listOfpng = new List<string>();

            adress = "https://www.toy.ru" + adress;

            //var adress = "https://www.toy.ru/catalog/mashinki_iz_multfilmov/fortnite_fnt0163_mashina_quadcrasher/";


            var config = Configuration.Default.WithDefaultLoader();   //парсинг имени
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(adress);

            TakeInfoAsync("nav.breadcrumb");
            TakeInfoAsync("h1.detail-name");
            TakeInfoAsync("span.old-price");
            TakeInfoAsync("span.price");
            TakeInfoAsync("span.ok");
            TakeInfoAsync("div.col-12.select-city-link a");
            TakeInfoAsync("div.col-12.col-md-10.col-lg-7");
            TakePngAsync("img.img-fluid");

            WriteCvs writeCvs = new WriteCvs();

            writeCvs.Writeinfile(listOfPage, listOfpng, adress);

            //foreach (var i in listOfPage) {
            //    Console.WriteLine(i);
            //}

            void AddToList (string cells) {
                //Console.WriteLine(cells.TextContent.Trim());
                listOfPage.Add(cells);
            }

            void TakeInfoAsync (string cellSelector) {
                var cells = document.QuerySelector(cellSelector);

                if (cells != null) {
                    AddToList(cells.TextContent.Trim());
                } else {
                    AddToList(" ");
                }        
            }

            void TakePngAsync (string cellSelector) {
                
                var cells = document.QuerySelectorAll(cellSelector);
                 
                foreach (var i in cells) { 
                    var pngLink = i.Attributes["src"].Value;
                    listOfpng.Add(pngLink);
                    //Console.WriteLine(pngLink); 
                }

            }
        }
    }
}

