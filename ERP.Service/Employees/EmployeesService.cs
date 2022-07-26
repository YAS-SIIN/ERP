
using ERP.Common.Enums;
using ERP.Common.Shared;      
using ERP.Entities.UnitOfWork;
using ERP.Framework.Exceptions;
using ERP.Models.Admin;
using ERP.Models.Employees;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
                                

using static ERP.Common.Enums.TypeEnum;

namespace ERP.Service.Employees;

public class EmployeesService : IEmployeesService
{
    private readonly ISecurity _security;
    private readonly IUnitOfWork _uw;
    private static readonly string[] VALID_FILE_TYPES = {   "image/bmp", "image/png", "image/jpeg" };
    private readonly IHostingEnvironment _hostingEnvironment;
    public EmployeesService(IUnitOfWork uw, ISecurity security )
    {
        _security = security;
        _uw = uw;                                 
    }

    public async Task<EMPEmployee> InsertEmployeeAsync(EMPEmployee model, IFormFile File)
    {
        model.EmpoloyeeNo = await _uw.GetRepository<EMPEmployee>().GetAll().MaxAsync(x => x.EmpoloyeeNo) + 1;
        model.EmpoloyeeNo = model.EmpoloyeeNo == 0 || model.EmpoloyeeNo == 1 ? 10001 : model.EmpoloyeeNo;
        if (File != null) {
            if (!VALID_FILE_TYPES.Contains(File.ContentType.ToLower()))
                throw new ValidationException(ErrorList.FileFormat, "فرمت عکس مجاز نمی باشد.");

            var folderName = Path.Combine("Resources", "Employee");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = "EmployeePic_" + model.EmpoloyeeNo + Path.GetExtension(File.FileName);
            var fullPath = Path.Combine(pathToSave, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                File.CopyTo(stream);
            }
            model.ImaghePath = folderName + fileName;
        }

                  
     
        model.Status = (short)BaseStatus.Deactive;
        model.CreateDateTime = DateTime.Now;
        model.LeaveDate = "";
    await _uw.GetRepository<EMPEmployee>().AddAsync(model);

        AdminUser user = new AdminUser() { EMPEmployee = model };
        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.UserName = model.EmpoloyeeNo.ToString();
        user.MobileNo = model.MobileNo;
        user.PassWord = _security.HashPassword(model.NationalCode);
        user.Status = (short)BaseStatus.Deactive;
        user.CreateDateTime = DateTime.Now;
        user.VerificationCode = "";

        await _uw.GetRepository<AdminUser>().AddAsync(user);

        _uw.SaveChanges();

        return model;
    }


    public async Task<EMPEmployee> UpdateEmployeeAsync(EMPEmployee model, IFormFile File)
    {
 
        AdminUser user = await _uw.GetRepository<AdminUser>().GetAll(x => x.EMPEmployee.Id == model.Id && x.Status != (short)BaseStatus.Deleted && x.EMPEmployee.Status != (short)BaseStatus.Deleted).FirstOrDefaultAsync();

        if (user == null)
            throw new ValidationException(ErrorList.NotFound, "پرسنل مورد نظر یافت نشد.");
        user.EMPEmployee = model;
        if (File != null)
        {
            if (!VALID_FILE_TYPES.Contains(File.ContentType.ToLower()))
                throw new ValidationException(ErrorList.FileFormat, "فرمت عکس مجاز نمی باشد.");

            var folderName = Path.Combine("Resources", "Employee");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = "EmployeePic_" + model.EmpoloyeeNo + Path.GetExtension(File.FileName);
            var fullPath = Path.Combine(pathToSave, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                File.CopyTo(stream);
            }
            model.ImaghePath = folderName + fileName;
        }

        user.UpdateDateTime = DateTime.Now;
        _uw.GetRepository<EMPEmployee>().Update(model);


        user.FirstName = model.FirstName;
        user.LastName = model.LastName;   
        user.MobileNo = model.MobileNo;
        user.PassWord = _security.HashPassword(model.NationalCode);
        user.UpdateDateTime = DateTime.Now;
                  
        _uw.GetRepository<AdminUser>().Update(user);

        _uw.SaveChanges();

        return model;
    }

    public async Task<EMPEmployee> DeleteEmployeeAsync(int Id)
    {
     
        AdminUser userModel = await _uw.GetRepository<AdminUser>().GetAll().Include(x => x.EMPEmployee)
            .Where(x => x.EMPEmployee.Id == Id && x.Status != (short)BaseStatus.Deleted && x.EMPEmployee.Status != (short)BaseStatus.Deleted).FirstOrDefaultAsync();

        if (userModel == null)
            throw new ValidationException(ErrorList.NotFound, "پرسنل مورد نظر یافت نشد.");

        userModel.EMPEmployee.UpdateDateTime = DateTime.Now;
        userModel.EMPEmployee.Status = (short)BaseStatus.Deleted;
                               
        userModel.UpdateDateTime = DateTime.Now;
        userModel.Status = (short)BaseStatus.Deleted;

        _uw.GetRepository<EMPEmployee>().Update(userModel.EMPEmployee);
        _uw.GetRepository<AdminUser>().Update(userModel);

        _uw.SaveChanges();

        return userModel.EMPEmployee;
    }

    public async Task<EMPEmployee> ConfirmEmployeeAsync(int Id)
    {

        AdminUser userModel = await _uw.GetRepository<AdminUser>().GetAll().Include(x => x.EMPEmployee)
            .Where(x => x.EMPEmployee.Id == Id && x.Status != (short)BaseStatus.Deleted && x.EMPEmployee.Status != (short)BaseStatus.Deleted).FirstOrDefaultAsync();

        if (userModel == null)
            throw new ValidationException(ErrorList.NotFound, "پرسنل مورد نظر یافت نشد.");

        userModel.EMPEmployee.UpdateDateTime = DateTime.Now;
        userModel.EMPEmployee.Status = (short)BaseStatus.Active;

        userModel.UpdateDateTime = DateTime.Now;
        userModel.Status = (short)BaseStatus.Active;

        _uw.GetRepository<EMPEmployee>().Update(userModel.EMPEmployee);
        _uw.GetRepository<AdminUser>().Update(userModel);

        _uw.SaveChanges();

        return userModel.EMPEmployee;
    }

}
