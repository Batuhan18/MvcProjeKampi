using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
        ILoginDal _loginDal;

        public LoginManager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }

        public Admin GetByID(int id)
        {
            return _loginDal.Get(x => x.AdminID == id);
        }

        public List<Admin> GetList()
        {
            return _loginDal.List();
        }

        public void LoginAdd(Admin admin)
        {
            _loginDal.Insert(admin);
        }

        public void LoginDelete(Admin admin)
        {
            _loginDal.Delete(admin);
        }

        public void LoginUpdate(Admin admin)
        {
            _loginDal.Update(admin);
        }
    }
}
