using ServiceContracts.DTO;

namespace ServiceContracts
{
	/// <summary>
	/// Represents business logic for manipulating Country entity
	/// </summary>
	public interface ICountriesService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="countryAddRequest"></param>
		/// <returns>Return the country object after ading it</returns>
		CountryResponse AddCountry(CountryAddRequest? countryAddRequest);

		/// <summary>
		/// returns all countries from the list 
		/// </summary>
		/// <returns>all countries from thr list as list of CountryResponse</returns>
		List<CountryResponse> GetAllCountries();

		/// <summary>
		/// returns country object based on the given country d
		/// </summary>
		/// <param name="countryID">CountryID (guid) to search</param>
		/// <returns> Matching coiuntry object as CountryResponse</returns> 
		CountryResponse? GetCountryByCountryID(Guid? countryID);

	}
}