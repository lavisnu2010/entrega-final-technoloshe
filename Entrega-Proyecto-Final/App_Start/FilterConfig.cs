﻿using System.Web;
using System.Web.Mvc;

namespace Entrega_Proyecto_Final
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
