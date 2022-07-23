
using ERP.Common.Enums;
using ERP.Common.Shared;
using ERP.Dtos.Employees;
using ERP.Entities.UnitOfWork;
using ERP.Framework.Exceptions;
using ERP.Models.Admin;
using ERP.Models.Employees;
 

using Microsoft.EntityFrameworkCore;

using System.Net.Http.Headers;

using static ERP.Common.Enums.TypeEnum;

namespace ERP.Service.Admin;

public class EmployeesService : IEmployeesService
{
    private readonly ISecurity _security;
    private readonly IUnitOfWork _uw;
    private static readonly string[] VALID_FILE_TYPES = {   "image/bmp", "image/png", "image/jpeg" };
    public EmployeesService(IUnitOfWork uw, ISecurity security)
    {
        _security = security;
        _uw = uw;
    }

    public async Task<EMPEmployee> InsertEmployeeAsync(EmplopyeeInDto model)
    {
        if (model.UploadFile.File.Length <= 0) throw new ValidationException(ErrorList.NotFoundFile, "عکس پرسنلی انتخاب نشده است.");


        if (!VALID_FILE_TYPES.Contains(model.UploadFile.File.ContentType.ToLower()))
                throw new ValidationException(ErrorList.FileFormat, "فرمت عکس مجاز نمی باشد.");


        model.EMPEmployee.EmpoloyeeNo = await _uw.GetRepository<EMPEmployee>().GetAll().MaxAsync(x => x.EmpoloyeeNo) + 1;
        model.EMPEmployee.EmpoloyeeNo = model.EMPEmployee.EmpoloyeeNo == 0 || model.EMPEmployee.EmpoloyeeNo == 1 ? 10001 : model.EMPEmployee.EmpoloyeeNo;

        var folderName = Path.Combine("Resources", "Employee");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        var fileName =  "EmployeePic_" + model.EMPEmployee.EmpoloyeeNo + Path.GetExtension(model.UploadFile.File.FileName);
        var fullPath = Path.Combine(pathToSave, fileName);
      
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            model.UploadFile.File.CopyTo(stream);
        }
        model.EMPEmployee.ImaghePath = fullPath;
        model.EMPEmployee.Status = (short)BaseStatus.Deactive;
        model.EMPEmployee.CreateDateTime = DateTime.Now;

        await _uw.GetRepository<EMPEmployee>().AddAsync(model.EMPEmployee);

        AdminUser user = new AdminUser() { EMPEmployee = model.EMPEmployee };
        user.FirstName = model.EMPEmployee.FirstName;
        user.LastName = model.EMPEmployee.LastName;
        user.UserName = model.EMPEmployee.EmpoloyeeNo.ToString();
        user.MobileNo = model.EMPEmployee.MobileNo;
        user.PassWord = _security.HashPassword(model.EMPEmployee.NationalCode);
        user.Status = (short)BaseStatus.Deactive;
        user.CreateDateTime = DateTime.Now;
        user.VerificationCode = "";

        await _uw.GetRepository<AdminUser>().AddAsync(user);

        _uw.SaveChanges();

        return model.EMPEmployee;
    }


    public async Task<EMPEmployee> UpdateEmployeeAsync(EMPEmployee model)
    {
 
        AdminUser user = await _uw.GetRepository<AdminUser>().GetAllAsync().Result.Include(x => x.EMPEmployee).Where(x => x.EMPEmployee.Id == model.Id).FirstOrDefaultAsync();
 
        model.Status = (short)BaseStatus.Deactive;
        model.CreateDateTime = DateTime.Now;

        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        model.Status = (short)BaseStatus.Deactive;
        user.CreateDateTime = DateTime.Now;

        _uw.GetRepository<EMPEmployee>().Update(model);
        _uw.GetRepository<AdminUser>().Update(user);

        _uw.SaveChanges();

        return model;
    }

    public async Task<EMPEmployee> DeleteEmployeeAsync(int Id)
    {
        EMPEmployee model = await _uw.GetRepository<EMPEmployee>().GetByIdAsync(Id);
        AdminUser user = await _uw.GetRepository<AdminUser>().GetAllAsync().Result.Include(x => x.EMPEmployee).Where(x => x.EMPEmployee.Id == model.Id).FirstOrDefaultAsync();
                                          
         _uw.GetRepository<EMPEmployee>().Delete(model);
         _uw.GetRepository<AdminUser>().Delete(user);

        _uw.SaveChanges();

        return model;
    }

}
