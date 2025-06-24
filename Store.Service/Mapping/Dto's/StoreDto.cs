using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Mapping.Dto_s
{
    public class StoreDto
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Name_Ar { get; set; }
        public string Name_En { get; set; }
        public string UserId { get; set; }
        public int? StoreTypeId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? Description_En { get; set; }
        public string? Description_Ar { get; set; }
        public bool? IsUniqueStore { get; set; }
        public bool? IsDeleted { get; set; }
        public string? IconPath { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile Image { get; set; }
        public string? Location { get; set; }
        public decimal? Location_Lat { get; set; }
        public decimal? Location_Lang { get; set; }
        public bool? IsOpen { get; set; }
        public bool? hasOffer { get; set; }
        public string? OfferValue { get; set; }
        public bool? IsDeliveryFree { get; set; }
        public string? PhoneNumber { get; set; }
        public int StoreStatus { get; set; }
        public string StatusName => ((StoreStatus)StoreStatus).ToString();
        public ICollection<RateDto> Rates { get; set; }

    }
}
