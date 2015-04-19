using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernateTestApp.DAL;
using NHibernateTestApp.DAL.PostgreSqlModel.Models;
using NHibernateTestApp.BLL.Services;

namespace PT_NHibernateTestApp
{
    class Program
    {
        private const String EXIT = "exit";
        private static CompanyService companyService = new CompanyService();
        private static DepartmentService departmentService = new DepartmentService();
        private static DutyService dutyService = new DutyService();

        static void Main()
        {
            PostgreSqlManager.Initialize("Server=ServerIP or ServerName;Port=Server Port;User Id=Username;Password=Password;Database=PB_NHibernateTest;");

            while (true) // Loop indefinitely
            {
                Console.WriteLine("Welcome!");
                Console.WriteLine("1: Create a new company;");
                Console.WriteLine("2: Update the company");
                Console.WriteLine("3: Insert a new department");
                Console.WriteLine("4: Insert a new duty");
                Console.WriteLine("5: Update the department");
                Console.WriteLine("6: Get departments count of companies");
                Console.WriteLine("exit: exit from the application.");
                Console.Write("Enter input: ");
                String line = Console.ReadLine();

                if (line == EXIT)
                {
                    break;
                }

                switch (line)
                {
                    case "1": CreateNewCompany(); break;
                    case "2": UpdateCompany(); break;
                    case "3": CreateNewDepartment(); break;
                    case "4": CreateNewDuty(); break;
                    case "5": UpdateDepartment(); break;
                    case "6": GetDepartmentsCountOfCompanies(); break;
                    default: break;
                }
            }
        }

        static void CreateNewCompany()
        {
            Company company = new Company()
            {
                Name = "Test Company",
                Description = "Test Company",
                DepartmentsCount = 4
            };

            company.CompanyDepartments = new List<CompanyDepartment>();

            company.CompanyDepartments.Add(new CompanyDepartment
            {
                Company = company,
                Department = departmentService.GetDepartment(1)
            });

            company.CompanyDepartments.Add(new CompanyDepartment
            {
                Company = company,
                Department = departmentService.GetDepartment(2)
            });

            company.CompanyDepartments.Add(new CompanyDepartment
            {
                Company = company,
                Department = departmentService.GetDepartment(4)
            });

            Int32? companyId = companyService.InsertCompany(company);

            if (companyId.HasValue)
            {
                Company savedCompany = companyService.GetCompany(companyId.Value);

                Console.WriteLine(String.Format("Company: Id={0}, Name={1}, Departments: ", savedCompany.Id, savedCompany.Name));
                foreach (CompanyDepartment cd in savedCompany.CompanyDepartments)
                {
                    Console.WriteLine(cd.Department.Name);
                }
                Console.WriteLine();
            }
        }

        static void UpdateCompany()
        {
            Company updatedCompany = companyService.GetCompany(23);

            updatedCompany.Description = "Updated company";
            updatedCompany.CompanyDepartments.RemoveAt(0);
            updatedCompany.CompanyDepartments.Add(new CompanyDepartment
            {
                Company = updatedCompany,
                Department = departmentService.GetDepartment(1)
            });

            Boolean result = companyService.UpdateCompany(updatedCompany);
            Console.WriteLine(String.Format("Result of updated company = {0}", result.ToString()));
        }

        static void CreateNewDepartment()
        {
            Department newDepartment = new Department()
            {
                Name = "TestDeparment",
                Duties = new List<Duty>()
            };

            newDepartment.Duties.Add(dutyService.GetDuty(1));
            newDepartment.Duties.Add(dutyService.GetDuty(2));

            Int32? newDepartmentId = departmentService.SaveOrUpdateDepartment(newDepartment);
            Console.WriteLine(String.Format("Result of insert a new department = {0}", newDepartmentId.HasValue.ToString()));
        }

        static void CreateNewDuty()
        {
            Duty newDuty = new Duty()
            {
                Name = "TestDuty",
                Departments = new List<Department>()
            };

            newDuty.Departments.Add(departmentService.GetDepartment(1));

            Int32? newDutyId = dutyService.SaveOrUpdateDuty(newDuty);
            Console.WriteLine(String.Format("Result of insert a new duty = {0}", newDutyId.HasValue.ToString()));
        }

        static void UpdateDepartment()
        {
            Department updatedDepartment = departmentService.GetDepartment(10);

            updatedDepartment.Name = String.Format("TestDepartment {0}", DateTime.Now.ToLongTimeString());

            updatedDepartment.Duties.RemoveAt(0);
            updatedDepartment.Duties.Add(new Duty()
            {
                Name = String.Format("TestDuty {0}", DateTime.Now.ToLongTimeString()),
                Description = "Inserted"
            });

            Int32? departmentId = departmentService.SaveOrUpdateDepartment(updatedDepartment);
            Console.WriteLine(String.Format("Result of update department = {0}", departmentId.HasValue.ToString()));
        }

        static void GetDepartmentsCountOfCompanies()
        {
            List<CompanyDepartmentsCountView> companyDepartmentsCountList = companyService.GetCompanyDepartmentsCount();

            if (companyDepartmentsCountList != null && companyDepartmentsCountList.Count() > 0)
            {
                foreach (CompanyDepartmentsCountView companyDepartmentsCount in companyDepartmentsCountList)
                {
                    Console.WriteLine(String.Format("Company: Id={0}, Name={1}, DepartmentsCount: {2}.", companyDepartmentsCount.CompanyId, companyDepartmentsCount.CompanyName, companyDepartmentsCount.DepartmentsCount));
                }
                Console.WriteLine();
            }
        }
    }
}