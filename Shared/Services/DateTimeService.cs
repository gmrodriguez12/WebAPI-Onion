using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUTC => DateTime.UtcNow;
    }
}
