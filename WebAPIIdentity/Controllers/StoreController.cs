using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebAPIIdentity.Models;

namespace WebAPIIdentity.Controllers
{
    public class StoreController : Controller
    {
        public ActionResult Index()
        {
            var albums = GetAlbums();

            return View(albums);
        }

        [Authorize]
        public ActionResult Buy(int id)
        {
            var album = GetAlbums().Single(a => a.AlbumId == id);
            string str = User.Identity.Name;
            string str1 = User.Identity.GetUserId();
            string str2 = User.Identity.GetUserName();
            //Charge the user and ship the album!!!
            return View(album);
        }

        // A simple music catalog
        private static List<Album> GetAlbums()
        {
            var albums = new List<Album>{
                new Album { AlbumId = 1, Title = "The Fall of Math", Price = 8.99M},
                new Album { AlbumId = 2, Title = "The Blue Notebooks", Price = 8.99M},
                new Album { AlbumId = 3, Title = "Lost in Translation", Price = 9.99M },
                new Album { AlbumId = 4, Title = "Permutation", Price = 10.99M },
            };
            return albums;
        }
    }
}
