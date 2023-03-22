using ContactAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAPI.Test.MockData
{

    public class ContactMockData
    {
        public static List<Contact> GetContacts()
        {
            return new List<Contact>{
             new Contact{
                 Id = 1,
                 LastChangeTimestamp = 0,
                 FirstName = "Oshadhi",
                 LastName = "Liyanage",
                 Salutation = "Miss",
                 DisplayName = "Oshadhi",
                 Birthday = new DateTime(1996,05,09,9,15,0),
                 Email = "gayangikaoshadhi@gmail.com",
                 PhoneNumber = "1234567890",
             },
              new Contact{
                 Id = 2,
                 LastChangeTimestamp = 0,
                 FirstName = "Gayangika",
                 LastName = "Liyanage",
                 Salutation = "Miss",
                 DisplayName = "Gayangika",
                 Birthday = new DateTime(1996,08,09,9,15,0),
                 Email = "gayangikashadhi@gmail.com",
                 PhoneNumber = "1234567890",
             },
              new Contact{
                 Id = 3,
                 LastChangeTimestamp = 0,
                 FirstName = "Binara",
                 LastName = "Liyanage",
                 Salutation = "Miss",
                 DisplayName = "Oshadhi",
                 Birthday = new DateTime(1996,05,09,9,15,0),
                 Email = "gayangikshadhi@gmail.com",
                 PhoneNumber = "1234567890",
             }
         };
        }

        public static async Task<Contact> GetContact()
        {
            return new Contact
            {
                Id = 1,
                LastChangeTimestamp = 0,
                FirstName = "Oshadhi",
                LastName = "Liyanage",
                Salutation = "Miss",
                DisplayName = "Oshadhi",
                Birthday = new DateTime(1996, 05, 09, 9, 15, 0),
                Email = "gayangikaoshadhi@gmail.com",
                PhoneNumber = "1234567890",
            };
        }
    }
}
