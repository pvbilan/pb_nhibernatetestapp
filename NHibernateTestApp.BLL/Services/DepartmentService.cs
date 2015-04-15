using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernateTestApp.DAL;
using NHibernateTestApp.DAL.PostgreSqlModel.Models;

namespace NHibernateTestApp.BLL.Services
{
    public class DepartmentService
    {
        public Department GetDepartment(Int32 departmentId)
        {
            using (ISession session = PostgreSqlManager.OpenSession())
            {
                Department department = session.Get<Department>(departmentId);

                NHibernateUtil.Initialize(department.Duties);

                return department;
            }
        }

        public Int32? SaveOrUpdateDepartment(Department department)
        {
            using (ISession session = PostgreSqlManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(department);
                        transaction.Commit();
                        return department.Id;
                    }
                    catch (Exception exp)
                    {
                        transaction.Rollback();
                        return null;
                    }
                }
            }
        }
    }
}