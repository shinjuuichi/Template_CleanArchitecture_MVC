using BusinessLogicLayer.Interfaces.Base;
using BusinessLogicLayer.Utils;
using DataAccessLayer.Commons.Exceptions;
using DataAccessLayer.Interfaces.Base;
using DataAccessLayer.Models.EntityAbstractions;

namespace BusinessLogicLayer.Implements.Base;
public class CrudService<TModel>(
    IUnitOfWork _unitOfWork,
    string[]? includes = null,
    bool isCached = false)
    : GetService<TModel>(_unitOfWork, includes, isCached),
      ICrudService<TModel>
    where TModel : BaseEntity
{
    public virtual async Task<TModel> CreateAsync(TModel entity)
    {
        entity.TryValidate();
        var resultEntity = await _repository.AddAsync(entity);
        await _unitOfWork.SaveChangeAsync();
        return resultEntity;
    }

    public virtual async Task<TModel> UpdateAsync(int id, TModel updatedEntity)
    {
        var existing = await _repository.GetByIdAsync(id)
            ?? throw new DataNotFoundException(typeof(TModel), id);

        updatedEntity.Id = id;
        updatedEntity.TryValidate();
        var resultEntity = _repository.Update(updatedEntity);
        await _unitOfWork.SaveChangeAsync();
        return resultEntity;
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id)
            ?? throw new DataNotFoundException(typeof(TModel), id);

        _repository.Remove(entity);
        await _unitOfWork.SaveChangeAsync();
    }
}
