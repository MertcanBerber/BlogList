using AksamWeb.DataOperations;
using AksamWeb.DataOperations.Entities;
using AksamWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AksamWeb.Controllers
{
    public class MainController : Controller
    {
        AksamEf database;
        public MainController(AksamEf ef)
        {
            database = ef;
        }
        public IActionResult Delete(string id) {

            
            var kayit = database.BlogPosts.FirstOrDefault(p=>p.Id == Convert.ToInt32(id));
            if (kayit == null)
                return RedirectToAction("Default");

            database.BlogPosts.Remove(kayit);

            database.SaveChanges();
            return RedirectToAction("Default");

        }
        public IActionResult Guncelle(string id)
        {


            var kayit = database.BlogPosts.FirstOrDefault(p => p.Id == Convert.ToInt32(id));
            if (kayit == null)
                return RedirectToAction("Default");

            return View(kayit);


        }
        [HttpPost]
        public IActionResult Guncelle(BlogPost model)
        {
            database.BlogPosts.Update(model);
            database.SaveChanges();
            return RedirectToAction("Default");
        }
        public IActionResult Default()
        {
            List<BlogListViewModel> liste = database.BlogPosts.Select(
                p=>new BlogListViewModel() { 
                    CreateDate = p.CreatedOn.ToString("dd-MM-yyyy"),
                    Description = p.Description.Length>25 ? p.Description.Remove(25) : p.Description,
                    Id = p.Id,
                    IsActive = p.IsActive == true ? "Kayıt yayında" : "Kayıt Yayında Değil",
                    Title = p.Title.ToUpper()
                }
                ).ToList();

            return View(liste);
        }
        public IActionResult AddBlog() {
            var bavm = new BlogAddViewModel();
            return View(bavm);
        }
        [HttpPost]
        public IActionResult AddBlog(BlogAddViewModel model)
        {

            if (ModelState.IsValid) {
                var bp = new BlogPost();
                bp.IsActive = false;
                bp.CreatedOn = DateTime.Now;
                bp.Title = model.Title;
                bp.Description = model.Description;
                bp.Content = model.Content;

                database.BlogPosts.Add(bp);

                database.SaveChanges();
            }

            return View(model);
        }
    }
}
