using System;
using System.Collections.Generic;
using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using ServiceContracts.Enums;
using Xunit.Abstractions;
using System.Linq;

namespace Test
{
	public class PersonsServiceTest
	{
		private readonly IPersonsService _personService;
		private readonly ICountriesService _countriesService;
		private readonly ITestOutputHelper _testOutputHelper;

		public PersonsServiceTest(ITestOutputHelper testOutputHelper)
		{
			_personService = new PersonsService();
			_countriesService = new CountriesService(false);
			_testOutputHelper = testOutputHelper;
		}

		#region AddPerson
		[Fact]
		public void AddPerson_NullPerson()
		{
			PersonAddRequest? personAddRequest = null;


			Assert.Throws<ArgumentNullException>(() =>
			{
				_personService.AddPerson(personAddRequest);
			});

		}

		[Fact]
		public void AddPerson_PersonNameIsNull()
		{
			PersonAddRequest? personAddRequest = new PersonAddRequest() { PersonName = null };

			Assert.Throws<ArgumentException>(() =>
			{
				_personService.AddPerson(personAddRequest);
			});

		}

		[Fact]
		public void AddPerson_ProperPersonDetails()
		{
			PersonAddRequest personAddRequest = new PersonAddRequest()
			{
				PersonName = "Krystian",
				Address = "sample addres",
				Email = "sample@person.pl",
				CountryID = Guid.NewGuid(),
				DateOfBirth = DateTime.Parse("2000-10-10"),
				Gender = GenderOptions.Female,
				ReceiveNewsLetters = true,
			};

			PersonResponse personResponse_from_addRequest = _personService.AddPerson(personAddRequest);

			List<PersonResponse> personResponsList = _personService.GetAllPersons();

			Assert.True(personResponse_from_addRequest.PersonID != Guid.Empty);

			Assert.Contains(personResponse_from_addRequest, personResponsList);

		}

		#endregion

		#region GetPersonPersonID

		[Fact]
		public void GetPersonByPersonID_NullPersonID()
		{
			Guid? personID = null;

			PersonResponse? personByPersonID = _personService.GetPersonByPersonID(personID);

			Assert.Null(personByPersonID);

		}

		[Fact]
		public void GetPersonByPersonID_ValidPersonID()
		{
			CountryAddRequest countryAddRequest = new CountryAddRequest() { CountryName = "China" };

			CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

			PersonAddRequest request = new PersonAddRequest()
			{
				PersonName = "Name",
				Email = "valid@person.pl",
				CountryID = countryResponse.CountryID
			};

			PersonResponse? personResponse = _personService.AddPerson(request);

			PersonResponse? personResponse_fromGetPersonByID = _personService.GetPersonByPersonID(personResponse.PersonID);

			Assert.Equal(personResponse, personResponse_fromGetPersonByID);



		}

		#endregion

		#region GetAllPersons

		[Fact]
		public void GetAllPersons_EmptyList()
		{
			List<PersonResponse>? persons_from_get = _personService.GetAllPersons();

			Assert.Empty(persons_from_get);
		}


