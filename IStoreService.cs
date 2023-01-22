using System.Linq.Expressions; 
using Kolokwium.Model.DataModels; 
using Kolokwium.ViewModels.VM; 
 
namespace Kolokwium.Services.Interfaces;

public interface IStoreService
{

    StoreVm GetStore(Expression<Func<Store, bool>> filterExpression);
    IEnumerable<StoreVm> GetStorees(Expression<Func<Store, bool>>? filterExpression = null);
    StoreVm AddStore(AddStoreVm addStoreVm);
    StoreVm UpdateStore(UpdateStoreVm updateStoreVm);
    bool DeleteStore(Expression<Func<Store, bool>> filterExpression);
}