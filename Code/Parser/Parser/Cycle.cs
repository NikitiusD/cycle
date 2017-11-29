using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;

namespace Parser
{
    class Cycle
    {
        private readonly Dictionary<string, double> rate;
        private readonly IHtmlDocument pageCode;
        public string cycleMark;
        public string cycleModel;
        public string run;
        public string year;
        public string price;
        public string color;
        public string volume;
        public string[] picturesList;

        public Cycle(IHtmlDocument pageCode, Dictionary<string, double> rate)
        {
            this.pageCode = pageCode;
            this.rate = rate;
            this.GetAllFields();
        }

        private void GetAllFields()
        {
            var info = pageCode.QuerySelectorAll("td.ColorCell_2").Select(e => e.TextContent).ToArray();
            var cycleInfo = new[] { info[1], info[4], info[8], info[9], info[12] };
            GetCycleName(pageCode);

            run = cycleInfo[1].Where(char.IsDigit).Aggregate("", (current, c) => current + c);
            year = cycleInfo[4];
            var cost = cycleInfo[3] + "000";
            volume = cycleInfo[2];
            GetPrice(int.Parse(cost));
            GetColor(cycleInfo[0]);
            GetPicturesLinks(pageCode);
        }

        private void GetPrice(int cost)
        {
            var custom = GetCustom(int.Parse(year), int.Parse(volume));
            var price = (((cost + 60500) / rate["USDtoJPN"] * 1.01 + custom * 0.4) * rate["USDtoRUB"] + 9000 + 0) * 1.1;
            price += 1000 - price % 1000;
            this.price = ((int)price).ToString();
        }

