
using DataLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public enum  DataLayerResult
    {
        Success,
        Conflict,
        InternalError,
        
    }
    public class DataLayerOperationResult<T> 
    {
     
       // public  bool Success { get; private set; }



        public string Message { get; private set; }



        public T Data { get; private set; }

      public DataLayerResult ResultType { get; }

        public DataLayerOperationResult(DataLayerResult success, string message, T data=default)
        {
            ResultType = success;
            Message = message;
            Data = data;
        }
        public static DataLayerOperationResult<T> SuccessOperation(T data, string message = "Operation completed successfully")
        => new DataLayerOperationResult<T>(DataLayerResult.Success, message, data);

        //
        public static DataLayerOperationResult<T> Fail(string message = "Database operation failed")
            => new DataLayerOperationResult<T>(DataLayerResult.Conflict, message);

        public static DataLayerOperationResult<T> InternalError(string message = "Unexpected server error")
                => new DataLayerOperationResult<T>(DataLayerResult.InternalError, message);

    }
}
