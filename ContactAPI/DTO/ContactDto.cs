
using System.ComponentModel.DataAnnotations;

namespace ContactAPI.DTO
{
    /// <summary>
    /// Data Transfer Object for Contact Entity
    /// </summary>
    public class ContactDto
    {
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
        [Required(AllowEmptyStrings = false), EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public long LastChangeTimestamp { get; }
        public long CreationTimestamp { get; }
    }
}
