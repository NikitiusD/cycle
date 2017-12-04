using System;
using System.IO;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using xNet.Net;

namespace Parser
{
    internal class Rate
    {
        public readonly double USDtoJPN;
        public readonly double USDtoRUB;

        public Rate()
        {
            var calcCode = GetRate("https://news.yandex.ru/quotes/7.html");
            USDtoJPN = double.Parse(calcCode.QuerySelectorAll("td.quote__value")[0].TextContent);
            calcCode = GetRate("https://news.yandex.ru/quotes/1.html");
            USDtoRUB = double.Parse(calcCode.QuerySelectorAll("td.quote__value")[0].TextContent);
        }

        private static IHtmlDocument GetRate(string url)
        {
            string document;
            using (var request = new HttpRequest())
            {
                request.UserAgent = HttpHelper.RandomChromeUserAgent();
                var response = request.Get(url);
                document = response.ToString();
            }
            var parser = new HtmlParser();
            var calcCode = parser.Parse(document);
            return calcCode;
        }
    }
}
