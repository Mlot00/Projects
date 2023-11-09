using ServiceContracts;
using Entities;
using ServiceContracts.DTO;

namespace Services
{
	public class CountriesService : ICountriesService
	{
		private readonly List<Country> _countries;

		public CountriesService(bool initialize = true)
		{
			_countries = new List<Country>();
			if (initialize)
			{
				_countries.AddRange(new List<Country>() {
					new Country() {CountryName="USA", CountryId=Guid.Parse("CADDA45F-772E-46A4-B477-07917A0B4A70") },
					new Country() {CountryName="Poland", CountryId=Guid.Parse("B07DBCA5-EF64-4A5F-9314-172E9C84C9CF") },
					new Country() {CountryName="Austrialia", CountryId=Guid.Parse("EE68BA72-1CCE-4488-8982-BAD3DAB2A963") },
					new Country() {CountryName="Canada", CountryId=Guid.Parse("3046C4AE-76F3-4F1D-9175-1C8E0C0672C4") },
					new Country() {CountryName="India", CountryId=Guid.Parse("F5C3747A-3746-4C77-A9A0-8EA9CED408B8") },
				});
			}
		}

		public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
		{
			if (countryAddRequest == null)
			{
				throw new ArgumentNullException(nameof(countryAddRequest));
			}

			if (countryAddRequest.CountryName == null)
			{
				throw new ArgumentException(nameof(countryAddRequest.CountryName));
			}

			if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
			{
				throw new ArgumentException("Given country name already exist");
			}

			Country country = countryAddRequest.ToCountry();

			country.CountryId = Guid.NewGuid();

			_countries.Add(country);



			return country.ToCountryResposne();
		}

		public List<CountryResponse> GetAllCountries()
		{
			return _countries.Select(country => country.ToCountryResposne()).ToList();

		}

		public CountryResponse? GetCountryByCountryID(Guid? countryID)
		{
			if (countryID == null)
				return null;

			Country? country_resposne_from_list = _countries.FirstOrDefault(country => country.CountryId == countryID);

			if (country_resposne_from_list == null)
				return null;

			return country_resposne_from_list.ToCountryResposne();

		}
	}
}