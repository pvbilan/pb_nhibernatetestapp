using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernateTestApp.DAL.PostgreSqlModel.Models
{
    public class Department
    {
        public virtual Int32 Id { get; set; }
        public virtual String Name { get; set; }
        public virtual IList<CompanyDepartment> CompanyDepartments { get; set; }
        public virtual IList<Duty> Duties { get; set; }
    }
}