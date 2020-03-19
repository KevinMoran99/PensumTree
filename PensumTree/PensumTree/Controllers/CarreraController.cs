using PensumTree.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PensumTree.Controllers
{
    class CarreraController : Controller<carrera>
    {

        public Operation<carrera> addRecord(carrera c)
        {
            try
            {
                EntitySingleton.Context.carreras.Add(c);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<carrera>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<carrera>.getFailOperation(e.Message);
            }
        }

        public Operation<carrera> deleteRecord(carrera c)
        {
            throw new NotImplementedException();
        }

        public Operation<carrera> getRecords()
        {
            try
            {
                List<carrera> data = EntitySingleton.Context.carreras.ToList();
                return FactoryOperation<carrera>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<carrera>.getFailOperation(e.Message);
            }
        }

        public Operation<carrera> getActiveRecords()
        {
            try
            {
                List<carrera> data = EntitySingleton.Context.carreras.Where(x => x.estado).ToList();
                return FactoryOperation<carrera>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<carrera>.getFailOperation(e.Message);
            }
        }

        public Operation<carrera> updateRecord(carrera c)
        {
            try
            {
                carrera carrera = EntitySingleton.Context.carreras.Find(c.id);
                EntitySingleton.Context.Entry(carrera).CurrentValues.SetValues(c);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<carrera>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<carrera>.getFailOperation(e.Message);
            }
        }
    }
}
