﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;

namespace Parser
{
    class Program
    {
        private static readonly Dictionary<string, double> Rate = GetRate();

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter \"test\" if you want to test\nOtherwise just press Enter");
            var isTest = !string.IsNullOrEmpty(Console.ReadLine());
            var pageSourceCodeArray = isTest
                ? Directory.GetFiles(@"C:\Projects\Moto\HTMLsTest", "*.html")
                : Directory.GetFiles(@"C:\Projects\Moto\HTMLs", "*.html");
            //var pageSourceCodeArray = Directory.GetFiles(@"C:\Projects\Moto\HTMLsTest", "*.html");
            //var pageSourceCodeArray = Directory.GetFiles(@"C:\Projects\Moto\HTMLs", "*.html");

            var cycles = pageSourceCodeArray.Select(GetPageCode).Select(CreateNewCycle);

            foreach (var cycle in cycles)
                Console.WriteLine(cycle);

            var doc = new XMLDocument(cycles);
        }

        private static Cycle CreateNewCycle(IHtmlDocument pageCode) => new Cycle(pageCode, Rate);

        private static Dictionary<string, double> GetRate()
        {
            var calcCode = GetCalcCode();

            var USDtoJPN = calcCode.QuerySelectorAll("span#usdjpy_curr")[0].TextContent;
            var USDtoRUB = calcCode.QuerySelectorAll("span#usd_curr")[0].TextContent;
            var EURtoRUB = calcCode.QuerySelectorAll("span#euro_curr")[0].TextContent;

            var rate = new Dictionary<string, double>
            {
                {"USDtoJPN", double.Parse(USDtoJPN.Replace('.', ','))},
                {"USDtoRUB", double.Parse(USDtoRUB.Replace('.', ','))},
                {"EURtoRUB", double.Parse(EURtoRUB.Replace('.', ','))}
            };

            return rate;
        }

        private static IHtmlDocument GetCalcCode()
        {
            Console.WriteLine("Please enter the relative from \"C:\\Projects\\Moto\\HTMLs\" path\nto the newcalc.html file\nIf it's \"1_files\" then just press Enter");
            var newcalcPath = Console.ReadLine();
            const string absolutePathToNewCalc = "C:\\Projects\\Moto\\HTMLs\\";
            var calcSourceCode = string.IsNullOrEmpty(newcalcPath)
                        ? Directory.GetFiles($"{absolutePathToNewCalc}1_files", "newcalc.html")[0]
                        : Directory.GetFiles($"{absolutePathToNewCalc}{newcalcPath}", "newcalc.html")[0];
            var document = File.ReadAllText(calcSourceCode);
            var parser = new HtmlParser();
            var calcCode = parser.Parse(document);
            return calcCode;
        }

        private static IHtmlDocument GetPageCode(string pageSourceCode)
        {
            var document = File.ReadAllText(pageSourceCode);
            document = document.Substring(document.IndexOf("<table border=\"0\" cellpadding=\"4\" cellspacing=\"0\" class=\"Verdana12px\"><tbody>"));
            document = document.Substring(0, document.IndexOf("</table></td><td valign=\"top\">"));
            var parser = new HtmlParser();
            var pageCode = parser.Parse(document);
            return pageCode;
        }
    }
}