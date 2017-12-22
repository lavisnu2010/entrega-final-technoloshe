using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Entrega_Proyecto_Final.Models
{

  public class UserContext : DbContext
  {
    /// <summary>
    /// El nombre que se especifica en el contructor padre, 
    /// es el que después se usa en el web.config para conectar
    /// a la base de datos
    /// </summary>
    public UserContext() :
        base("UserContext")
    {

    }


    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {

    }

    /// <summary>
    /// Colección para poder administrar Series en la base de datos
    /// </summary>
    public DbSet<Course> Courses { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Inscription> Inscriptions { get; set; }
    public DbSet<User> Users { get; set; }

  }
}
