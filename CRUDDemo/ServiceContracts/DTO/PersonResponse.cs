using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ServiceContracts.Enums;

namespace ServiceContracts.DTO
{
	/// <summary>
	/// Represents DTO class that is used as return type of most methods od Person Service
	/// </summary>
	public class PersonResponse
	{
		public string? PersonName { get; set; }

		public Guid PersonID { get; set; }
		public string? Email { get; set; }

		public DateTime? DateOfBirth { get; set; }

		public string? Gender { get; set; }

		public Guid? CountryID { get; set; }

		public string? Country { get; set; }
		public string? Address { get; set; }

		public bool ReceiveNewsLetters { get; set; }
		public double? Age { get; set; }

		public override bool Equals(object? obj)
		{
			if (obj == null)
				return false;

			if (obj.GetType() != typeof(PersonResponse))
				return false;

			PersonResponse person = (PersonResponse)obj;
			return PersonID == person.PersonID && PersonName == person.PersonName;

		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return $"PersonId: {PersonID}, Person Name: {PersonName}, Email: {Email}, Country ID: {CountryID}, Country: {Country}";
		}

		public PersonUpdateRequest ToPersonUpdateRequest()
		{
			return new PersonUpdateRequest()
			{
				PersonID = PersonID,
				Email = Email,
				DateOfBirth = DateOfBirth,
				ReceiveNewsLetters = ReceiveNewsLetters,
				Address = Address,
				Gender = (GenderOptions)Enum.Parse(typeof(GenderOptions), Gender, true),
				CountryID = CountryID,
				PersonName = PersonName,
				
			};
		}
	}

	public static class PersonExtensions
	{
		public static PersonResponse ToPersonResponse(this Person person)
		{
			return new PersonResponse
			{
				PersonName = person.PersonName,
				PersonID = person.PersonID,
				Email = person.Email,
				DateOfBirth = person.DateOfBirth,
				Gender = person.Gender,
				CountryID = person.CountryID,
				Address = person.Address,
				ReceiveNewsLetters = person.ReceiveNewsLetters,
				Age = (person.DateOfBirth != null)?  Math.Round((DateTime.Now - person.DateOfBirth.Value).TotalDays / 365.25) : null,
			};
		}
	}
}

		
	

