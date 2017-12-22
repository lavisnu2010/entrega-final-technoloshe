using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entrega_Proyecto_Final.ViewModels
{
  public class CursoViewModel
  {
    public int ID { get; set; }
    public string DescriptionCourse { get; set; }

    public List<ModuloViewModel> modules = new List<ModuloViewModel>();
  }

  public class ModuloViewModel
  {
    public string DescriptionModule { get; set; }

  }
}