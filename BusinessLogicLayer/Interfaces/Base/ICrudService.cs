using DataAccessLayer.Models.EntityAbstractions;

namespace BusinessLogicLayer.Interfaces.Base;
public interface ICrudService<TModel> : IGetService<TModel>
    where TModel : BaseEntity
{
    Task<TModel> CreateAsync(TModel entity);
    Task<TModel> UpdateAsync(TModel updatedEntity);
    Task DeleteAsync(int id);
}
