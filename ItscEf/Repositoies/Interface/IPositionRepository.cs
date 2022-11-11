using ItscEf.DatabaseModels;

namespace ItscEf.Repositoies.Interface
{
    public interface IPositionRepository
    {
        public List<TblPosition> GetByIdQuerySyntax(string searchText, int? searchId);
        public TblPosition GetByIdMethodSynTax(int id);
        public Task<List<TblPosition>> GetPositionsAsync();
    }
}
