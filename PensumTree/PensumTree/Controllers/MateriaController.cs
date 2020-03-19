using PensumTree.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PensumTree.Controllers
{
    class MateriaController: Controller<materia>
    {

        public Operation<materia> addRecord(materia m)
        {
            try
            {
                EntitySingleton.Context.materias.Add(m);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<materia>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<materia>.getFailOperation(e.Message);
            }
        }

        public Operation<materia> deleteRecord(materia m)
        {
            throw new NotImplementedException();
        }

        public Operation<materia> getRecords()
        {
            try
            {
                List<materia> data = EntitySingleton.Context.materias.ToList();
                return FactoryOperation<materia>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<materia>.getFailOperation(e.Message);
            }
        }

        public Operation<materia> getActiveRecords()
        {
            try
            {
                List<materia> data = EntitySingleton.Context.materias.Where(x => x.estado).ToList();
                return FactoryOperation<materia>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<materia>.getFailOperation(e.Message);
            }
        }

       
        public Operation<materia> updateRecord(materia m)
        {
            try
            {
                materia materia = EntitySingleton.Context.materias.Find(m.id);
                EntitySingleton.Context.Entry(materia).CurrentValues.SetValues(m);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<materia>.getSuccessOperation();
            }
            catch (Exception e)
            {
                return FactoryOperation<materia>.getFailOperation(e.Message);
            }
        }
    }
}
