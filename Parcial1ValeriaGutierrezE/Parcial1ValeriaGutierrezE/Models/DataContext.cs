using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Parcial1ValeriaGutierrezE.Models
{
    public class DataContext : DbContext
    {
        public System.Data.Entity.DbSet<Parcial1ValeriaGutierrezE.Models.gutierrez> gutierrezs { get; set; }
    }
}