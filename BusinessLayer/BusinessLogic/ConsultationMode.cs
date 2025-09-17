using AutoMapper;
using DataLayer;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;

namespace BusinessLayer
{
    public class ConsultationMode
    {
        public ConsultationMode()
        {
        }
        public enum enConsultationType
        {
            General = 1,              
            Specialist = 2,           
            SecondOpinion = 3,      
            Preventive = 4,           
            Diagnostic = 5,           
            PostTreatment = 6,        
            Counseling = 7            
        }
        public int ModeID { get; set; }
        public string Mode_Name { get; set; }
        public string Description { get; set; }

        public ConsultationMode(ConsultationModeEntity c)
        {
            ModeID = c.ModeID;
            Mode_Name =c. Mode_Name;
            Description =c. Description;
        }

        public ConsultationMode(ConsultationModeDTOs c)
        {
            ModeID = c.ModeID;
            Mode_Name = c.Mode_Name;
            Description = c.Description;
        }
    }
    public class ConsultationModeServices
    {

        private IMapper _mapper;

        readonly IConsultationModeRepository _service;
        public ConsultationModeServices(IConsultationModeRepository consultationModeRepository,IMapper mapper)
        {
            _mapper = mapper;
            _service = consultationModeRepository;
        }
        public  int AddNewConsultationMode(ref ConsultationMode mode)
        {
            mode.ModeID = _service.AddConsultationMode(_mapper.Map<ConsultationModeEntity>(mode));
            return mode.ModeID;
        }

        public  bool UpdateConsultationMode(ConsultationMode mode)
        {
            return _service.UpdateConsultationMode(_mapper.Map<ConsultationModeEntity>(mode));
        }

        public  bool DeleteConsultationMode(int modeId)
        {
            return _service.DeleteConsultationMode(modeId);
        }

        public  ConsultationMode GetConsultationModeById(int modeId)
        {
            return new ConsultationMode(_service.GetConsultationModeById(modeId));
         
        }

        //public static List<clsConsultationMode> GetAllConsultationMode()
        //{
        //   return 
        //}

    }











}



