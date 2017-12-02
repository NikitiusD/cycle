using System;
using System.Linq;
using System.IO;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;

namespace Parser
{
    class Program
    {
        private static readonly Rate Rate = new Rate();

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter something if you want to test\nOtherwise just press Enter");
            var isTest = !string.IsNullOrEmpty(Console.ReadLine());

            var pagesContent = isTest
                ? new PagesContent("C:\\Projects\\Moto\\cycles_test.txt")
                : new PagesContent("C:\\Projects\\Moto\\cycles.txt");

            var pageSourceCodeArray = pagesContent.Pages.ToArray();

            var cycles = pageSourceCodeArray.Select(GetPageCode).Select(CreateNewCycle);

            if (isTest)
                foreach (var cycle in cycles)
                    Console.WriteLine(cycle);

            var doc = new XMLDocument(cycles);

            if (isTest) Console.ReadKey();
        }

        private static Cycle CreateNewCycle(IHtmlDocument pageCode) => new Cycle(pageCode, Rate);

        private static IHtmlDocument GetPageCode(string pageSourceCode)
        {
            var document = pageSourceCode.Substring(pageSourceCode.IndexOf("<table border=\"0\" cellpadding=\"4\" cellspacing=\"0\" class=\"Verdana12px\">"));
            document = document.Substring(0, document.IndexOf("</table></td><td valign=\"top\">"));
            var parser = new HtmlParser();
            var pageCode = parser.Parse(document);
            return pageCode;
        }
    }
}