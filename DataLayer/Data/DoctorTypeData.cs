using DataLayer.Contract;
using DataLayer.Entities;

namespace DataLayer.Data
{
    public class DoctorTypeData:IDoctorTypeRepository
    {

        private readonly Clinicdbcontext _context;
        public DoctorTypeData(Clinicdbcontext context)
        {
            _context = context;
        }
        public int DoctorTypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }

        public int AddDoctorType(DoctorTypeEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDoctorType(int id)
        {
            throw new NotImplementedException();
        }

        public List<DoctorTypeEntity> GetAllDoctorTypes()
        {
            throw new NotImplementedException();
        }

        public DoctorTypeEntity? GetDoctorTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public int? GetPaymentProviderIDByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDoctorType(DoctorTypeEntity entity)
        {
            throw new NotImplementedException();
        }
    }

}


