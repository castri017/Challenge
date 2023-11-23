using Challenge.Application.Dtos.Permission;
using Challenge.Application.Services.Contracs;
using Challenge.Application.Services.MessageResultServices;
using Challenge.Presentation.API.Model;
using Microsoft.AspNetCore.Mvc; 

namespace Challenge.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionApplicationService _permissionApplciation;
        private readonly IDictionary<string, string> message;

        public PermissionController(IResultMessage _resultMessage, IPermissionApplicationService permisionApplication)
        {
            this._permissionApplciation = permisionApplication;
            message = _resultMessage.Message["PermissionMessage"]; 
            permisionApplication._message = message;
        }

        [HttpPost(nameof(CreatePermission))]
        public async Task<IActionResult> CreatePermission([FromBody] Permissiondto permissiondto)
        {
            await _permissionApplciation.addPermission(permissiondto);

            return Ok(new ResponseModel()
            {
                StatusCode = 200,
                Response = message["Succes"]
            });
        }

        [HttpGet(nameof(GetByIdPermission) + "/{PermissionId}")]
        public async Task<IActionResult> GetByIdPermission(Guid PermissionId)
        {
            var _staffing = await _permissionApplciation.getByPermission(PermissionId);
            return Ok(new ResponseModel()
            {
                StatusCode = 200,
                Response = _staffing
            });
        }

        [HttpPut(nameof(ModifyPermission))]
        public async Task<IActionResult> ModifyPermission([FromBody] Permissiondto permissiondto)
        {
            var _isupdate = await _permissionApplciation.ModifyPermission(permissiondto);

            return Ok(new ResponseModel()
            {
                StatusCode = _isupdate ? 200 :
                                           202,
                Response = _isupdate ? message["Succes"] :
                                       message["Failed"]
            }); ;
        }

    }
}
