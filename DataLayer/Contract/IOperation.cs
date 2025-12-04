using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Contract
{
   
    public interface IOperation<T>
    {
       


        public ResultStatus ResultType { get; }
      public  string Message { get; }
      public  T Data { get; }
    }
}
