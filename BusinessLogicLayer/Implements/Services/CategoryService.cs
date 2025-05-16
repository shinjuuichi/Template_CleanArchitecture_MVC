using BusinessLogicLayer.Implements.Base;
using BusinessLogicLayer.Interfaces.Services;
using DataAccessLayer.Interfaces.Base;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Implements.Services
{
    public class CategoryService(IUnitOfWork _unitOfWork)
          : CrudService<Category>(_unitOfWork, [], false),
            ICategoryService
    {
    }
}
