using PensumTree.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensumTree.Controllers
{
    class PlanController: Controller<plan>
    {
        public Operation<plan> addRecord(plan p)
        {
            try
            {
                EntitySingleton.Context.plans.Add(p);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<plan>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<plan>.getFailOperation(e.Message);
            }
        }

        public Operation<plan> deleteRecord(plan p)
        {
            throw new NotImplementedException();
        }

        public Operation<plan> getRecords()
        {
            try
            {
                List<plan> data = EntitySingleton.Context.plans.ToList();
                return FactoryOperation<plan>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<plan>.getFailOperation(e.Message);
            }
        }

        public Operation<plan> getActiveRecords()
        {
            try
            {
                List<plan> data = EntitySingleton.Context.plans.Where(x => x.estado).ToList();
                return FactoryOperation<plan>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<plan>.getFailOperation(e.Message);
            }
        }

        public Operation<plan> getActiveRecordsByCareer(int idCarrera)
        {
            try
            {
                List<plan> data = EntitySingleton.Context.plans.Where(x => x.estado).Where(x => x.idCarrera == idCarrera).ToList();
                return FactoryOperation<plan>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<plan>.getFailOperation(e.Message);
            }
        }

        public Operation<plan> getLatestRecord()
        {
            try
            {
                long id = EntitySingleton.Context.plans.Max(p => p.id);
                plan data = EntitySingleton.Context.plans.Find(id);
                return FactoryOperation<plan>.getSingleValueOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<plan>.getFailOperation(e.Message);
            }
        }

        public Operation<plan> updateRecord(plan p)
        {
            try
            {
                plan plan = EntitySingleton.Context.plans.Find(p.id);
                EntitySingleton.Context.Entry(plan).CurrentValues.SetValues(p);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<plan>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<plan>.getFailOperation(e.Message);
            }
        }
    }
}
