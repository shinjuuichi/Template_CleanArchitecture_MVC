using BusinessLogicLayer.Interfaces.Base;
using DataAccessLayer.Interfaces.Base;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Interfaces.Services
{
    public interface IProductService : ICrudService<Product>;
}
