using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernateTestApp.DAL.PostgreSqlModel.Models
{
    public class CompanyDepartment
    {
        public virtual Int32 Id { get; set; }  
        public virtual Company Company { get; set; }
        public virtual Department Department { get; set; }
    }
}