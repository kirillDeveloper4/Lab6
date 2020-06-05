using CCL.Security.Identity;

namespace CCL.Security
{
    public class Authorization
    {
        private static UserBase _userBase = null;

        public static UserBase GetUser()
        {
            return _userBase;
        }

        public static void SetUser(UserBase userBase)
        {
            _userBase = userBase;
        }
    }
}