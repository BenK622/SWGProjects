using MediaFileSpike2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaFileSpike2.Controllers
{
    public class AudioController : Controller
    {
        // GET: Audio
        public ActionResult Index()
        {
            
            AudioFileModel file = new AudioFileModel();

            //  file.filePath = @"http://www.talkingwav.com/music_mp3/guitar10.mp3";

            var filename = @"/Audio/guitar.mp3";
        

           // var filename = @"\terminated.wav";

            file.filePath = filename;

            return View(file);
        }
    }
}