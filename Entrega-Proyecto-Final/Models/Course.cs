using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entrega_Proyecto_Final.Models
{
  public class Course
  {
    [Key]
    public int ID { get; set; }
    public string DescriptionCourse { get; set; }

    public virtual ICollection<Module> Modules { get; set; }
  }
}