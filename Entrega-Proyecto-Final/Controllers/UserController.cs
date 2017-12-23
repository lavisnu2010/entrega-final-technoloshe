using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity; //agregue este
using Entrega_Proyecto_Final.Models;
using System.Net; //agregue este
using System.Net.Mail; //agregue este

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
                return RedirectToAction("Pricing", "Home", new { idUser = user.ID });
            }
            //si no existe el usuario o lo contraseña no coincide
            return RedirectToAction("Login", "User");
        }

        public ActionResult AddInscription(int idUser, int idCourse)
        {
            Inscription insc = new Inscription();
            insc.UserID = idUser;
            insc.CourseID = idCourse; 
            var user = db.Users.Where(u => u.ID == idUser);

            db.Inscriptions.Add(insc);
            db.SaveChanges();


            /*
            //Definimos la conexión al servidor SMTP que vamos a usar
            //para mandar el mail. Hay que buscar como es en nuestro proveedor.
            SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
            clienteSmtp.Credentials = new NetworkCredential("reiseleiter.tours@gmail.com", "martinez1234");
            clienteSmtp.EnableSsl = true;

            //Generamos el objeto MAIL a enviar
            MailMessage mailParaAdministrador = new MailMessage();
            mailParaAdministrador.From = new MailAddress("reiseleiter.tours@gmail.com", "inscripción");
            mailParaAdministrador.To.Add("reiseleiter.tours@gmail.com");
            mailParaAdministrador.Subject = "Nueva inscripción Curso";
            mailParaAdministrador.Body = "Nueva inscripción con exito: " + idCourse;

            //mandamos el mail
            clienteSmtp.Send(mailParaAdministrador);
            */

            TempData["Message"] = "Gracias por haberse inscripto! Nos contactaremos a la brevedad";
            return RedirectToAction("Details", "User", new { idUser = idUser });
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
