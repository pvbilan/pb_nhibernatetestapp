using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernateTestApp.DAL.PostgreSqlModel.Models
{
    public class CompanyDepartmentsCountView
    {
        public Int32 CompanyId { get; set; }
        public String CompanyName { get; set; }
        public Int32 DepartmentsCount { get; set; }
    }
}