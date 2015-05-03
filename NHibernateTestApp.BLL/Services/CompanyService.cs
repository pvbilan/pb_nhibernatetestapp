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

        public List<CompanyDepartmentsCountDTO> GetCompanyDepartmentsCount()
        {
            using (ISession session = PostgreSqlManager.OpenSession())
            {
                List<CompanyDepartmentsCountDTO> companyDepartmentsCountList = new List<CompanyDepartmentsCountDTO>();
                Company companyAlias = null;
                CompanyDepartment companyDepartmentAlias = null;
                CompanyDepartmentsCountDTO companyDepartmentsCountDTO = null;

                companyDepartmentsCountList = session.QueryOver<Company>(() => companyAlias)
                                                     .JoinAlias(() => companyAlias.CompanyDepartments, () => companyDepartmentAlias)
                                                     .SelectList(list => list
                                                         .SelectGroup(() => companyAlias.Id).WithAlias(() => companyDepartmentsCountDTO.CompanyId)
                                                         .Select(() => companyAlias.Name).WithAlias(() => companyDepartmentsCountDTO.CompanyName)
                                                         .SelectCount(() => companyDepartmentAlias.Id).WithAlias(() => companyDepartmentsCountDTO.DepartmentsCount))
                                                     .TransformUsing(Transformers.AliasToBean<CompanyDepartmentsCountDTO>())
                                                     .List<CompanyDepartmentsCountDTO>()
                                                     .ToList();

                return companyDepartmentsCountList;
            }
        }

        public List<CompanyDepartmentsCountDTO> GetCompaniesWhichDepartmentsCountGT2()
        {
            using (ISession session = PostgreSqlManager.OpenSession())
            {
                IEnumerable<CompanyDepartmentsCountDTO> companyDepartmentsCountList = null;
                Company companyAlias = null;
                CompanyDepartment companyDepartmentAlias = null;
                CompanyDepartmentsCountDTO companyDepartmentsCountDTO = null;

                // Batch the two queries together
                IFutureValue<Int32> companiesCount = session.QueryOver<Company>().SelectList(list => list.SelectCount(c => c.Id)).FutureValue<Int32>();

                companyDepartmentsCountList = session.QueryOver<Company>(() => companyAlias)
                                                     .JoinAlias(() => companyAlias.CompanyDepartments, () => companyDepartmentAlias)
                                                     .SelectList(list => list
                                                         .SelectGroup(() => companyAlias.Id).WithAlias(() => companyDepartmentsCountDTO.CompanyId)
                                                         .Select(() => companyAlias.Name).WithAlias(() => companyDepartmentsCountDTO.CompanyName)
                                                         .SelectCount(() => companyDepartmentAlias.Id).WithAlias(() => companyDepartmentsCountDTO.DepartmentsCount))
                                                     .Where(Restrictions.Gt(Projections.Count(Projections.Property(() => companyDepartmentAlias.Id)), 2))
                                                     .TransformUsing(Transformers.AliasToBean<CompanyDepartmentsCountDTO>())
                                                     .Future<CompanyDepartmentsCountDTO>();
                
                // Access the "Value" property of IFutureValue, which will execute both queries in one round-trip
                Console.WriteLine(String.Format("Companies count = {0}", companiesCount.Value));

                return companyDepartmentsCountList.ToList();
            }
        }
    }
}