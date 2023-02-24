namespace Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
public sealed class ExampleController : ControllerBase
{
    [HttpGet("from-query")]
    public ActionResult<ResponseDto> FromQuery([FromQuery] QueryRequestDto dto)
    {
        return new ResponseDto
        {
            Resource = dto.Resource,
            Server = dto.Resource.Server,
            Tenant = dto.Resource.Tenant,
            Identifier = dto.Resource.Identifier,
        };
    }

    [HttpPost("from-json")]
    public ActionResult<ResponseDto> FromJson([FromBody] JsonRequestDto dto)
    {
        return new ResponseDto
        {
            Resource = dto.Resource,
            Server = dto.Resource.Server,
            Tenant = dto.Resource.Tenant,
            Identifier = dto.Resource.Identifier,
        };
    }
}