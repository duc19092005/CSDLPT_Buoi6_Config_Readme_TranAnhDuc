using CSDLPT_Tuan6_API.Context;
using CSDLPT_Tuan6_API.Enums;
using CSDLPT_Tuan6_API.Interfaces;

namespace CSDLPT_Tuan6_API.Ultis;

public class DBChangerHelper
{
    private readonly MyDbContext1 myDbContext;
    private readonly MyDbContext2 myDbContext2;
    private readonly MyDbContext3 myDbContext3;

    public DBChangerHelper(MyDbContext1 myDbContext1, MyDbContext2 myDbContext2, MyDbContext3 myDbContext3)
    {
        this.myDbContext = myDbContext1;
        this.myDbContext2 = myDbContext2;
        this.myDbContext3 = myDbContext3;
    }
    
    public IDBContext DatabaseChangerHelper(DBContextEnum dbContextEnum)
    {
        if (dbContextEnum == DBContextEnum.Server1)
        {
            return myDbContext;
        }
        else if(dbContextEnum == DBContextEnum.Server2)
        {
            return myDbContext2;
        }
        else if (dbContextEnum == DBContextEnum.Server3)
        {
            return myDbContext3;
        }
        else
        {
            return myDbContext;
        }
    }
}