using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            var music_data = new Data.Data();
            var music = music_data.ReadMusic();
            var message = string.Format("收到{0}筆音樂的資料<br/><br/>", music.Count);

            music.ForEach(x =>
            {
                message += string.Format("標題：{0}<br/>位置:{1}<br/>開始時間：{2}<br/>結束時間:{3}<br/>價錢：{4}<br/>建立時間:{5}<br/><br/>", x.title, x.name,x.starttime, x.endtime, x.price, x.create);

            });
            return Content(message);

        }
    }
}