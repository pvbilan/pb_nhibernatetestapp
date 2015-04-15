using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernateTestApp.DAL.PostgreSqlModel.Models;
using FluentNHibernate.Mapping;

namespace NHibernateTestApp.DAL.PostgreSqlModel.Mapping
{
    class CompanyDepartmentMapping : ClassMap<CompanyDepartment>
    {
        public CompanyDepartmentMapping()
        {
            this.Table("companydepartment");
            this.Id(cd => cd.Id, "id").GeneratedBy.Sequence("companydepartment_id_seq");
            this.References<Company>(cd => cd.Company).Column("companyid").Cascade.None();
            this.References<Department>(cd => cd.Department).Column("departmentid").Cascade.None();
        }
    }
}