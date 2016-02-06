using System;
using Newtonsoft.Json;
using static System.DateTime;

namespace MyShop
{
	public class Feedback
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }


        [Microsoft.WindowsAzure.MobileServices.Version]
		public string Version { get; set; }


		public string Text { get; set; } = string.Empty;
        public DateTime FeedbackDate { get; set; } = UtcNow;
        public DateTime VisitDate { get; set; } = UtcNow;
        public int Rating { get; set; } = 9;
        public int ServiceType { get; set; } = 4;
		public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool RequiresCall { get; set; } = false;
        public string StoreName { get; set; } = string.Empty;

        [JsonIgnore]
		public string VisitDateDisplay => FeedbackDate.ToString("g"); 

        public override string ToString() => 
                $"{nameof(Name)}: {Name} " +
                $"{nameof(StoreName)}: {StoreName} " +
                $"{nameof(RequiresCall)}: {RequiresCall} " +
                $"{nameof(VisitDateDisplay)}: {VisitDateDisplay} " +
                $"{nameof(Name)}: {ServiceType} " +
                $"{nameof(Rating)}: {Rating} " +
                $"{nameof(Text)}: {Text} ";
        

        [JsonIgnore]
        public string SortBy => FeedbackDate.ToString("MMMM yyyy");
    }
}

