using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet.Net;

namespace Parser
{
    class PagesContent
    {
        public readonly List<string> Pages = new List<string>();
        private readonly string path;

        public PagesContent(string path)
        {
            this.path = path;
            GetPages();
        }

        private void GetPages()
        {
            var urls = File.ReadAllLines(path);

            using (var request = new HttpRequest())
            {
                request.UserAgent = HttpHelper.RandomChromeUserAgent();
                var response = request.Get("http://auc.samurai-motor.ru/auth/login.php");
                request.Cookies = response.Cookies;
                request.Post("http://auc.samurai-motor.ru/auth/login.php", 
                                        "username=105951650&password=123456&Submit=%D0%92%D0%BE%D0%B9%D1%82%D0%B8");
                foreach (var url in urls)
                    Pages.Add(request.Get(url).ToString());
            }
        }
    }
}
