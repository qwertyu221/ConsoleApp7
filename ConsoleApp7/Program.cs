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
        public static async Task Main (string[] args) {

            ParseProduct parse = new ParseProduct();

            await parse.ParseProd();
        }
    }
}