		[Fact]
		public void GetAllPersons_ProperList()
		{
			CountryAddRequest countryAddRequest1 = new CountryAddRequest() { CountryName = "china" };
			CountryAddRequest countryAddRequest2 = new CountryAddRequest() { CountryName = "Japan" };
			CountryResponse countryResposne1 = _countriesService.AddCountry(countryAddRequest1);
			CountryResponse countryResposne2 = _countriesService.AddCountry(countryAddRequest2);

			PersonAddRequest personAddRequest1 = new PersonAddRequest()
			{
				PersonName = "Name",
				Email = "mail@exapl.pl",
				CountryID = countryResposne1.CountryID
			};
			PersonAddRequest personAddRequest2 = new PersonAddRequest()
			{
				PersonName = "First",
				Email = "person@exapl.pl",
				CountryID = countryResposne2.CountryID
			};
			PersonAddRequest personAddRequest3 = new PersonAddRequest()
			{
				PersonName = "LastN",
				Email = "sample@exapl.pl",
				CountryID = countryResposne1.CountryID
			};

			List<PersonResponse>? personResponsesList = new List<PersonResponse>();
			List<PersonAddRequest>? personsAddRequestList = new List<PersonAddRequest>()
			{ personAddRequest1, personAddRequest2, personAddRequest3 };

			foreach (PersonAddRequest personAddRequest in personsAddRequestList)
			{
				PersonResponse? personResponse = _personService.AddPerson(personAddRequest);
				personResponsesList.Add(personResponse);
			}

			_testOutputHelper.WriteLine("Expected: ");
			foreach (PersonResponse personResponseFromAdd in personResponsesList)
			{
				_testOutputHelper.WriteLine(personResponseFromAdd.ToString());
			}

			List<PersonResponse>? personResponses_from_Get = _personService.GetAllPersons();

			foreach (PersonResponse personResponse in personResponsesList)
			{
				Assert.Contains(personResponse, personResponses_from_Get);
			}

			_testOutputHelper.WriteLine("Actual: ");
			foreach (PersonResponse personResponseFromAdd in personResponses_from_Get)
			{
				_testOutputHelper.WriteLine(personResponseFromAdd.ToString());
			}
		}
		#endregion

		#region GetFilteredPersons

		[Fact]
		public void GetFilteredPersons_EmptySearchText()
		{
			CountryAddRequest countryAddRequest1 = new CountryAddRequest() { CountryName = "china" };
			CountryAddRequest countryAddRequest2 = new CountryAddRequest() { CountryName = "Japan" };
			CountryResponse countryResposne1 = _countriesService.AddCountry(countryAddRequest1);
			CountryResponse countryResposne2 = _countriesService.AddCountry(countryAddRequest2);

			PersonAddRequest personAddRequest1 = new PersonAddRequest()
			{
				PersonName = "Name",
				Email = "mail@exapl.pl",
				CountryID = countryResposne1.CountryID
			};
			PersonAddRequest personAddRequest2 = new PersonAddRequest()
			{
				PersonName = "First",
				Email = "person@exapl.pl",
				CountryID = countryResposne2.CountryID
			};
			PersonAddRequest personAddRequest3 = new PersonAddRequest()
			{
				PersonName = "LastN",
				Email = "sample@exapl.pl",
				CountryID = countryResposne1.CountryID
			};

			List<PersonResponse>? personResponsesList = new List<PersonResponse>();
			List<PersonAddRequest>? personsAddRequestList = new List<PersonAddRequest>()
			{ personAddRequest1, personAddRequest2, personAddRequest3 };

			foreach (PersonAddRequest personAddRequest in personsAddRequestList)
			{
				PersonResponse? personResponse = _personService.AddPerson(personAddRequest);
				personResponsesList.Add(personResponse);
			}

			_testOutputHelper.WriteLine("Expected: ");
			foreach (PersonResponse personResponseFromAdd in personResponsesList)
			{
				_testOutputHelper.WriteLine(personResponseFromAdd.ToString());
			}

			List<PersonResponse>? personResponses_from_Get = _personService.GetFilteredPersons(nameof(Person.PersonName), "");

			foreach (PersonResponse personResponse in personResponsesList)
			{
				Assert.Contains(personResponse, personResponses_from_Get);
			}

			_testOutputHelper.WriteLine("Actual: ");
			foreach (PersonResponse personResponseFromAdd in personResponses_from_Get)
			{
				_testOutputHelper.WriteLine(personResponseFromAdd.ToString());
			}
		}