        private int GetCustom(int year, int volume)
        {
            if (volume <= 50)
            {
                switch (year)
                {
                    case 2015:
                    case 2016:
                        return 985;
                    case 2013:
                    case 2014:
                        return 611;
                    case 2011:
                    case 2012:
                        return 506;
                    case 2008:
                    case 2009:
                    case 2010:
                        return 410;
                    case 2005:
                    case 2006:
                    case 2007:
                        return 297;
                    case 2001:
                    case 2002:
                    case 2003:
                    case 2004:
                        return 297;
                    case 1997:
                    case 1998:
                    case 1999:
                    case 2000:
                        return 297;
                    default:
                        return 98;
                }
            }
            if (volume >= 51 && volume <= 100)
            {
                switch (year)
                {
                    case 2015:
                    case 2016:
                        return 1095;
                    case 2013:
                    case 2014:
                        return 804;
                    case 2011:
                    case 2012:
                        return 595;
                    case 2008:
                    case 2009:
                    case 2010:
                        return 503;
                    case 2005:
                    case 2006:
                    case 2007:
                        return 412;
                    case 2001:
                    case 2002:
                    case 2003:
                    case 2004:
                        return 316;
                    case 1997:
                    case 1998:
                    case 1999:
                    case 2000:
                        return 228;
                    default:
                        return 125;
                }
            }
            if (volume >= 101 && volume <= 200)
            {
                switch (year)
                {
                    case 2015:
                    case 2016:
                        return 1312;
                    case 2013:
                    case 2014:
                        return 978;
                    case 2011:
                    case 2012:
                        return 714;
                    case 2008:
                    case 2009:
                    case 2010:
                        return 598;
                    case 2005:
                    case 2006:
                    case 2007:
                        return 486;
                    case 2001:
                    case 2002:
                    case 2003:
                    case 2004:
                        return 407;
                    case 1997:
                    case 1998:
                    case 1999:
                    case 2000:
                        return 301;
                    default:
                        return 189;
                }
            }
            if (volume >= 201 && volume <= 300)
            {
                switch (year)
                {
                    case 2015:
                    case 2016:
                        return 2965;
                    case 2013:
                    case 2014:
                        return 2316;
                    case 2011:
                    case 2012:
                        return 1669;
                    case 2008:
                    case 2009:
                    case 2010:
                        return 1411;
                    case 2005:
                    case 2006:
                    case 2007:
                        return 1283;
                    case 2001:
                    case 2002:
                    case 2003:
                    case 2004:
                        return 1076;
                    case 1997:
                    case 1998:
                    case 1999:
                    case 2000:
                        return 828;
                    default:
                        return 465;
                }
            }
            if (volume >= 301 && volume <= 400)
            {
                switch (year)
                {
                    case 2015:
                    case 2016:
                        return 3205;
                    case 2013:
                    case 2014:
                        return 2741;
                    case 2011:
                    case 2012:
                        return 2616;
                    case 2008:
                    case 2009:
                    case 2010:
                        return 2156;
                    case 2005:
                    case 2006:
                    case 2007:
                        return 1532;
                    case 2001:
                    case 2002:
                    case 2003:
                    case 2004:
                        return 1308;
                    case 1997:
                    case 1998:
                    case 1999:
                    case 2000:
                        return 1091;
                    default:
                        return 618;
                }
            }
            if (volume >= 401 && volume <= 500)
            {
                switch (year)
                {
                    case 2015:
                    case 2016:
                        return 3631;
                    case 2013:
                    case 2014:
                        return 3086;
                    case 2011:
                    case 2012:
                        return 2711;
                    case 2008:
                    case 2009:
                    case 2010:
                        return 2289;
                    case 2005:
                    case 2006:
                    case 2007:
                        return 1836;
                    case 2001:
                    case 2002:
                    case 2003:
                    case 2004:
                        return 1475;
                    case 1997:
                    case 1998:
                    case 1999:
                    case 2000:
                        return 1315;
                    default:
                        return 742;
                }
            }
            if (volume >= 501 && volume <= 600)
            {
                switch (year)
                {
                    case 2015:
                    case 2016:
                        return 4289;
                    case 2013:
                    case 2014:
                        return 3621;
                    case 2011:
                    case 2012:
                        return 2789;
                    case 2008:
                    case 2009:
                    case 2010:
                        return 2337;
                    case 2005:
                    case 2006:
                    case 2007:
                        return 2016;
                    case 2001:
                    case 2002:
                    case 2003:
                    case 2004:
                        return 1711;
                    case 1997:
                    case 1998:
                    case 1999:
                    case 2000:
                        return 1356;
                    default:
                        return 903;
                }
            }
            if (volume >= 601 && volume <= 700)
            {
                switch (year)
                {
                    case 2015:
                    case 2016:
                        return 5016;
                    case 2013:
                    case 2014:
                        return 4091;
                    case 2011:
                    case 2012:
                        return 2929;
                    case 2008:
                    case 2009:
                    case 2010:
                        return 2481;
                    case 2005:
                    case 2006:
                    case 2007:
                        return 2196;
                    case 2001:
                    case 2002:
                    case 2003:
                    case 2004:
                        return 1739;
                    case 1997:
                    case 1998:
                    case 1999:
                    case 2000:
                        return 1412;
                    default:
                        return 938;
                }
            }
            if (volume >= 701 && volume <= 800)
            {
                switch (year)
                {
                    case 2015:
                    case 2016:
                        return 5867;
                    case 2013:
                    case 2014:
                        return 4751;
                    case 2011:
                    case 2012:
                        return 3013;
                    case 2008:
                    case 2009:
                    case 2010:
                        return 2631;
                    case 2005:
                    case 2006:
                    case 2007:
                        return 2304;
                    case 2001:
                    case 2002:
                    case 2003:
                    case 2004:
                        return 1791;
                    case 1997:
                    case 1998:
                    case 1999:
                    case 2000:
                        return 1466;
                    default:
                        return 1011;
                }
            }
            if (volume >= 801 && volume <= 900)
            {
                switch (year)
                {
                    case 2015:
                    case 2016:
                        return 6500;
                    case 2013:
                    case 2014:
                        return 5385;
                    case 2011:
                    case 2012:
                        return 4126;
                    case 2008:
                    case 2009:
                    case 2010:
                        return 3018;
                    case 2005:
                    case 2006:
                    case 2007:
                        return 2562;
                    case 2001:
                    case 2002:
                    case 2003:
                    case 2004:
                        return 1844;
                    case 1997:
                    case 1998:
                    case 1999:
                    case 2000:
                        return 1614;
                    default:
                        return 1076;
                }
            }
            if (volume >= 901 && volume <= 1000)
            {
                switch (year)
                {
                    case 2015:
                    case 2016:
                        return 7218;
                    case 2013:
                    case 2014:
                        return 6016;
                    case 2011:
                    case 2012:
                        return 4491;
                    case 2008:
                    case 2009:
                    case 2010:
                        return 3115;
                    case 2005:
                    case 2006:
                    case 2007:
                        return 2617;
                    case 2001:
                    case 2002:
                    case 2003:
                    case 2004:
                        return 1911;
                    case 1997:
                    case 1998:
                    case 1999:
                    case 2000:
                        return 1676;
                    default:
                        return 1214;
                }
            }
            if (volume >= 1001 && volume <= 1100)
            {
                switch (year)
                {
                    case 2015:
                    case 2016:
                        return 7765;
                    case 2013:
                    case 2014:
                        return 6411;
                    case 2011:
                    case 2012:
                        return 4784;
                    case 2008:
                    case 2009:
                    case 2010:
                        return 3201;
                    case 2005:
                    case 2006:
                    case 2007:
                        return 2817;
                    case 2001:
                    case 2002:
                    case 2003:
                    case 2004:
                        return 2036;
                    case 1997:
                    case 1998:
                    case 1999:
                    case 2000:
                        return 1784;
                    default:
                        return 1296;
                }
            }
            if (volume >= 1101 && volume <= 1300)
            {
                switch (year)
                {
                    case 2015:
                    case 2016:
                        return 8569;
                    case 2013:
                    case 2014:
                        return 6996;
                    case 2011:
                    case 2012:
                        return 5011;
                    case 2008:
                    case 2009:
                    case 2010:
                        return 3265;
                    case 2005:
                    case 2006:
                    case 2007:
                        return 3016;
                    case 2001:
                    case 2002:
                    case 2003:
                    case 2004:
                        return 2161;
                    case 1997:
                    case 1998:
                    case 1999:
                    case 2000:
                        return 1914;
                    default:
                        return 1368;
                }
            }
            if (volume >= 1301 && volume <= 1500)
            {
                switch (year)
                {
                    case 2015:
                    case 2016:
                        return 9486;
                    case 2013:
                    case 2014:
                        return 7416;
                    case 2011:
                    case 2012:
                        return 5953;
                    case 2008:
                    case 2009:
                    case 2010:
                        return 3972;
                    case 2005:
                    case 2006:
                    case 2007:
                        return 3291;
                    case 2001:
                    case 2002:
                    case 2003:
                    case 2004:
                        return 2424;
                    case 1997:
                    case 1998:
                    case 1999:
                    case 2000:
                        return 1939;
                    default:
                        return 1407;
                }
            }
            else
            {
                switch (year)
                {
                    case 2015:
                    case 2016:
                        return 10616;
                    case 2013:
                    case 2014:
                        return 8091;
                    case 2011:
                    case 2012:
                        return 6738;
                    case 2008:
                    case 2009:
                    case 2010:
                        return 5396;
                    case 2005:
                    case 2006:
                    case 2007:
                        return 3927;
                    case 2001:
                    case 2002:
                    case 2003:
                    case 2004:
                        return 2561;
                    case 1997:
                    case 1998:
                    case 1999:
                    case 2000:
                        return 2031;
                    default:
                        return 1466;
                }
            }
        }

