using DataAccess.Abstract;
using Entitities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class TblDataRepository : ITblDataRepository
    {
        CaseContext caseContext;

        public TblDataRepository(CaseContext caseContext)
        {
            this.caseContext = caseContext;
        }

        public void Add(TblData data)
        {
           
            caseContext.Database.ExecuteSqlRaw("DISABLE TRIGGER trgAfterInsert ON Tbldata");
            caseContext.TblData.Add(data);
            caseContext.SaveChanges();
            caseContext.Database.ExecuteSqlRaw($@"
                 INSERT INTO TbldataYedek (Name, Surname, City, CreatedDate, BirthYear)
                 OUTPUT INSERTED.Name, INSERTED.Surname, INSERTED.City, INSERTED.CreatedDate, INSERTED.BirthYear
                 VALUES ('{data.Name}', '{data.Surname}', '{data.City}', '{data.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss")}', {data.BirthYear})");
            caseContext.Database.ExecuteSqlRaw("ENABLE TRIGGER trgAfterInsert ON Tbldata");
          
        }

        public void Update(TblData data)
        {
            caseContext.TblData.Update(data);
            caseContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = caseContext.TblData.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                caseContext.TblData.Remove(data);
                caseContext.SaveChanges();
            }
        }

        public List<TblData> GetAllDatas()
        {
           return caseContext.TblData.ToList();
        }

        public TblData GetByData(Expression<Func<TblData, bool>> expression)
        {
            return caseContext.Set<TblData>().FirstOrDefault(expression);
        }
    }
}
