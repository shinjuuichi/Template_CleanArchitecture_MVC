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

    public virtual async Task<TModel> UpdateAsync(TModel updatedEntity)
    {
        bool isExist = await _repository.IsExistById(updatedEntity.Id);
        if (!isExist) throw new DataNotFoundException(typeof(TModel), updatedEntity.Id);

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
