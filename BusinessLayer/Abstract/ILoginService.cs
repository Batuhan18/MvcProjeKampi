using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ILoginService
    {
        List<Admin> GetList();
        void LoginAdd(Admin admin);
        Admin GetByID(int id);
        void LoginDelete(Admin admin);
        void LoginUpdate(Admin admin);
    }
}
