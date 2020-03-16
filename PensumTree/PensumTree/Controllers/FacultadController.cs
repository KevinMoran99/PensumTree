using PensumTree.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PensumTree.Controllers
{
    class FacultadController : Controller<facultad>
    {
        //Aquí encontrarán un método por cada una de las operaciones CRUD:
        //Create: addRecord
        //Read:   getRecords (y su variante getActiveRecords que devuelve solamente registros con estado activo)
        //Update: updateRecord
        //Delete: deleteRecord (este realmente no se usa porque manejamos estados en cada tabla)

        //Literal, solo copien y peguen estos métodos en sus controladores, y cámbien toda cosa que
        //diga 'facultad' o derivados por el nombre del objeto que estén trabajando

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
