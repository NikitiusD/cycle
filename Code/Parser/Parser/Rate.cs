using System;
using System.IO;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;

namespace Parser
{
    internal class Rate
    {
        public readonly double USDtoJPN;
        public readonly double USDtoRUB;
        public readonly double EURtoRUB;

        public Rate()
        {
            var calcCode = GetCalcCode();

            USDtoJPN = double.Parse(calcCode.QuerySelectorAll("span#usdjpy_curr")[0].TextContent.Replace('.', ','));
            USDtoRUB = double.Parse(calcCode.QuerySelectorAll("span#usd_curr")[0].TextContent.Replace('.', ','));
            EURtoRUB = double.Parse(calcCode.QuerySelectorAll("span#euro_curr")[0].TextContent.Replace('.', ','));
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
    }
}
