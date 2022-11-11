using ItscEf.DatabaseModels;
using ItscEf.Repositoies.Interface;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ItscEf.Repositoies
{
    public class PositionRepository : IPositionRepository
    {
        private readonly DatabaseContext _databaseContext;

        public PositionRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<TblPosition> GetByIdQuerySyntax(string searchText, int? searchId)
        {
            IEnumerable<TblPosition> result = (from i in _databaseContext.TblPosition
                                               select i);

            //if (!string.IsNullOrEmpty(searchText))
            //{
            //    result = result.Where(i => i.Name.Contains(searchText));
            //}

            if (searchId.HasValue)
            {
                result = result.Where(i => i.Id == searchId.Value);
            }

            return result.ToList();
        }

        public TblPosition GetByIdMethodSynTax(int id)
        {
            TblPosition single = _databaseContext.TblPosition.Single(i => i.Id == id);
            TblPosition singleOrDefault = _databaseContext.TblPosition.SingleOrDefault(i => i.Id == id);

            TblPosition first = _databaseContext.TblPosition.First(i => i.Name.Contains(""));
            TblPosition firstOrDefault = _databaseContext.TblPosition.FirstOrDefault(i => i.Name.Contains(""));

            int count = _databaseContext.TblPosition.Where(i => i.Id == id).ToList().Count();
            //int coustShort = _databaseContext.TblPosition.Co(i => i.Id);

            return new TblPosition();
        }

        public TblPosition AddPosition(TblPosition tblPosition)
        {
            _databaseContext.Add(tblPosition);
            int result = _databaseContext.SaveChanges();
            return tblPosition;
        }

        public List<TblPosition> AddPositions(List<TblPosition> tblPositions)
        {
            _databaseContext.AddRange(tblPositions);
            _databaseContext.SaveChanges();
            return tblPositions;
        }

        public TblPosition UpdatePosition(TblPosition tblPosition)
        {
            _databaseContext.Update(tblPosition);
            _databaseContext.SaveChanges();
            return tblPosition;
        }

        public List<TblPosition> UpdatePositions(List<TblPosition> tblPositions)
        {
            _databaseContext.UpdateRange(tblPositions);
            _databaseContext.SaveChanges();
            return tblPositions;
        }

        public TblPosition DeletePosition(TblPosition tblPosition)
        {
            _databaseContext.Remove(tblPosition);
            _databaseContext.SaveChanges();
            return tblPosition;
        }

        public List<TblPosition> DeletePositions(List<TblPosition> tblPositions)
        {
            _databaseContext.RemoveRange(tblPositions);
            _databaseContext.SaveChanges();
            return tblPositions;
        }


        public async Task<List<TblPosition>> GetPositionsAsync()
        {
            Console.WriteLine("Start get position");
            List<TblPosition> tblPositions = await _databaseContext.TblPosition.ToListAsync();
            Console.WriteLine("Complete");
            return tblPositions;
        }
    }
}
