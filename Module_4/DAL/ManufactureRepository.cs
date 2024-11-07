using System.Data;
using Dapper;

namespace DAL;

public class ManufactureRepository : BaseRepository
{
    public ManufactureRepository(IDbConnection connection) : base(connection)
    {
    }

    public IEnumerable<Manufacturer> GetManufactures()
    {
        return Connection.Query<Manufacturer>("SELECT * FROM Manufacturer");
    }
}