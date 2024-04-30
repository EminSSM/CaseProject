using Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITblDataRepository
    {
        List<TblData> GetAllDatas();
        TblData GetByData(Expression<Func<TblData, bool>> expression);
        void Add(TblData data);
        void Update(TblData data);
        void Delete(int id);
    }
}
