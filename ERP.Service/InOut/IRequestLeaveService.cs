﻿
using ERP.Models.Admin;
using ERP.Models.Employees;
using ERP.Models.InOut;     

namespace ERP.Service.InOut;

public interface IRequestLeaveService
{
    Task<List<InOutRequestLeave>> GetUserAllAsync(EMPEmployee employee);

}
