using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Parser
{
    class XMLdocument
    {
        private IEnumerable<Cycle> cycles;
        public XMLdocument(IEnumerable<Cycle> cycles)
        {
            this.cycles = cycles;
            CreateNewXML();
        }

        private void CreateNewXML()
        {
            var xdoc = new XDocument();
            var data = new XElement("data");
            var cars = new XElement("cars");
            foreach (var cycle in cycles)
            {
                var car = new XElement("car");
                car.Add(new XElement("mark_id", cycle.cycleMark));
                car.Add(new XElement("group_id", cycle.cycleModel));
                car.Add(new XElement("model_id", cycle.cycleModel));
                car.Add(new XElement("run", cycle.run));
                car.Add(new XElement("year", cycle.year));
                car.Add(new XElement("state", "Не требует ремонта"));
                car.Add(new XElement("availability", "На заказ"));
                car.Add(new XElement("currency", "RUR"));
                car.Add(new XElement("exchange", "Не интересует"));
                car.Add(new XElement("custom", "Растаможен"));
                car.Add(new XElement("price", cycle.price));
                car.Add(new XElement("color", cycle.color));
                car.Add(new XElement("description", "Мотоцикл представлен как образец на заказ. " +
                                                        "Качественный подбор, найдем мотоцикл под любой бюджет. " +
                                                        "Участвуем на всех мотоаукионах BDS, ARAI, JBA, NPA и других. " +
                                                        "Регулярная контейнерная доставка из Японии - для вас от 1 штуки по оптовой цене. " +
                                                        "Мотоцикл может быть доставлен в любой город РФ. " +
                                                        "Подробная информация о возможности заказа, условиях работы и оплаты на нашем сайте."));
                car.Add(new XElement("extras", "Электро стартер"));
                car.Add(new XElement("type", "Классик"));
                car.Add(new XElement("engine_volume", cycle.volume));
                car.Add(new XElement("haggle", "Возможен"));
                var images = new XElement("images");
                foreach (var picture in cycle.picturesList)
                    images.Add(new XElement("image", picture));
                car.Add(images);
                cars.Add(car);
            }
            data.Add(cars);
            xdoc.Add(data);
            xdoc.Save("cycles.xml");
        }
    }
}
