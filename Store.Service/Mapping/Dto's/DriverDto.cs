using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s
{
    public class DriverDto
    {
        public int DriverId { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string TruckId { get; set; }
        public string PersonalId_Photo { get; set; }
        public string LicenseId_Photo { get; set; }
        public string ProfilePhoto { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
