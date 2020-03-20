using PensumTree.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensumTree.Controllers
{
    class PensumController: Controller<pensum>
    {
        public Operation<pensum> addRecord(pensum p)
        {
            try
            {
                EntitySingleton.Context.pensums.Add(p);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<pensum>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<pensum>.getFailOperation(e.Message);
            }
        }

        public Operation<pensum> deleteRecord(pensum p)
        {
            throw new NotImplementedException();
        }

        public Operation<pensum> deleteRecord(long idPlan, int corr)
        {
            try
            {
                pensum pensum = EntitySingleton.Context.pensums.Where(x => x.idPlan == idPlan && x.corr == corr).FirstOrDefault();
                EntitySingleton.Context.pensums.Remove(pensum);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<pensum>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<pensum>.getFailOperation(e.Message);
            }
        }

        public Operation<pensum> getRecords()
        {
            try
            {
                List<pensum> data = EntitySingleton.Context.pensums.ToList();
                return FactoryOperation<pensum>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<pensum>.getFailOperation(e.Message);
            }
        }

        public Operation<pensum> getRecordsByPlan(long idPlan)
        {
            try
            {
                List<pensum> data = EntitySingleton.Context.pensums.Where(x => x.idPlan == idPlan).OrderBy(x => x.corr).ToList();
                return FactoryOperation<pensum>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<pensum>.getFailOperation(e.Message);
            }
        }

        public Operation<pensum> getActiveRecords()
        {
            try
            {
                List<pensum> data = EntitySingleton.Context.pensums.Where(x => x.estado).ToList();
                return FactoryOperation<pensum>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<pensum>.getFailOperation(e.Message);
            }
        }


        public Operation<pensum> updateRecord(pensum p)
        {
            try
            {
                pensum pensum = EntitySingleton.Context.pensums.Find(p.id);
                EntitySingleton.Context.Entry(pensum).CurrentValues.SetValues(p);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<pensum>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<pensum>.getFailOperation(e.Message);
            }
        }

        public Operation<pensum> addOrUpdateRecord(pensum p)
        {
            try
            {
                pensum pensum = EntitySingleton.Context.pensums.Where(x => x.idPlan == p.idPlan && x.corr == p.corr).FirstOrDefault();
                if (pensum == null)
                {
                    EntitySingleton.Context.pensums.Add(p);
                }
                else
                {
                    p.id = pensum.id;
                    EntitySingleton.Context.Entry(pensum).CurrentValues.SetValues(p);
                }
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<pensum>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<pensum>.getFailOperation(e.Message);
            }
        }

    }
}
