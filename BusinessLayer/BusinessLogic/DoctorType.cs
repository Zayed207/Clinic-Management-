using DataLayer.Contract;
using DataLayer.Entities;

namespace BusinessLayer
{
    public class DoctorType
    {
        public short DoctorTypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }

        public ICollection<DoctorEntity> Doctor { get; set; }
    }


    public class DoctorTypeServices 
    {
        public int AddDoctorType(DoctorTypeDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDoctorType(int id)
        {
            throw new NotImplementedException();
        }

        public List<DoctorTypeServices> GetAllDoctorTypes()
        {
            throw new NotImplementedException();
        }

        public DoctorTypeServices GetDoctorTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public int? GetPaymentProviderIDByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDoctorType(DoctorTypeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}


