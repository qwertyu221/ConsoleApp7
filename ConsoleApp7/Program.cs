using AngleSharp;
using AngleSharp.Dom;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        async static Task Main (string[] args) {

            List<String> listOfPage = new List<string>();

            //var config = Configuration.Default.WithDefaultLoader();
            //var address = "https://en.wikipedia.org/wiki/List_of_The_Big_Bang_Theory_episodes";
            //var context = BrowsingContext.New(config);
            //var document = await context.OpenAsync(address);
            //var cellSelector = "td:nth-child(3)";
            //var cells = document.QuerySelectorAll(cellSelector);
            //var titles = cells.Select(m => m.TextContent);



            //foreach (var i in titles) {
            //    Console.WriteLine(i.ToString());
            //}

            await TakeInfoAsync("h1.detail-name");
            await TakeInfoAsync("span.price");
            await TakeInfoAsync("span.ok");

            foreach (var i in listOfPage) {
                Console.WriteLine(i);
            }


            void AddToList (ref List<String> listOfPage, ref String cells) {

                listOfPage.Add(cells);
            }

            async Task TakeInfoAsync (string cellSelector) {

               
                var config = Configuration.Default.WithDefaultLoader();   //парсинг имени
                var address = "https://www.toy.ru/catalog/mashinki_iz_multfilmov/fortnite_fnt0163_mashina_quadcrasher/";
                var context = BrowsingContext.New(config);
                var document = await context.OpenAsync(address);

                var cells = document.QuerySelector(cellSelector).TextContent;
                AddToList(ref listOfPage, ref cells);


                //foreach (var i in listOfPage) {
                //    Console.WriteLine(i);
                //}
            }
        }
    }
}
