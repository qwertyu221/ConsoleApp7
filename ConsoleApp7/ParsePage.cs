﻿using AngleSharp;
using AngleSharp.Js;

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
        async public Task GetToyLink(string adress) {

            


            //string adress = "https://www.toy.ru/catalog/boy_transport/";


            var config = Configuration.Default.WithDefaultLoader();   //парсинг имени
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(adress);

           

            var cellSelector = "div.row.mt-2 a";

            var cells = document.QuerySelectorAll(cellSelector); // получение списка товаров со страницы

            List<String> links = new List<String>();
            

            foreach (var i in cells) {
                var pngLink = i.GetAttribute("href");
                links.Add(pngLink);
            }

            var smth= links.Distinct(); // очистка повторяющихся ссылок

           

            foreach (var i in smth) {
                ParseProduct parseProduct = new ParseProduct(); // запуск чтения каждого товара со страницы
               
            
                await parseProduct.ParseProd(i);
            }

            var pageSelector = "a.page-link";
            var nextPage = document.QuerySelectorAll(pageSelector).Last(); // получение следующей страницы



            var strNextPage = nextPage.GetAttribute("href"); // пока кнопка активна происходит повторный вызов 
            Console.WriteLine(strNextPage);
            if (strNextPage != "#") {
                await GetToyLink("https://www.toy.ru" + strNextPage);
            }

            WriteCvs writeCvs = new WriteCvs();


            try {
                writeCvs.Push(); // окончательная запись в файл
            } catch {
                
                Console.WriteLine("Запись в файл уже произведена");
            }
            Console.WriteLine("done");



            //nextPageParse.;




            //foreach (var i in links2) {
            //    Console.WriteLine(i);
            //    //await parseProduct.ParseProd(i);
            //}

        }
    }
}
