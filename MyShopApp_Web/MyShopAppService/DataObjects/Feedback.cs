using Microsoft.Azure.Mobile.Server;
using System;

namespace MyShopAppService.DataObjects
{
	public class Feedback : EntityData
	{
		public string Text { get; set; }
		public DateTime FeedbackDate { get; set; }
		public DateTime VisitDate { get; set; }
		public int Rating { get; set; }
		public int ServiceType { get; set; }
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public bool RequiresCall { get; set; }
		public string StoreName { get; set; }
	}
}
