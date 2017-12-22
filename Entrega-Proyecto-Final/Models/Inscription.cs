using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entrega_Proyecto_Final.Models
{
  public class Inscription
  {
    [Key]
    public int ID { get; set; }
    public int CourseID { get; set; }
    public int UserID { get; set; }
    public string DescriptionCourse { get; set; }
  }
}