		[Fact]
		public void GetFilteredPersons_SearchByPersonName()
		{
			CountryAddRequest countryAddRequest1 = new CountryAddRequest() { CountryName = "china" };
			CountryAddRequest countryAddRequest2 = new CountryAddRequest() { CountryName = "Japan" };
			CountryResponse countryResposne1 = _countriesService.AddCountry(countryAddRequest1);
			CountryResponse countryResposne2 = _countriesService.AddCountry(countryAddRequest2);

			PersonAddRequest personAddRequest1 = new PersonAddRequest()
			{
				PersonName = "Name",
				Email = "mail@exapl.pl",
				CountryID = countryResposne1.CountryID
			};
			PersonAddRequest personAddRequest2 = new PersonAddRequest()
			{
				PersonName = "First",
				Email = "person@exapl.pl",
				CountryID = countryResposne2.CountryID
			};
			PersonAddRequest personAddRequest3 = new PersonAddRequest()
			{
				PersonName = "LastNaMe",
				Email = "sample@exapl.pl",
				CountryID = countryResposne1.CountryID
			};

			List<PersonResponse>? personResponsesList = new List<PersonResponse>();
			List<PersonAddRequest>? personsAddRequestList = new List<PersonAddRequest>()
			{ personAddRequest1, personAddRequest2, personAddRequest3 };

			foreach (PersonAddRequest personAddRequest in personsAddRequestList)
			{
				PersonResponse? personResponse = _personService.AddPerson(personAddRequest);
				personResponsesList.Add(personResponse);
			}

			_testOutputHelper.WriteLine("Expected: ");
			foreach (PersonResponse personResponseFromAdd in personResponsesList)
			{
				_testOutputHelper.WriteLine(personResponseFromAdd.ToString());
			}

			List<PersonResponse>? personResponses_from_Get = _personService.GetFilteredPersons(nameof(Person.PersonName), "me");

			foreach (PersonResponse personResponse in personResponsesList)
			{
				if (personResponse.PersonName != null)
				{
					if (personResponse.PersonName.Contains("me", StringComparison.OrdinalIgnoreCase))
					{
						Assert.Contains(personResponse, personResponses_from_Get);
					}
				}
			}

			_testOutputHelper.WriteLine("Actual: ");
			foreach (PersonResponse personResponseFromAdd in personResponses_from_Get)
			{
				_testOutputHelper.WriteLine(personResponseFromAdd.ToString());
			}
		}

		#endregion

		#region GetSortedPersons

		[Fact]
		public void GetSortedPersons()
		{
			CountryAddRequest countryAddRequest1 = new CountryAddRequest() { CountryName = "china" };
			CountryAddRequest countryAddRequest2 = new CountryAddRequest() { CountryName = "Japan" };
			CountryResponse countryResposne1 = _countriesService.AddCountry(countryAddRequest1);
			CountryResponse countryResposne2 = _countriesService.AddCountry(countryAddRequest2);

			PersonAddRequest personAddRequest1 = new PersonAddRequest()
			{
				PersonName = "Name",
				Email = "mail@exapl.pl",
				CountryID = countryResposne1.CountryID
			};
			PersonAddRequest personAddRequest2 = new PersonAddRequest()
			{
				PersonName = "First",
				Email = "person@exapl.pl",
				CountryID = countryResposne2.CountryID
			};
			PersonAddRequest personAddRequest3 = new PersonAddRequest()
			{
				PersonName = "LastNaMe",
				Email = "sample@exapl.pl",
				CountryID = countryResposne1.CountryID
			};

			List<PersonResponse>? personResponsesList = new List<PersonResponse>();
			List<PersonAddRequest>? personsAddRequestList = new List<PersonAddRequest>()
			{ personAddRequest1, personAddRequest2, personAddRequest3 };

			foreach (PersonAddRequest personAddRequest in personsAddRequestList)
			{
				PersonResponse? personResponse = _personService.AddPerson(personAddRequest);
				personResponsesList.Add(personResponse);
			}

			_testOutputHelper.WriteLine("Expected: ");
			foreach (PersonResponse personResponseFromAdd in personResponsesList)
			{
				_testOutputHelper.WriteLine(personResponseFromAdd.ToString());
			}

			List<PersonResponse>? personResponses_from_GetSorted = _personService.
				GetSortedPersons(personResponsesList, nameof(Person.PersonName), SortOrderOptions.DESC);

			_testOutputHelper.WriteLine("Actual: ");
			foreach (PersonResponse personResponseFromAdd in personResponses_from_GetSorted)
			{
				_testOutputHelper.WriteLine(personResponseFromAdd.ToString());
			}

			personResponsesList = personResponsesList.OrderByDescending(temp => temp.PersonName).ToList();

			for (int i = 0; i < personResponsesList.Count; i++)
			{
				Assert.Equal(personResponses_from_GetSorted[i], personResponsesList[i]);
			}


		}

