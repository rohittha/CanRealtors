using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realtor.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials
            {
                get
                {
                    return Error.Validation(
                        code: "Auth.InvalidCreds",
                        description: "Invalid redentials");
                }
            }
        }
    }
}
