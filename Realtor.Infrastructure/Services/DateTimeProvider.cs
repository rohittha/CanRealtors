using Realtor.Application.Common.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realtor.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        // What is this doing? TODO understand the working
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
