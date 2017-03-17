using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var musics = FindMusics();

            for (var j = 0; j < musics.Count; j++) {
                Console.WriteLine("----------------");
                Console.WriteLine(musics[j].title);
                Console.WriteLine(musics[j].name);
                Console.WriteLine(musics[j].startname);
                Console.WriteLine(musics[j].endname);
                Console.WriteLine(musics[j].price);
                Console.WriteLine(musics[j].create);
                Console.WriteLine("----------------");

            }
            Console.ReadLine();

        }
        public static List<music> FindMusics()
        {
            List<music> musics = new List<music>();
            var xml = XElement.Load(@"D:\0317\HW\music.xml");
            var musictitle = xml.Descendants("Info").ToList();
            for (var i = 0; i < musictitle.Count(); i++) {
                //musictitle[i]

                var musicNode = musictitle[i];
            }
            musictitle.Where(x => !x.IsEmpty).ToList().ForEach(musicNode =>
              {
                  var title = musicNode.Attribute("title").Value.Trim();
                  var price= musicNode.Element("showInfo").Element("element").Attribute("price").Value.Trim();
                  var name = musicNode.Element("showInfo").Element("element").Attribute("locationName").Value.Trim();
                  var starttime = musicNode.Element("showInfo").Element("element").Attribute("time").Value.Trim();
                  var endtime = musicNode.Element("showInfo").Element("element").Attribute("endTime").Value.Trim();
                  music musicData = new music();
                  musicData.title = title;
                  musicData.price = price;
                  musicData.name = name;
                  musicData.startname = starttime;
                  musicData.endname = endtime;
                  musicData.create = DateTime.Now;
                  musics.Add(musicData);
              });
            return musics;

        }

    }
}
