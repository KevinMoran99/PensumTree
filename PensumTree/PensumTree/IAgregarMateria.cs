using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PensumTree.EntityFramework;
using PensumTree.Models;
using PensumTree.Utils;

namespace PensumTree
{
    public interface IAgregarMateria
    {
        void Selected(materia mat);
    }
}
