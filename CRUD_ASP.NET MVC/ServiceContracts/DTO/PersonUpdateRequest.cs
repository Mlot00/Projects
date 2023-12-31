﻿using Entities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
	public class PersonUpdateRequest
	{
		[Required(ErrorMessage ="Person ID cant be blank")]
		public Guid PersonID { get; set; }

		[Required(ErrorMessage = "Person Name can't be blank")]
		public string? PersonName { get; set; }

		[Required(ErrorMessage = "Email can't be blank")]
		[EmailAddress(ErrorMessage = "Email must be valid")]
		public string? Email { get; set; }

		[DataType(DataType.Date)]
		public DateTime? DateOfBirth { get; set; }

		public GenderOptions? Gender { get; set; }

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
				PersonID = PersonID,
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
