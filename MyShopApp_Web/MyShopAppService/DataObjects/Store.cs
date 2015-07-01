using Microsoft.Azure.Mobile.Server;

namespace MyShopAppService.DataObjects
{
	public class Store : EntityData
	{
		public string Name { get; set; }
		public string LocationHint { get; set; }

		public string StreetAddress { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public string Image { get; set; }

		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public string MondayOpen { get; set; }
		public string MondayClose { get; set; }
		public string TuesdayOpen { get; set; }
		public string TuesdayClose { get; set; }
		public string WednesdayOpen { get; set; }
		public string WednesdayClose { get; set; }
		public string ThursdayOpen { get; set; }
		public string ThursdayClose { get; set; }
		public string FridayOpen { get; set; }
		public string FridayClose { get; set; }
		public string SaturdayOpen { get; set; }
		public string SaturdayClose { get; set; }
		public string SundayOpen { get; set; }
		public string SundayClose { get; set; }

		public string PhoneNumber { get; set; }

		public string Country { get; set; }

		public string LocationCode { get; set; }
	}
}
