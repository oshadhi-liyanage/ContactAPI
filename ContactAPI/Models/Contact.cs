using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactAPI.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Contact : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required, MinLength(2)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = true), MinLength(2)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = true), MinLength(2)]
        public string Salutation { get; set; }

        private string _displayName;

        [Required(AllowEmptyStrings = true), MinLength(2)]
        public string DisplayName
        {
            get
            {

                return _displayName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _displayName = $"{Salutation} {FirstName} {LastName}";
                }
                else
                {
                    _displayName = value;
                }
            }
        }
       
        public DateTime Birthday { get; set; }
        
        [NotMapped]
        public bool NotifyHasBirthdaySoon
        {
            get
            {
                DateTime nextBirthday = new DateTime(DateTime.Now.Year, Birthday.Month, Birthday.Day);
                if (nextBirthday < DateTime.Now)
                {
                    nextBirthday = nextBirthday.AddYears(1);
                }

                TimeSpan timeUntilNextBirthday = nextBirthday - DateTime.Now;
                if (timeUntilNextBirthday <= TimeSpan.FromDays(14))
                {
                    return true;
                }
                return false;

            }
        }

        [Required(AllowEmptyStrings = false), EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

    }
}
