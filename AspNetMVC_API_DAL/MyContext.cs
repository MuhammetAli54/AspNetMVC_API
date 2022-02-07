using AspNetMVC_API_Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetMVC_API_DAL
{
    public class MyContext:DbContext
    {
        public MyContext() 
            : base("name=MyCon")
        {

        }

        public virtual DbSet<Student> Students { get; set; }
    }
}
