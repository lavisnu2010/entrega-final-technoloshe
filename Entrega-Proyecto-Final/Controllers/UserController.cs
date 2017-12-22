using System.Data;
using System.Linq;
using System.Web.Mvc;
using Entrega_Proyecto_Final.Models;

namespace Entrega_Proyecto_Final.Controllers
{
  public class UserController : Controller
  {
    private UserContext db = new UserContext();

    // GET: User
    public ActionResult Details(int idUser)
    {
      User user = db.Users.FirstOrDefault(u => u.ID.Equals(idUser));
      if (user != null)
      {
        Session["LoggedUser"] = user;
        ViewBag.UserID = user.ID;
        return View(user);
      }

      return View(db.Users.Where(u => u.ID == idUser));
    }

    public ActionResult UserInscriptions(int idUser)
    {
      var inscriptions = db.Inscriptions.Where(u => u.UserID == idUser).ToList();

      ViewBag.Inscriptions = inscriptions;
      ViewBag.UserID = idUser;
      return View();
    }

    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public ActionResult DoLogin(string mail, string password)
    {
      //buscamos al usuario
      User user = db.Users.FirstOrDefault(u => u.Mail.Equals(mail));
      if (user != null && user.Password.Equals(password)) //si existe (no queda null) y la contraseña coincide
      {
        Session["LoggedUser"] = user; //agregamos el objeto usuario a la sesión, para después tener control sobre él
        return RedirectToAction("Details", "User", new { idUser = user.ID });
      }
      //si no existe el usuario o lo contraseña no coincide
      return RedirectToAction("Login", "User");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