        private void GetColor(string cycleInfo)
        {
            var colorSet = new Dictionary<string, string>
            {
                {"BEIGE", "Бежевый"},
                {"WHITE", "Белый"},
                {"BLUE", "Синий"},
                {"YELLOW", "Желтый"},
                {"GREEN", "Зеленый"},
                {"GOLD", "Золотой"},
                {"BROWN", "Коричневый"},
                {"RED", "Красный"},
                {"ORANGE", "Оранжевый"},
                {"PURPLE", "Фиолетовый"},
                {"PINK", "Розовый"},
                {"SILVER", "Серебряный"},
                {"GRAY", "Серый"},
                {"VIOLET", "Фиолетовый"},
                {"BLACK", "Черный"},
                {"CREAM", "Бежевый"},
                {"GUNMETAL", "Серый"},
                {"WINE", "Красный"}
            };
            color = "";
            var colors = cycleInfo.Split('/', '|', ' ');
            foreach (var colo in colors)
            {
                foreach (var col in colorSet)
                {
                    if (col.Key == colo)
                        color = col.Value;
                }
            }

            if (color == "") Console.WriteLine($"Can't identify color at {cycleMark} {cycleModel} {year}");
        }

        private void GetCycleName(IHtmlDocument pageCode)
        {
            var cycleName = pageCode.QuerySelectorAll("div.Verdana16px").Select(e => e.TextContent).ToArray()[1].Split('\u00A0');
            cycleMark = cycleName[0];
            cycleModel = cycleName[1].ToLower().Contains(cycleMark.ToLower())
                ? cycleName[1].Remove(cycleName[1].ToLower().IndexOf(cycleMark.ToLower()), cycleMark.Length + 1)
                : cycleName[1];

            var k = new List<int>();
            for (var i = 0; i < cycleModel.Length; i++)
                if (char.IsDigit(cycleModel[i]))
                    k.Add(i);

            cycleModel = cycleModel.Substring(0, k[0]) + " " + cycleModel.Substring(k[0], k.Last() - k[0] + 1) + " " + cycleModel.Substring(k.Last() + 1);
            cycleModel = cycleModel.Replace("  ", " ");
        }

        private void GetPicturesLinks(IHtmlDocument doc)
        {
            var imagesCode = doc.QuerySelectorAll("img").Where(item => item.Id != null && item.Id.Contains("url_img_")).ToArray();
            List<string> picturesLinksList = new List<string>();
            picturesLinksList.AddRange(imagesCode.Select(element => element.GetAttribute("load_src")));
            picturesLinksList.RemoveAt(0);
            picturesList = picturesLinksList.ToArray();
        }

        public Cycle(string cycleMark, string cycleModel, string run, string year, string price, string color, string volume, string[] picturesList)
        {
            this.cycleMark = cycleMark;
            this.cycleModel = cycleModel;
            this.run = run;
            this.year = year;
            this.price = price;
            this.color = color;
            this.volume = volume;
            this.picturesList = picturesList;
        }

        public override string ToString()
        {
            return $"Cycle Mark: {cycleMark}\nCycle Model: {cycleModel}\nRun: {run} km\nYear: {year}\nPrice: {price}\nColor: {color}\nVolume: {volume}\nPictures: {picturesList.Length}\n";
        }
    }
}
