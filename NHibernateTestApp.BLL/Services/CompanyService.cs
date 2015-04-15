using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernateTestApp.DAL;
using NHibernateTestApp.DAL.PostgreSqlModel.Models;

namespace NHibernateTestApp.BLL.Services
{
    public class CompanyService
    {
        public Int32? InsertCompany(Company company)
        {
            using (ISession session = PostgreSqlManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(company);
                        transaction.Commit();
                        return company.Id;
                    }
                    catch (Exception exp)
                    {
                        transaction.Rollback();
                        return null;
                    }
                }
            }
        }

        public Boolean UpdateCompany(Company company)
        {
            using (ISession session = PostgreSqlManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(company);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception exp)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public Company GetCompany(Int32 companyId)
        {
            using (ISession session = PostgreSqlManager.OpenSession())
            {
                Company company = session.Get<Company>(companyId);

                NHibernateUtil.Initialize(company.CompanyDepartments);
                foreach (CompanyDepartment cd in company.CompanyDepartments)
                {
                    NHibernateUtil.Initialize(cd.Department);
                }

                return company;
            }
        }
    }
}