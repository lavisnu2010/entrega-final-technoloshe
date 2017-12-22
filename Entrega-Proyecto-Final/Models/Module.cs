using Entrega_Proyecto_Final.Models;
using System.ComponentModel.DataAnnotations;

namespace Entrega_Proyecto_Final.Models
{
  public class Module
  {
    [Key]
    public int ID { get; set; }
    public string DescriptionModule { get; set; }
    public int CourseID { get; set; }
    public virtual Course Course { get; set; }
  }

}