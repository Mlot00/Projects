﻿using System;
using ServiceContracts.Enums;
using Entities;
using System.ComponentModel.DataAnnotations;


namespace ServiceContracts.DTO
{
	/// <summary>
	/// Acts as a DTO for inserting a new person
	/// </summary>
	public class PersonAddRequest
	{
		[Required(ErrorMessage ="Person Name can't be blank")]
		public string? PersonName { get; set; }

		[Required(ErrorMessage ="Email can't be blank")]
		[EmailAddress(ErrorMessage ="Email must be valid")]
		[DataType(DataType.EmailAddress)]
		public string? Email { get; set; }

		[DataType(DataType.Date)]
		public DateTime? DateOfBirth { get; set; }

		[Required(ErrorMessage ="Gender must be chosen")]
		public GenderOptions? Gender { get; set; }

		[Required(ErrorMessage ="Country must be chosen")]
		public Guid? CountryID { get; set; }
		public string? Address { get; set; }

		public bool ReceiveNewsLetters { get; set; }

		/// <summary>
		/// Convwert the PersonAddRequest object nto a new object of Person type
		/// </summary>
		/// <returns></returns>
		public Person ToPerson()
		{
			return new Person()
			{
				PersonName = PersonName,
				Email = Email,
				DateOfBirth = DateOfBirth,
				Gender = Gender.ToString(),
				CountryID = CountryID,
				Address = Address,
				ReceiveNewsLetters = ReceiveNewsLetters

			};

		
		}
	}
}
