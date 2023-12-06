using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class ServiceResult
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
    public class SuccessResult:ServiceResult
    {
        public SuccessResult()
        {
            this.Message = "Successful service";
        }
        public SuccessResult(string messsage)
        {
            this.Message= messsage;
        }
    }
    public class FailedResult : ServiceResult
    {
        public FailedResult()
        {
            this.Message = "Failed Service";
        }
        public FailedResult(string messsage)
        {

            this.Message= messsage;
        }
    }
}
