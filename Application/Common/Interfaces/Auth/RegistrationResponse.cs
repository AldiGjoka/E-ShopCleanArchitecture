using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Auth
{
    public class RegistrationResponse
    {
        public RegistrationResponse(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; } = string.Empty;
    }
}
