using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.ExternalServices.Abstractions
{
    public interface ITokenService
    {
        public string GenerateToken(AppUser user);

    }
}
