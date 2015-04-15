using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernateTestApp.DAL.PostgreSqlModel.Models;
using FluentNHibernate.Mapping;

namespace NHibernateTestApp.DAL.PostgreSqlModel.Mapping
{
    class DepartmentMapping : ClassMap<Department>
    {
        public DepartmentMapping()
        {
            this.Table("department");
            this.Id(d => d.Id, "id").GeneratedBy.Sequence("department_id_seq");
            this.Map(d => d.Name, "name").Not.Nullable();
            this.HasMany<CompanyDepartment>(p => p.CompanyDepartments).KeyColumn("departmentid").AsBag().Cascade.None();
            this.HasManyToMany(d => d.Duties).Table("departmentduty").ParentKeyColumn("departmentid").ChildKeyColumn("dutyid").LazyLoad().Cascade.All().OrderBy("id");
        }
    }
}