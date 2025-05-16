using BusinessLogicLayer.Interfaces.Base;
using DataAccessLayer.Interfaces.Base;
using DataAccessLayer.Models.EntityAbstractions;

namespace BusinessLogicLayer.Implements.Base;
public class GetService<TModel>(
    IUnitOfWork _unitOfWork,
    string[]? includes = null,
    bool isCached = false)
    : IGetService<TModel>
    where TModel : BaseEntity
{
    protected readonly IGenericRepository<TModel> _repository = _unitOfWork.Repository<TModel>(isCached);

    public virtual async Task<List<TModel>> GetAllAsync()
    {
        return await _repository.GetAllAsync(includes: includes);
    }

    public virtual async Task<List<TModel>> GetAllWithDeletedAsync()
    {
        return await _repository.GetAllWithDeletedAsync(includes);
    }

    public virtual async Task<TModel?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id, includes);
    }
}
