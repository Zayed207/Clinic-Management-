using DataLayer;
namespace BusinessLayer
{
    public class clsPermissions
    {
        public Dictionary<short,string> PermissionsDetails=new Dictionary<short,string>();

        enum enPermissionType {Doctor=1,Nures=2 ,Secertary=3,Patient=4,Register=5}



    }
}
