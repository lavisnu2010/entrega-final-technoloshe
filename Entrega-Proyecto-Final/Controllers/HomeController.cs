using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Entrega_Proyecto_Final.Models;
using System.Net;
using System.Net.Mail;

namespace Entrega_Proyecto_Final.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db = new UserContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Teachers()
        {
            ViewBag.Message = "Your teachers page.";

            return View();
        }

        public ActionResult Pricing(int idUser)
        {
            User user = db.Users.FirstOrDefault(u => u.ID.Equals(idUser));
            if (user != null)
            {
                Session["LoggedUser"] = user;
                ViewBag.UserID = user.ID;
                var courses = db.Courses.ToList();
                ViewBag.Courses = courses;
                return View(user);
            }

            return View(db.Users.Where(u => u.ID == idUser));
        }





        public ActionResult Courses()
        {
            var Courses = db.Courses.Include(a => a.Modules).ToList();
            return View(Courses);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult ReceiveContact(string nombre, string mail, string telefono, string mensaje)
        {
            ViewBag.Nombre = nombre;
            ViewBag.Mail = mail;
            ViewBag.Telefono = telefono;
            ViewBag.Mensaje = mensaje;

            //Definimos la conexión al servidor SMTP que vamos a usar
            //para mandar el mail. Hay que buscar como es en nuestro proveedor.
            SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
            clienteSmtp.Credentials = new NetworkCredential("reiseleiter.tours@gmail.com", "martinez1234");
            clienteSmtp.EnableSsl = true;

            //Generamos el objeto MAIL a enviar
            MailMessage mailParaAdministrador = new MailMessage();
            mailParaAdministrador.From = new MailAddress("reiseleiter.tours@gmail.com", "Cotáctenos");
            mailParaAdministrador.To.Add("reiseleiter.tours@gmail.com");
            mailParaAdministrador.Subject = "Nuevo contacto";
            mailParaAdministrador.Body = "Te contactó: " + nombre + "(" + mail + ") Nro. de teléfono: " + telefono + ".\nSu mensaje fue: " + mensaje;

            //mandamos el mail
            clienteSmtp.Send(mailParaAdministrador);

            //vamos a mandarle un mail al usuario que nos dejó el contacto
            MailMessage mailAUsuario = new MailMessage();
            mailAUsuario.From = new MailAddress("reiseleiter.tours@gmail.com", "Test ComunidadIT");
            mailAUsuario.To.Add(mail);
            mailAUsuario.Subject = "Gracias por contactarte con nosotros!";
            mailAUsuario.IsBodyHtml = true;
            mailAUsuario.Body = "Hola <b>" + nombre + "</b>!<br>Gracias por contactarte con nosotros!<br>Te responderemos a la brevedad.<br>Nos dejaste los siguientes datos:<br>Mail: " + mail + "<br>Mensaje: " + mensaje + "<br><br>Saludos!!!<br><b>La mejor APP</b><img src=\"https://maspublicidades.com/wp-content/uploads/2017/03/contacto.jpg\" />";

            //usamos el mismo objeto cliente smtp que creamos antes
            clienteSmtp.Send(mailAUsuario);

            return View("Gracias");
        }

    }
}