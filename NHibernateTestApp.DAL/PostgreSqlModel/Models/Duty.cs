using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateTestApp.DAL.PostgreSqlModel.Models
{
    public class Duty
    {
        public virtual Int32 Id { get; set; }
        public virtual String Name { get; set; }
        public virtual String Description { get; set; }
        public virtual IList<Department> Departments { get; set; }
    }
}