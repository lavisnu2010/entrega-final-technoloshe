using System.ComponentModel.DataAnnotations;

namespace Entrega_Proyecto_Final.Models
{
  public class User
  {
    [Key]
    public int ID { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
    public string CompleteName { get; set; }
  }

}