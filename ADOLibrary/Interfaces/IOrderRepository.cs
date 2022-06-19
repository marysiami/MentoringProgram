using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOLibrary.Interfaces
{
    public interface IOrderRepository
    {
        public void Insert();
        public void Update();
        public void Get();
        public void GetAll();
        public void Delete();
        public void DeleteAll();
    }
}
