using BusinessLayer.BusinessLogic;
using DataLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessLogic
{

    public enum ResultStatus
    {
        Success,
        ValidationError,
        NotFound,
        Conflict,
        InternalError,
        Updated,
        Valid
    }
    public class OperationResult<T>
        {
            public ResultStatus Status { get; private set; }
            public string Message { get; private set; }
            public T Data { get; private set; }

  

        private OperationResult(ResultStatus status, string message, T data = default)
            {
                Status = status;
                Message = message;
                Data = data;
            }

      

        public static OperationResult<T> Success(T data, string message = "Operation completed successfully")
                => new OperationResult<T>(ResultStatus.Success, message, data);

        public static OperationResult<T> Updated( string message = "Operation completed successfully")
             => new OperationResult<T>(ResultStatus.Success, message);

        public static OperationResult<T> ValidationError(string message)
              => new OperationResult<T>(ResultStatus.ValidationError, message);
        public static OperationResult<T> Validate(string message =" valid")
                => new OperationResult<T>(ResultStatus.Valid,message);

            public static OperationResult<T> NotFound(string message = "Resource not found")
                => new OperationResult<T>(ResultStatus.NotFound, message);

            
            public static OperationResult<T> Conflict(string message = "Conflict detected")
                => new OperationResult<T>(ResultStatus.Conflict, message);

           
            public static OperationResult<T> InternalError(string message = "Unexpected server error")
                => new OperationResult<T>(ResultStatus.InternalError, message);
        }


    }