		#endregion

		#region UpdatePerson

		[Fact]
		public void UpdatePerson_NullPerson()
		{
			PersonUpdateRequest? personUpdateRequest = null;

			Assert.Throws<ArgumentNullException>(() =>
			{
				_personService.UpdatePerson(personUpdateRequest);
			});
		}

		[Fact]
		public void UpdatePerson_InvalidPersonID()
		{
			PersonUpdateRequest? personUpdateRequest = new PersonUpdateRequest()
			{
				PersonID = Guid.NewGuid()
			};

			Assert.Throws<ArgumentException>(() =>
			{
				_personService.UpdatePerson(personUpdateRequest);
			});
		}

		[Fact]
		public void UpdatePerson_PersonNameIsNull()
		{
			CountryAddRequest countryAddRequest = new CountryAddRequest() { CountryName = "UK" };
			CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

			PersonAddRequest personAddRequest = new PersonAddRequest()
			{
				CountryID = countryResponse.CountryID,
				PersonName = "PapaJohn",
				Email = "mail@ads.com",
				Gender = GenderOptions.Male
			};

			PersonResponse personResponse = _personService.AddPerson(personAddRequest);

			PersonUpdateRequest? personUpdateRequest = personResponse.ToPersonUpdateRequest();
			personUpdateRequest.PersonName = null;

			Assert.Throws<ArgumentException>(() =>
			{
				_personService.UpdatePerson(personUpdateRequest);
			});
		}

		[Fact]
		public void UpdatePerson_PersonFullDetails()
		{
			CountryAddRequest countryAddRequest = new CountryAddRequest() { CountryName = "UK" };
			CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

			PersonAddRequest personAddRequest = new PersonAddRequest()
			{
				CountryID = countryResponse.CountryID,
				PersonName = "PapaJohn",
				Email = "mail@ads.com",
				Address = "adres",
				DateOfBirth = DateTime.Parse("2000-10-10"),
				Gender = GenderOptions.Male,
				ReceiveNewsLetters = true,
			};

			PersonResponse personResponse_fromAdd = _personService.AddPerson(personAddRequest);

			PersonUpdateRequest? personUpdateRequest = personResponse_fromAdd.ToPersonUpdateRequest();
			personUpdateRequest.PersonName = "Wiliam";
			personUpdateRequest.Email = "update@mial.com";

			PersonResponse personResponse_afterUpdate = _personService.UpdatePerson(personUpdateRequest);

			PersonResponse? personResponse_fromGetPersonByPersonID = _personService.GetPersonByPersonID(personUpdateRequest.PersonID);

			Assert.Equal(personResponse_fromGetPersonByPersonID, personResponse_afterUpdate);

		}
		#endregion

		#region DeletePerson

		[Fact]
		public void DeletePerson_ValidPersonID()
		{
			CountryAddRequest countryAddRequest = new CountryAddRequest() { CountryName = "Japan" };
			CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

			PersonAddRequest personAddRequest = new PersonAddRequest()
			{
				CountryID = countryResponse.CountryID,
				PersonName = "Jacek",
				Email = "email@ds.com"
			};

			PersonResponse personResponse_fromAdd = _personService.AddPerson(personAddRequest);

			bool idDeleted = _personService.DeletePerson(personResponse_fromAdd.PersonID);

			Assert.True(idDeleted);
		}

		[Fact]
		public void DeletePerson_InValidPersonID()
		{
			CountryAddRequest countryAddRequest = new CountryAddRequest() { CountryName = "Japan" };
			CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

			PersonAddRequest personAddRequest = new PersonAddRequest()
			{
				CountryID = countryResponse.CountryID,
				PersonName = "Jacek",
				Email = "email@ds.com"
			};

			PersonResponse personResponse_fromAdd = _personService.AddPerson(personAddRequest);

			bool idDeleted = _personService.DeletePerson(Guid.NewGuid());

			Assert.False(idDeleted);
		}


		#endregion

	}
}
