using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernateTestApp.DAL.PostgreSqlModel.Models;
using FluentNHibernate.Mapping;

namespace NHibernateTestApp.DAL.PostgreSqlModel.Mapping
{
    class DutyMapping : ClassMap<Duty>
    {
        public DutyMapping()
        {
            this.Table("duty");
            this.Id(cd => cd.Id, "id").GeneratedBy.Sequence("duty_id_seq");
            this.Map(d => d.Name, "name").Not.Nullable();
            this.Map(d => d.Description, "description");
            this.HasManyToMany(d => d.Departments).Table("departmentduty").ParentKeyColumn("dutyid").ChildKeyColumn("departmentid").LazyLoad();
        }
    }
}