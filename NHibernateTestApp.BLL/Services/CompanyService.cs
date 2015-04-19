using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using NHibernateTestApp.DAL;
using NHibernateTestApp.DAL.PostgreSqlModel.Models;
using NHibernate.Transform;

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

        public List<CompanyDepartmentsCountView> GetCompanyDepartmentsCount()
        {
            using (ISession session = PostgreSqlManager.OpenSession())
            {
                List<CompanyDepartmentsCountView> companyDepartmentsCountList = new List<CompanyDepartmentsCountView>();
                Company companyAlias = null;
                CompanyDepartment companyDepartmentAlias = null;
                CompanyDepartmentsCountView companyDepartmentsCountViewAlias = null;

                companyDepartmentsCountList = session.QueryOver<Company>(() => companyAlias)
                                                     .JoinAlias(() => companyAlias.CompanyDepartments, () => companyDepartmentAlias)
                                                     .SelectList(list => list
                                                         .SelectGroup(() => companyAlias.Id).WithAlias(() => companyDepartmentsCountViewAlias.CompanyId)
                                                         .Select(() => companyAlias.Name).WithAlias(() => companyDepartmentsCountViewAlias.CompanyName)
                                                         .Select(Projections.Count(() => companyDepartmentAlias.Id).WithAlias(() => companyDepartmentsCountViewAlias.DepartmentsCount)))
                                                     .TransformUsing(Transformers.AliasToBean<CompanyDepartmentsCountView>())
                                                     .List<CompanyDepartmentsCountView>()
                                                     .ToList();


                return companyDepartmentsCountList;
            }
        }
    }
}