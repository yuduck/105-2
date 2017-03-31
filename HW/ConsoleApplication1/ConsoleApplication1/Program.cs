using Models;
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
                Console.WriteLine("第"+j+"筆資料");
                Console.WriteLine("標題："+musics[j].title);
                Console.WriteLine("位置："+musics[j].name);
                Console.WriteLine("開始時間："+musics[j].starttime);
                Console.WriteLine("結束時間："+musics[j].endtime);
                Console.WriteLine("價錢："+musics[j].price);
                //Console.WriteLine("----------------");
            }
            Console.WriteLine("----------------");
            Console.WriteLine("按下任一鍵進行新增資料庫");
            Console.ReadKey();
            InsertMusic(musics);
            Console.ReadLine();

        }
        public static List<music> FindMusics()
        {
            List<music> musics = new List<music>();
            var xml = XElement.Load(@"D:\105-2\HW\music.xml");
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
                  musicData.starttime = starttime;
                  musicData.endtime = endtime;
                  musicData.create = DateTime.Now;
                  musics.Add(musicData);
              });
            return musics;

        }
        public static void InsertMusic(List<music> musics)
        {
            Data.Data db = new Data.Data();


            Console.WriteLine(string.Format("新增{0}筆監測站的資料開始", musics.Count));
            musics.ForEach(x =>
            {

                db.Createtitle(x);


            });
            Console.WriteLine(string.Format("新增音樂的資料結束"));


        }

    }
}
