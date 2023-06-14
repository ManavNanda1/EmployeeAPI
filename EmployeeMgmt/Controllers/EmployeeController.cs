using EmployeeMgmt.Model.AppSet;
using EmployeeMgmt.Model.Employee;
using EmployeeMgmt.Model.User;
using EmployeeMgmt.Services.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Common.Helper;
using StudentApi.Common.Messages;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeMgmt.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Fields
        IEmployeeService EmployeeObj;
        #endregion

        #region Constructor
        public EmployeeController(IEmployeeService _employeeObj)
        {
            EmployeeObj = _employeeObj;
        }
        #endregion

        #region Post Employee

        [HttpPost("AddEmployee")]
        public async Task <BaseApiResponse> AddEmployee([FromForm] EmployeeModel Empdata)
        {
            try
            {
                ApiPostResponse <string> Response = new ApiPostResponse<string>();

                var Result = await EmployeeObj.UserEmailCheck(Empdata);
                if (Result == null)
                {
                    var Data = await EmployeeObj.AddEmployee(Empdata);
                    if (Data != null)
                    {
                        Response.Message = Messages.EmployeeAdded;
                        Response.Success = true;
                        string email = Empdata.EmpEmail;
                        decimal Salary = Empdata.EmpSalary;
                        SendRegistrationEmail(email, Salary);
                        

                    }
                    else
                    {
                        Response.Success = false;
                        Response.Message = Messages.InvalidRegister;
                    }
                }
                else
                {
                    Response.Message = Messages.EmailExists;
                    Response.Success = false;
                }
                return Response;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        #endregion

        #region Send Email
        private void SendRegistrationEmail(string email, decimal Salary)
        {
            try
            {

                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;
                string smtpUsername = "Manav Nanda";
                string smtpPassword = "lwadxrvvqzdbsifk";
                string senderEmail = "funishere97@gmail.com";

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(senderEmail);
                    mail.To.Add(email);
                    mail.Subject = "Hello From Employee Management System";
                    mail.Body = $"Thank you for registering! Your email is: {email}, and your Salary is: {Salary}";
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(senderEmail, smtpPassword);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Get All Employees
        [HttpGet("GetAllEmployees")]
        public async Task<ApiResponse<EmployeeModel>> GetAllEmployees()
        {
            ApiResponse<EmployeeModel> response = new ApiResponse<EmployeeModel>()
            {
                Data = new List<EmployeeModel>()
            };

            var Result = await EmployeeObj.GetAllEmployee();
            if (Result != null)
            {
                response.Message = Messages.EmployeesGotIt;
                response.Data = Result;
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = Messages.InValidDetails;
            }
            return response;

        }
        #endregion

        #region Delete Employee

        [HttpDelete("DeleteEmployee")]
        public async Task<BaseApiResponse>DeleteEmployee(int Id)
        {
            try
            {
                ApiResponse<int> response = new ApiResponse<int>();
                var Result = await EmployeeObj.DeleteEmployee(Id);
                if(Result != null)
                {
                    response.Success = true;
                    response.Message = Messages.IsDeleted;
                }
                else
                {
                    response.Success = false;
                }
                return response;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }

        #endregion

        #region Get Employee By Id

        [HttpPost("GetEmployeeById")]
        public async Task<BaseApiResponse>GetEmployeeById(int Id)
        {
            try
            {
                ApiResponse<EmployeeModel> response = new ApiResponse<EmployeeModel>();
                var Result = await EmployeeObj.GetEmployeeById(Id);
                if(Result != null)
                {
                    response.Data = new List<EmployeeModel> { Result };
                    response.Success = true;
                    response.Message= Messages.EmployeesGotIt;
                }
                else
                {
                    response.Success = false;
                }
                return response;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
        }
        #endregion
    }
}
