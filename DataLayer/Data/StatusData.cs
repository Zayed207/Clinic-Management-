//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataLayer
//{

//    public class StatusData:
//    {
//        public static int AddNewAppointmentStatus(AppointmentStatusEntity status)
//        {
//            using (var _context = new Clinicdb_context())
//            {
//                _context.AppointmentStatuses.Add(status);
//                _context.SaveChanges();
//                return status.Status_ID;
//            }
//        }

//        public static bool UpdateAppointmentStatus(AppointmentStatusEntity status)
//        {
//            using (var _context = new Clinicdb_context())
//            {
//                _context.AppointmentStatuses.Update(status);
//                return _context.SaveChanges() > 0;
//            }
//        }

//        public static bool DeleteAppointmentStatus(int statusId)
//        {
//            using (var _context = new Clinicdb_context())
//            {
//                var status = _context.AppointmentStatuses.Find(statusId);
//                if (status == null) return false;
//                _context.AppointmentStatuses.Remove(status);
//                return _context.SaveChanges() > 0;
//            }
//        }

//        public static AppointmentStatusEntity GetAppointmentStatusById(int statusId)
//        {
//            using (var _context = new Clinicdb_context())
//            {
//                return _context.AppointmentStatuses.FirstOrDefault(x => x.Status_ID == statusId);
//            }
//        }

//        public static List<AppointmentStatusEntity> GetAllAppointmentStatuses()
//        {
//            using (var _context = new Clinicdb_context())
//            {
//                return _context.AppointmentStatuses.AsNoTracking().ToList();
//            }
//        }



//    }
//}

