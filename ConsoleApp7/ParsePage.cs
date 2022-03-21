using AngleSharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class ParsePage
    {
        public async Task GetToyLink (string adress) {

            ParseProduct parseProduct = new ParseProduct();

         

            

            var config = Configuration.Default.WithDefaultLoader();   //парсинг имени
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(adress);

            var cellSelector = "div.row.mt-2 a";

            var cells = document.QuerySelectorAll(cellSelector); // ошибка

            List<String> links = new List<String>();
            

            foreach (var i in cells) {
                var pngLink = i.GetAttribute("href");
                links.Add(pngLink);
            }

            var smth= links.Distinct();

            Thread thread = Thread.CurrentThread;

            foreach (var i in smth) {
                Console.WriteLine(thread.ManagedThreadId);
                await Task.Run(() => parseProduct.ParseProd(i));
            }

            var pageSelector = "a.page-link";
            var nextPage =  document.QuerySelectorAll(pageSelector).Last();

          

            var strNextPage = nextPage.GetAttribute("href");
            //Console.WriteLine(strNextPage);
            if (strNextPage != "#") {
                await Task.Run(() => GetToyLink("https://www.toy.ru" + strNextPage));
            } 

           
            

            
            //nextPageParse.;

            


            //foreach (var i in links2) {
            //    Console.WriteLine(i);
            //    //await parseProduct.ParseProd(i);
            //}

        }
    }
}
