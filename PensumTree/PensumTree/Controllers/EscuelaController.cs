using PensumTree.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PensumTree.Controllers
{
    class EscuelaController: Controller<escuela>
    {
        public Operation<escuela> addRecord(escuela es)
        {
            try
            {
                EntitySingleton.Context.escuelas.Add(es);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<escuela>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<escuela>.getFailOperation(e.Message);
            }
        }

        public Operation<escuela> deleteRecord(escuela es)
        {
            throw new NotImplementedException();
        }

        public Operation<escuela> getRecords()
        {
            try
            {
                List<escuela> data = EntitySingleton.Context.escuelas.ToList();
                return FactoryOperation<escuela>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<escuela>.getFailOperation(e.Message);
            }
        }
        public Operation<escuela> getActiveRecords()
        {
            try
            {
                List<escuela> data = EntitySingleton.Context.escuelas.Where(x => x.estado).ToList();
                return FactoryOperation<escuela>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<escuela>.getFailOperation(e.Message);
            }
        }
        public Operation<escuela> updateRecord(escuela es)
        {
            try
            {
                escuela escuela = EntitySingleton.Context.escuelas.Find(es.id);
                EntitySingleton.Context.Entry(escuela).CurrentValues.SetValues(es);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<escuela>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<escuela>.getFailOperation(e.Message);
            }
        }
    }
}
