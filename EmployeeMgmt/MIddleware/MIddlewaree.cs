namespace EmployeeMgmt.MIddleware
{
    public class MIddlewaree
    {
        private readonly RequestDelegate _requestDelegate;
        public MIddlewaree(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            string logFilePath = @"C:\Tasks (Manav Nanda)\.NET CORE\\EmployeeMgmt\EmployeeMgmt\EmployeeMgmt\LogFile\Logs.txt";
            string ExceptionPath = @"C:\Tasks (Manav Nanda)\.NET CORE\EmployeeMgmt\EmployeeMgmt\EmployeeMgmt\LogFile\Exceptions.txt";

            try
            {
             
                if (!File.Exists(logFilePath))
                {
                    var myFile = File.Create(logFilePath);
                    myFile.Close();
                }
                using StreamWriter sw = File.AppendText(logFilePath);
                sw.WriteLine("");
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("Request");
                sw.WriteLine(context.Request.Path.Value);
                sw.WriteLine("Response");
                await _requestDelegate(context);
                sw.WriteLine(context.Response.StatusCode);
            }
            catch (Exception ex)
            {
                using StreamWriter sw = File.AppendText(ExceptionPath);
                sw.WriteLine("=========");
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(ex.Message);
                sw.WriteLine(context.Request.Path.Value);
                sw.WriteLine("=========");

            }

        }
    }
}
