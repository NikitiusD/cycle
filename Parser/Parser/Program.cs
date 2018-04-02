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
            var pagesContent = new PagesContent("C:\\Projects\\cycle\\cycles.txt");

            var pageSourceCodeArray = pagesContent.Pages.ToArray();

            var cycles = pageSourceCodeArray.Select(GetPageCode).Select(CreateNewCycle).Select(x => x);

            foreach (var cycle in cycles)
                    Console.WriteLine(cycle);

            var xmlDocument = new XmlDocument(cycles);
            xmlDocument.CreateNewXml();

            Console.ReadKey();
        }

        private static Cycle CreateNewCycle(IHtmlDocument pageCode) => new Cycle(pageCode, Rate);

        private static IHtmlDocument GetPageCode(string pageSourceCode)
        {
            var document = pageSourceCode.Substring(pageSourceCode.IndexOf(
                "<table border=\"0\" cellpadding=\"4\" cellspacing=\"0\" class=\"Verdana12px\">"));
            document = document.Substring(0, document.IndexOf("</table></td><td valign=\"top\">"));
            var parser = new HtmlParser();
            var pageCode = parser.Parse(document);
            return pageCode;
        }
    }
}