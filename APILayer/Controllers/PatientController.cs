//using BusinessLayer;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using BusinessLayer;
//using APILayer.DTOs___Validations;
//using APILayer.Global;
//namespace APILayer.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PatientController : ControllerBase
//    {
//        clsPatient Patient;

//        [HttpPost]
//        [ProducesResponseType(StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        [ProducesResponseType(StatusCodes.Status502BadGateway)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public ActionResult<clsPatient> AddNewPatient(clsPatient newpatinet,clsPerson newperson)
//        {
//            if (newperson.Save()) {
//                newpatinet.person= newperson;
//                    }





//                // this.PatientID= DataLayer.
//                if (patient.Save())
//            {
//                return Created();
            
//            }
//            else { return BadRequest(); }

            


//        }


//        private bool UpdatePatient(clsUser user)
//        {

//            // this.PatientID= DataLayer.

//            //return datelayer.UpdatePatient

//            return true;
//        }

//        private bool DeleteByPatientID(int Patientid)
//        {

//            // this.PatientID= DataLayer.

//            //return datelayer.UpdatePatient

//            return true;
//        }

//        private bool DeletePatientPersonID(int personid)
//        {

//            // this.PatientID= DataLayer.

//            //return datelayer.UpdatePatient

//            return true;
//        }


//        private bool FindPatientPersonID(int personid)
//        {

//            // this.PatientID= DataLayer.

//            //return datelayer.UpdatePatient

//            return true;
//        }

//        private bool FindByPatientID(int Patientid)
//        {

//            // this.PatientID= DataLayer.

//            //return datelayer.UpdatePatient

//            return true;
//        }

//        private bool FindPatientUserName(int Patientid)
//        {

//            // this.PatientID= DataLayer.

//            //return datelayer.UpdatePatient

//            return true;
//        }
//    }
//}
