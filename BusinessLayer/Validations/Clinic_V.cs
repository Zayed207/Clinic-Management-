using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsForPresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    internal class Clinic_V
    {

        public static OperationResult<bool> ClinicObjectCheck(ClinicRequestDTO e)
        {
            if (e.City == null  || e.ClinicName == null) return OperationResult<bool>.ValidationError("one or more of city or clinicname are not valid");

            return OperationResult<bool>.Validate();
        }
    }
}
