using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Model.Model;
using RequestModel;
using ViewModel;

namespace ServiceLibrary
{
    public interface IBaseService<T, TRm, TVm> where T : Entity where TRm : RequestModel<T> where TVm : BaseViewModel<T>
    {
        bool Add(T entity);

        IQueryable<T> Search(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        bool Delete(T entity);
        bool Delete(string id);
        bool Edit(T entity);
        T GetById(string id);
        Task<List<TVm>> GetAllAsync();
        List<DropdownViewModel> GetDropdownList(TRm request);
        Task<Tuple<List<DropdownViewModel>, int>> GetDropdownListAsync(TRm request);
        Task<Tuple<List<TVm>, int>> SearchAsync(TRm request);
        TVm GetDetail(string id);
        bool SyncList(List<T> entities);
        bool Upsert(T e);
    }
}