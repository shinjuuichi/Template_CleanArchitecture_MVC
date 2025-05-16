using DataAccessLayer.Models.EntityAbstractions;

namespace BusinessLogicLayer.Interfaces.Base;
public interface IGetService<TModel>
    where TModel : BaseEntity
{
    Task<List<TModel>> GetAllAsync();
    Task<List<TModel>> GetAllWithDeletedAsync();
    Task<TModel?> GetByIdAsync(int id);
}
