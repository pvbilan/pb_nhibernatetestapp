using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernateTestApp.DAL;
using NHibernateTestApp.DAL.PostgreSqlModel.Models;

namespace NHibernateTestApp.BLL.Services
{
    public class DutyService
    {
        public Duty GetDuty(Int32 dutyId)
        {
            using (ISession session = PostgreSqlManager.OpenSession())
            {
                Duty duty = session.Get<Duty>(dutyId);

                NHibernateUtil.Initialize(duty.Departments);

                return duty;
            }
        }

        public Int32? SaveOrUpdateDuty(Duty duty)
        {
            using (ISession session = PostgreSqlManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(duty);
                        transaction.Commit();
                        return duty.Id;
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