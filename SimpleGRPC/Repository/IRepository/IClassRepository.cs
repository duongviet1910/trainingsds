using Google.Protobuf.WellKnownTypes;
using Share;
using SimpleGRPC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGRPC.Repository.IRepository
{
    public interface IClassRepository
    {
        public List<Class> GetAllClasses();
        public DataItems GetDataPage(int pageNumber, int pageSize, Class classSearch);
        public Class GetClassById(int id);
        public BooleanGrpc AddNewClass(Class classNew);

        public BooleanGrpc UpdateClass(Class classUpdate);

        public BooleanGrpc DeleteClass(Class classDelete);
        public int GetIDNewClass();

    }
}
