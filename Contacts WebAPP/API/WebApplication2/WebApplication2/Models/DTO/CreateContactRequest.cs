using System.ComponentModel.DataAnnotations;


namespace WebApplication2.Models.DTO
{
	public class CreateContactRequest
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		[EmailAddress(ErrorMessage = "Email must be valid")]
		public string Email { get; set; }

		[Phone(ErrorMessage = "Phone number must be valid")]
		public string Phone { get; set; }

		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }

        public Guid Category { get; set; }
    }
}
