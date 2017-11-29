using System;

namespace Parser
{
    class Cycle
    {
        private string cycleMark;
        private string cycleModel;
        private string run;
        private string year;
        private string price;
        private string color;
        private string volume;
        private string[] picturesList;

        public Cycle()
        {

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
