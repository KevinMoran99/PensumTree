using PensumTree.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PensumTree.Controllers
{
    class FacultadController : Controller<facultad>
    {
        public Operation<facultad> addRecord(facultad f)
        {
            try
            {
                EntitySingleton.Context.facultads.Add(f);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<facultad>.getSuccessOperation();
            }
            catch(Exception e)
            {
                return FactoryOperation<facultad>.getFailOperation(e.Message);
            }
        }

        public Operation<facultad> deleteRecord(facultad f)
        {
            throw new NotImplementedException();
        }

        public Operation<facultad> getRecords()
        {
            try
            {
                List<facultad> data = EntitySingleton.Context.facultads.ToList();
                return FactoryOperation<facultad>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<facultad>.getFailOperation(e.Message);
            }
        }

        public Operation<facultad> getActiveRecords()
        {
            try
            {
                List<facultad> data = EntitySingleton.Context.facultads.Where(x => x.estado).ToList();
                return FactoryOperation<facultad>.getDataOperation(data);
            }
            catch (Exception e)
            {
                return FactoryOperation<facultad>.getFailOperation(e.Message);
            }
        }

        public Operation<facultad> updateRecord(facultad f)
        {
            try
            {
                facultad facultad = EntitySingleton.Context.facultads.Find(f.id);
                EntitySingleton.Context.Entry(facultad).CurrentValues.SetValues(f);
                EntitySingleton.Context.SaveChanges();
                return FactoryOperation<facultad>.getSuccessOperation();
            }
            catch(Exception e)
            {
                return FactoryOperation<facultad>.getFailOperation(e.Message);
            }
        }
    }
}
