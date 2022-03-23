using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Js;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        async public static Task Main (string[] args) {

            

            ParsePage parsePage = new ParsePage();


            string firstPage = "https://www.toy.ru/catalog/boy_transport/";

           

            await parsePage.GetToyLink(firstPage);
           
            

        }
    }
}
