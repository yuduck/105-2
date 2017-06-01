using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
namespace web.Controllers
{
    public class musicController : Controller
    {
        // GET: music
        public ActionResult Index(string search = "")
        {
            var musicRepository = new Data.Data();

            var musics = musicRepository.ReadMusic();
            if (!string.IsNullOrEmpty(search))
                musics = musics
                    .Where(x =>
                    x.title.Contains(search) ||
                    x.name.Contains(search))
                    .ToList();
            ViewBag.Search = search;
            //ViewBag.Stations = stations;

            return View(musics);
        }
    }
}