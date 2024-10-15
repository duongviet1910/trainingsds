using ConsoleAppQLSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppQLSV.Repository.IRepository
{
    interface IClassRepository 
    {
        public List<Class> GetAllClass();
        public Class GetClass(int id);
    }
}
