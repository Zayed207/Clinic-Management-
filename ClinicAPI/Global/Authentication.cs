//using BusinessLayer;
//using System.Security.Cryptography;
//using System.Text;

//namespace APILayer.Global
//{
//    public class Authentication
//    {
//        public static clsUser CurrentUser;

//        public static bool _IsAuthenticated { get; private set; }

       
//        public static int _CurrentUserID { get; private set; }
//        private string HashPassword(string password)
//        {
//            using (SHA256 sha256Hash = SHA256.Create())
//            {
//                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
//                StringBuilder builder = new StringBuilder();
//                for (int i = 0; i < bytes.Length; i++)
//                {
//                    builder.Append(bytes[i].ToString("x2"));
//                }
//                return builder.ToString();
//            }
//        }
//        public static clsUser IsUserExist(string username,string password)
//        {
//            _IsAuthenticated = false;
//           var _CurrentUser= clsUser.GetUserByUserName(username,password);

//            if (_CurrentUser == null) return null;
//            else return _CurrentUser;


//        }

        

//    }
//}
