using BusinessLogicLayer.Implements.Base;
using BusinessLogicLayer.Interfaces.Services;
using DataAccessLayer.Interfaces.Base;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Implements.Services
{
    public class ProductService(IUnitOfWork _unitOfWork)
        : CrudService<Product>(_unitOfWork, ["Category"], true),
          IProductService
    {
    }
}
