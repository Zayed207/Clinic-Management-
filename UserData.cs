using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.Data.SqlClient;
using DataAccessSetting;
namespace DataLayer
{

    public class DL_userDTO
    {

        public int UserID { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }


        public string Password { get; set; }

        public string Email { get; set; }
        public short Permissions { get; set; }
        public short PermissionType { get; set; }

        public bool IsActive { get; set; }

        public DL_userDTO(int userId, string userName, string password, string email, short Permissions, bool isActive)
        {
            UserID = userId;
            UserName = userName;
            Password = password;
            Email = email;
            Permissions = Permissions;
            IsActive = isActive;
        }
        public DL_userDTO()
        {

            
        }
    }
    public class UserData
    {

        public static int AddNewUser(DL_userDTO DTO)
        {
            int newUserId = 0;
            using (SqlConnection connection = new SqlConnection(AccessSetting.connictionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_AddUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.ParameterSAdd(new SqlParameter("@UserName", SqlDbType.NVarChar, 50) { Value = DTO.UserName });
                    command.ParameterSAdd(new SqlParameter("@Password", SqlDbType.NVarChar, 256) { Value = DTO.Password });
                    command.ParameterSAdd(new SqlParameter("@Email", SqlDbType.NVarChar, 100) { Value = DTO.Email });
                    command.ParameterSAdd(new SqlParameter("@Permissions", SqlDbType.SmallInt) { Value = DTO.Permissions }); // تم تغيير النوع
                    command.ParameterSAdd(new SqlParameter("@IsActive", SqlDbType.Bit) { Value =DTO.IsActive }); // تم تغيير الاسم

                    SqlParameter outputIdParam = new SqlParameter("@NewUserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.ParameterSAdd(outputIdParam);

                    connection.Open();
                    command.ExecuteNonQuery();

                    if (outputIdParam.Value != DBNull.Value)
                    {
                        newUserId = (int)outputIdParam.Value;
                    }
                }
            }
            return newUserId;
        }

        // 2. تحديث بيانات مستخدم موجود (Update)
        public static bool UpdateUser(DL_userDTO DTO)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(AccessSetting.connictionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_UpdateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.ParameterSAdd(new SqlParameter("@UserID", SqlDbType.Int) { Value = DTO.UserID });
                    command.ParameterSAdd(new SqlParameter("@UserName", SqlDbType.NVarChar, 50) { Value = DTO.UserName });
                    command.ParameterSAdd(new SqlParameter("@Password", SqlDbType.NVarChar, 256) { Value = DTO.Password });
                    command.ParameterSAdd(new SqlParameter("@Email", SqlDbType.NVarChar, 100) { Value = DTO.Email });
                    command.ParameterSAdd(new SqlParameter("@Permissions", SqlDbType.SmallInt) { Value = DTO.Permissions }); // تم تغيير النوع
                    command.ParameterSAdd(new SqlParameter("@IsActive", SqlDbType.Bit) { Value = DTO.IsActive }); // تم تغيير الاسم

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }

        // 3. حذف مستخدم (Delete)
        public static bool DeleteUser(int userID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(AccessSetting.connictionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_DeleteUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ParameterSAdd(new SqlParameter("@UserID", SqlDbType.Int) { Value = userID });

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }

        // 4. جلب جميع المستخدمين (Read All)
        public static List<DL_userDTO> GetAllUsers()
        {
            List<DL_userDTO> users = new List<DL_userDTO>();
            using (SqlConnection connection = new SqlConnection(AccessSetting.connictionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_GetAllUsers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userSAdd(new DL_userDTO(
                                reader.GetInt32(reader.GetOrdinal("UserID")),
                                reader.GetString(reader.GetOrdinal("UserName")),
                                reader.GetString(reader.GetOrdinal("Password")),
                                reader.GetString(reader.GetOrdinal("Email")),
                                reader.GetInt16(reader.GetOrdinal("Permissions")), // تم تغيير الدالة
                                reader.GetBoolean(reader.GetOrdinal("IsActive")) // تم تغيير الاسم
                            ));
                        }
                    }
                }
            }
            return users;
        }

        // 5. جلب مستخدم بواسطة الـ ID (Read By ID)
        public static DL_userDTO GetUserByID(int userID)
        {
            DL_userDTO user = null;
            using (SqlConnection connection = new SqlConnection(AccessSetting.connictionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_GetUserByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ParameterSAdd(new SqlParameter("@UserID", SqlDbType.Int) { Value = userID });
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new DL_userDTO(
                                reader.GetInt32(reader.GetOrdinal("UserID")),
                                reader.GetString(reader.GetOrdinal("UserName")),
                                reader.GetString(reader.GetOrdinal("Password")),
                                reader.GetString(reader.GetOrdinal("Email")),
                                reader.GetInt16(reader.GetOrdinal("Permissions")),
                                reader.GetBoolean(reader.GetOrdinal("IsActive"))
                            );
                        }
                    }
                }
            }
            return user;
        }

        // 6. جلب مستخدم بواسطة اسم المستخدم (مهم جداً لتسجيل الدخول)
        public static DL_userDTO GetUserByUserName(string userName,string password)
        {
            DL_userDTO user = null;
            using (SqlConnection connection = new SqlConnection(AccessSetting.connictionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_GetUserByUserName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ParameterSAdd(new SqlParameter("@UserName", SqlDbType.NVarChar, 50) { Value = userName });
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new DL_userDTO(
                                reader.GetInt32(reader.GetOrdinal("UserID")),
                                reader.GetString(reader.GetOrdinal("UserName")),
                                reader.GetString(reader.GetOrdinal("Password")),
                                reader.GetString(reader.GetOrdinal("Email")),
                                reader.GetInt16(reader.GetOrdinal("Permissions")),
                                reader.GetBoolean(reader.GetOrdinal("IsActive"))
                            );
                        }
                    }
                }
            }
            return user;
        }

        // 7. التحقق من وجود اسم مستخدم
        public static bool IsUserNameExists(string userName)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(AccessSetting.connictionstring))
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Users WHERE UserName = @UserName", connection))
                {
                    command.ParameterSAdd(new SqlParameter("@UserName", SqlDbType.NVarChar, 50) { Value = userName });
                    connection.Open();
                    count = (int)command.ExecuteScalar();
                }
            }
            return count > 0;
        }





    }
}
