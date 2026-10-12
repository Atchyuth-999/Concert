using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertRepository.Model
{
    public class UserDTO
    {
        public int RegistrationId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
        public string Gender { get; set; }

        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string HomeAddress { get; set; }
        public string StreetAddress { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }

        public string HeardAboutConcert { get; set; }
        public string OtherSource { get; set; }

        public decimal VirtualConcertFee { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }

        public string PaymentMethod { get; set; }

        //public DateTime? CreatedDate { get; set; }

        //public DateTime? UpdatedDate { get; set; }


    }
}
