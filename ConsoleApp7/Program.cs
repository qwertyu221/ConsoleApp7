using AngleSharp;
using AngleSharp.Dom;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        public static async Task Main (string[] args) {

            //ParseProduct parse = new ParseProduct();

            //await parse.ParseProd();

            //await PrintAsync();   // вызов асинхронного метода
            //Console.WriteLine("Некоторые действия в методе Main");


            //void Print () {
            //    Thread.Sleep(1000);     // имитация продолжительной работы
            //    Console.WriteLine("Hello METANIT.COM");
            //}

            //// определение асинхронного метода
            //async Task PrintAsync () {
            //    Console.WriteLine("Начало метода PrintAsync"); // выполняется синхронно
            //    await Task.Run(() => Print());                // выполняется асинхронно
            //    Console.WriteLine("Конец метода PrintAsync");
            //}

            ParsePage parsePage = new ParsePage();


            String firstPage = "https://www.toy.ru/catalog/boy_transport/";

            await parsePage.GetToyLink(firstPage);

        }
    }
}
