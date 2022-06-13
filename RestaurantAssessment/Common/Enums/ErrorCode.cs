using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum ErrorCode
    {
        Unknown                 = -1,
        Success                 = 0,
        NotLoggedIn             = 1000,
        NotAuthorized           = 1001,
        TokenExpired            = 1002,
        UserNameOrPasswordError = 1003,
        UserNotFound            = 1004,
    }
}
