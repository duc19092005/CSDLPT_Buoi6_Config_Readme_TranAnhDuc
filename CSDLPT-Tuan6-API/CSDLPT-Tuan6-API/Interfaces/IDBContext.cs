using CSDLPT_Tuan6_API.Dtos;

namespace CSDLPT_Tuan6_API.Interfaces;

public interface IDBContext
{
    List<DbContextDtos> getAllDatabases();
}