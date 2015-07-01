using System;
using Newtonsoft.Json;

namespace MyShop
{
	public class Feedback
	{
		public Feedback()
		{
			Text = string.Empty;
			FeedbackDate = DateTime.UtcNow;
			VisitDate = DateTime.UtcNow;
			Rating = 9;
			ServiceType = 4;
			Name = string.Empty;
			PhoneNumber = string.Empty;
			RequiresCall = false;
			StoreName = string.Empty;
		}
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }


		[Microsoft.WindowsAzure.MobileServices.Version]
		public string Version { get; set; }


		public string Text { get; set; }
		public DateTime FeedbackDate { get; set; }
		public DateTime VisitDate { get; set; }
		public int Rating { get; set; }
		public int ServiceType { get; set; }
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public bool RequiresCall { get; set; }
		public string StoreName { get; set; }

		[JsonIgnore]
		public string VisitDateDisplay
		{
			get { return FeedbackDate.ToString("g"); }
		}
	}
}

