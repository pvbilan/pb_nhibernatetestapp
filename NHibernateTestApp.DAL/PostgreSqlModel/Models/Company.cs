using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernateTestApp.DAL.PostgreSqlModel.Models
{
    public class Company
    {
        public virtual Int32 Id { get; set; }
        public virtual String Name { get; set; }
        public virtual String Description { get; set; }
        public virtual Int32 DepartmentsCount { get; set; }
        public virtual IList<CompanyDepartment> CompanyDepartments { get; set; }
    }
}