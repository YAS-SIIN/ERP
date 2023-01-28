using ERP.Entities.UnitOfWork;
using ERP.Models.Admin;
using ERP.Models.Employees;

namespace ERP.Api
{
    public class NewDataGenerator
    {
        public static void InsertNewData(IUnitOfWork _uw)
        {
            if (!_uw.GetRepository<AdminRole>().ExistData(x => x.RoleName == "Employee"))
            {
                _uw.GetRepository<AdminRole>().Add(new AdminRole { RoleName = "Employee", RoleNameFa = "کارمندان", Status = 1, Description = "", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now });
                _uw.SaveChanges();
            }
            if (!_uw.GetRepository<AdminRole>().ExistData(x => x.RoleName == "RequestLeave"))
            {
                _uw.GetRepository<AdminRole>().Add(new AdminRole { RoleName = "RequestLeave", RoleNameFa = "مرخصی", Status = 1, Description = "", CreateDateTime = DateTime.Now, UpdateDateTime = DateTime.Now });
                _uw.SaveChanges();
            }

            if (!_uw.GetRepository<EMPEmployee>().ExistData(x => x.NationalCode == "4920040336"))
            {
                EMPEmployee testData = new EMPEmployee
                {
                    FirstName = "Yasin",
                    LastName = "Asadnezhad",
                    EmpoloyeeNo = 10001,
                    FatherName = "mm",
                    NationalCode = "4920040336",
                    IdentifyNo = "12",
                    DateOfBirth = "1370/01/01",
                    Gender = 0,
                    HireDate = "1401/01/01",
                    LeaveDate = "",
                    MobileNo = "09149611762",
                    ImaghePath = "",
                    Status = 1,
                    CreateDateTime = DateTime.Now,
                    UpdateDateTime = DateTime.Now,
                    Description = ""
                };

                _uw.GetRepository<EMPEmployee>().Add(testData);

                AdminUser user = new AdminUser()
                {
                    EMPEmployee = testData,
                    FirstName = testData.FirstName,
                    LastName = testData.LastName,
                    UserName = "Yasin",
                    MobileNo = testData.MobileNo,
                    PassWord = "1",
                    Status = 1,
                    CreateDateTime = DateTime.Now,
                    UpdateDateTime = DateTime.Now,
                    VerificationCode = "",
                    Description = ""
                };
                _uw.GetRepository<AdminUser>().Add(user);

                _uw.SaveChanges();
            }
        }
    }
}
