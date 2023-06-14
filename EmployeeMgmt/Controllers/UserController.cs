using EmployeeMgmt.Model.AppSet;
using EmployeeMgmt.Model.User;
using EmployeeMgmt.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentApi.Common.Helper;

namespace EmployeeMgmt.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Fields
        private readonly IUserService UserObj;
        private readonly AppSetting _appSettings;
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region Constructor
        public UserController(IUserService _UserObj, IOptions<AppSetting> config, IWebHostEnvironment webHost)
        {
            UserObj = _UserObj;
            _appSettings = config.Value;
            _webHostEnvironment = webHost;
        }
        #endregion

        #region Login Post Method

        [HttpPost("UserLogin")]
        public async Task<BaseApiResponse> UserLogin([FromForm] LoginModel LogData)
        {
            ApiPostResponse<List<LoginResponse>> Response = new ApiPostResponse<List<LoginResponse>>();
            var Result = await UserObj.UserLogin(LogData);
            if (Result != null)
            {
                string jwtToken = JWToken.GenerateJSONWebToken(LogData.Email, LogData.Password, _appSettings.JWT_Secret);
              
                Response.Message = jwtToken;
                Response.Success = true;

            }
            else
            {
                Response.Success = false;
            }
            return Response;
        }

      

        #endregion
    }
}
