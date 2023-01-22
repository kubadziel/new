using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using Kolokwium.ViewModels.VM;
using Kolokwium.Services.Interfaces;

namespace Kolokwium.Services.ConcreteServices;
public class StoreService : BaseService, IStoreService
{
    public StoreService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
    : base(dbContext, mapper, logger) { }

    public StoreVm AddStore(AddStoreVm addStoreVm)
    {
        try
        {
            if (addStoreVm == null)
                throw new ArgumentNullException("View model parameter is null");
            var StoreEntity = Mapper.Map<Store>(addStoreVm);
            DbContext.Stores.Add(StoreEntity);
            DbContext.SaveChanges();
            var StoreVm = Mapper.Map<StoreVm>(StoreEntity);
            return StoreVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public StoreVm UpdateStore(UpdateStoreVm updateStoreVm)
    {
        try
        {
            if (updateStoreVm == null)
                throw new ArgumentNullException("View model parameter is null");
            var StoreEntity = Mapper.Map<Store>(updateStoreVm);
            DbContext.Stores.Update(StoreEntity);
            DbContext.SaveChanges();
            var StoreVm = Mapper.Map<StoreVm>(StoreEntity);
            return StoreVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public bool DeleteStore(Expression<Func<Store, bool>> filterExpression)
    {
        try
        {
            if (filterExpression == null)
                throw new ArgumentNullException("Filter expression parameter is null");
            var StoreEntity = DbContext.Stores.FirstOrDefault(filterExpression);
            if (StoreEntity != null)
            {
                DbContext.Stores.Remove(StoreEntity);
                DbContext.SaveChanges();
                return true;
            }
            else return false;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public StoreVm GetStore(Expression<Func<Store, bool>>? filterExpression)
    {
        try
        {
            if (filterExpression == null)
                throw new ArgumentNullException("Filter expression parameter is null");
            var StoreEntity = DbContext.Stores.FirstOrDefault(filterExpression);
            var StoreVm = Mapper.Map<StoreVm>(StoreEntity);
            return StoreVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public IEnumerable<StoreVm> GetStorees(Expression<Func<Store, bool>>? filterExpression = null)
    {
        try
        {
            var StoreesQuery = DbContext.Stores.AsQueryable();
            if (filterExpression != null)
                StoreesQuery = StoreesQuery.Where(filterExpression);
            var StoreVms = Mapper.Map<IEnumerable<StoreVm>>(StoreesQuery);
            return StoreVms;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }
}