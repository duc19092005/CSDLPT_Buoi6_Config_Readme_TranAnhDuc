using CSDLPT_Tuan6_API.Enums;
using CSDLPT_Tuan6_API.Ultis;
using Microsoft.AspNetCore.Mvc;

namespace CSDLPT_Tuan6_API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly DBChangerHelper dbChangerHelper;

    public WeatherForecastController(DBChangerHelper dbChangerHelper)
    {
        this.dbChangerHelper = dbChangerHelper;
    }

    [HttpGet("/")]
    public IActionResult GetDB(DBContextEnum dbContextEnum)
    {
        return Ok(dbChangerHelper.DatabaseChangerHelper(dbContextEnum).getAllDatabases());
    }
}