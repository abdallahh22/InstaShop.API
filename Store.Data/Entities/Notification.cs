using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Header_En { get; set; }
        public string Header_Ar { get; set; }
        public string Body_En { get; set; }
        public string Body_Ar { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int? StoreId { get; set; }
        public store store { get; set; }
        public ICollection<NotificationUser> NotificationUsers { get; set; }
        public bool? IS_Deleted {  get; set; }
    }
}
