using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernateTestApp.DAL.PostgreSqlModel.Models;
using FluentNHibernate.Mapping;

namespace NHibernateTestApp.DAL.PostgreSqlModel.Mapping
{
    class CompanyMapping : ClassMap<Company>
    {
        public CompanyMapping()
        {
            this.Table("company");
            this.Id(d => d.Id, "id").GeneratedBy.Sequence("company_id_seq");
            this.Map(d => d.Name, "name").Not.Nullable();
            this.Map(d => d.Description, "description");
            this.Map(d => d.DepartmentsCount, "departmentscount").Not.Nullable();
            this.HasMany<CompanyDepartment>(p => p.CompanyDepartments).KeyColumn("companyid").AsBag().Cascade.AllDeleteOrphan().Not.KeyUpdate().OrderBy("id");
        }
    }
}