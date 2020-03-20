using PensumTree.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PensumTree.Controllers
{
    class TipoCarreraController : Controller<tipo_carrera>
    {

        public Operation<tipo_carrera> addRecord(tipo_carrera c)
        {
            try
            {
                EntitySingleton.Context.tipo_carrera.Add(c);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<tipo_carrera>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<tipo_carrera>.getFailOperation(e.Message);
            }
        }

        public Operation<tipo_carrera> deleteRecord(tipo_carrera c)
        {
            throw new NotImplementedException();
        }

        public Operation<tipo_carrera> getRecords()
        {
            try
            {
                List<tipo_carrera> data = EntitySingleton.Context.tipo_carrera.ToList();
                return FactoryOperation<tipo_carrera>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<tipo_carrera>.getFailOperation(e.Message);
            }
        }

        public Operation<tipo_carrera> getActiveRecords()
        {
            try
            {
                List<tipo_carrera> data = EntitySingleton.Context.tipo_carrera.Where(x => x.estado).ToList();
                return FactoryOperation<tipo_carrera>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<tipo_carrera>.getFailOperation(e.Message);
            }
        }

        public Operation<tipo_carrera> updateRecord(tipo_carrera c)
        {
            try
            {
                tipo_carrera tipo_carrera = EntitySingleton.Context.tipo_carrera.Find(c.id);
                EntitySingleton.Context.Entry(tipo_carrera).CurrentValues.SetValues(c);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<tipo_carrera>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<tipo_carrera>.getFailOperation(e.Message);
            }
        }
    }
}
