using System;
using Entities;

namespace ServiceContracts.DTO
{
	/// <summary>
	/// DTO class that is used as return type for most of CountriesService methods
	/// </summary>
	public class CountryResponse
	{
		public Guid CountryID { get; set; }
		public string? CountryName { get; set; }

		public override bool Equals(object? obj)
		{
			if (obj == null) return false;
			if (obj.GetType() != typeof(CountryResponse)) return false;

			CountryResponse country_to_compare = (CountryResponse)obj;

			return (country_to_compare.CountryID == this.CountryID && country_to_compare.CountryName == this.CountryName); 

		}
		public override string ToString()
		{
			return $"Country: {CountryName}, Id: {CountryID}";
		}
	}

	public static class CountryExtensions
	{
		public static CountryResponse ToCountryResposne(this Country country)
		{
			return new CountryResponse()
			{
				CountryID = country.CountryId,
				CountryName = country.CountryName,
			};
		}
	}
}
