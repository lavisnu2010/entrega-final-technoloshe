using Entrega_Proyecto_Final.Models;
using System.Web.Mvc;

namespace Entrega_Proyecto_Final.Controllers
{
  public class TestController : Controller
  {
    UserContext db = new UserContext();

    // GET: Test
    public ActionResult AddUser(string mail, string password)
    {
      User newUser = new User();
      newUser.Mail = mail;
      newUser.Password = password;

      db.Users.Add(newUser);
      db.SaveChanges();

      return Json(newUser, JsonRequestBehavior.AllowGet);
    }
  }
}