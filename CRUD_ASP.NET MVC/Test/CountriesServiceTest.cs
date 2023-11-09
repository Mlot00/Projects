using ServiceContracts;
using Entities;
using Services;
using ServiceContracts.DTO;
using System.Security.Cryptography.X509Certificates;
using Xunit.Abstractions;

namespace Test
{

	public class CountriesServiceTest
	{
		private readonly ICountriesService _countriesService;
		private readonly ITestOutputHelper _outputHelper;

		public CountriesServiceTest(ITestOutputHelper outputHelper)
		{
			_countriesService = new CountriesService(false);
			_outputHelper = outputHelper;
		}

		#region AddCountry
		//When CountryAddRequest is null it should throw ArgumentNullException
		[Fact]
		public void AddCountry_NullCountry()
		{
			//Arange
			CountryAddRequest request = null;



			//Asert
			Assert.Throws<ArgumentNullException>(() =>
			{
				//act
				_countriesService.AddCountry(request);
			});
		}

		//Whgne the CountryName is null it should throw ArgumentException

		[Fact]
		public void AddCountry_CountryNameIsNull()
		{
			//Arange
			CountryAddRequest request = new CountryAddRequest()
			{
				CountryName = null
			};



			//Asert
			Assert.Throws<ArgumentException>(() =>
			{
				//act
				_countriesService.AddCountry(request);
			});
		}

		//Whgne the CountryName is duplicate it should throw ArgumentException

		[Fact]
		public void AddCountry_DuplicateCountryName()
		{
			//Arange
			CountryAddRequest request1 = new CountryAddRequest()
			{ CountryName = "USA" };
			CountryAddRequest request2 = new CountryAddRequest()
			{ CountryName = "USA" };



			//Asert
			Assert.Throws<ArgumentException>(() =>
			{
				//act
				_countriesService.AddCountry(request1);
				_countriesService.AddCountry(request2);
			});
		}

		//when you suply proper country name it should add the country to the existing list of countires 

		[Fact]
		public void AddCountry_ProperCountryDetails()
		{
			//Arange
			CountryAddRequest request = new CountryAddRequest()
			{ CountryName = "Japan" };

			//act
			CountryResponse response = _countriesService.AddCountry(request);
			List<CountryResponse> response_list = _countriesService.GetAllCountries();


			//Asert
			Assert.True(response.CountryID != Guid.Empty);
			Assert.Contains(response, response_list);
		}
		#endregion

		#region GetAllCountries

		[Fact]
		public void GetAllCountries_EmptyList()
		{
			//Act
			List<CountryResponse> actual_countries_from_response_list = _countriesService.GetAllCountries();

			//Assert
			Assert.Empty(actual_countries_from_response_list);

		}

		[Fact]
		public void GetAllCountry_AddFewCountries()
		{
			//Arrange
			List<CountryAddRequest> country_request_list = new List<CountryAddRequest>()
			{
				new CountryAddRequest() { CountryName = "UK"},
				new CountryAddRequest() {CountryName = "USA"}
			};


			//ACT
			List<CountryResponse> country_response_list = new List<CountryResponse>();
			foreach (CountryAddRequest country_request in country_request_list)
			{
				country_response_list.Add(_countriesService.AddCountry(country_request));
			}

			List<CountryResponse> actual_countries_from_list = _countriesService.GetAllCountries();

			//Asssert
			foreach(CountryResponse expected_country in country_response_list)
			{
				Assert.Contains(expected_country, actual_countries_from_list);
			}
		}


		#endregion

		#region GetCountryByCountryID

		[Fact]
		public void GetCountryBtCountryID_NullCountryID()
		{
			//Arange
			Guid? countryID = null;

			//ACt
			CountryResponse? country_resposne_from_get_method = _countriesService.GetCountryByCountryID(countryID);

			//assert
			Assert.Null(country_resposne_from_get_method);
		}

		[Fact]
		public void GetCountryByCountryId_ValidCountryID()
		{
			//Arrange
			CountryAddRequest country_add_request = new CountryAddRequest()
			{ CountryName = "China"};
			CountryResponse country_resposne_from_add = _countriesService.AddCountry(country_add_request);

			//act
			CountryResponse? country_resposne_from_get = _countriesService.GetCountryByCountryID(country_resposne_from_add.CountryID);

			_outputHelper.WriteLine($"Expected: {country_resposne_from_add}");
			_outputHelper.WriteLine($"Actual: {country_resposne_from_get}");

			//asert
			Assert.Equal(country_resposne_from_add, country_resposne_from_get);
		}
		#endregion

	}
}

