using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyShop
{
	public class FeedbackViewModel : BaseViewModel
	{
		IDataStore dataStore;
		public FeedbackViewModel (Page page) : base (page)
		{
			
			this.dataStore = DependencyService.Get<IDataStore> ();
			this.Title = "Leave Feedback";
			StoreName = string.Empty;
		}

		public async Task<IEnumerable<Store>> GetStoreAsync()
		{
			if (IsBusy)
				return new List<Store>();

			IsBusy = true;
			IEnumerable<Store> stores = null;
			try{


				return await dataStore.GetStoresAsync ();

			}catch(Exception ex) {
				page.DisplayAlert ("Uh Oh :(", "Unable to gather stores.", "OK");
				Xamarin.Insights.Report (ex);
			}
			finally {
				IsBusy = false;
			}

			return new List<Store> ();

		}

		Command saveFeedbackCommand;
		public Command SaveFeedbackCommand
		{
			get {
				return saveFeedbackCommand ??
					(saveFeedbackCommand = new Command (async () => await ExecuteSaveFeedbackCommand (), () => {return !IsBusy;}));
			}
		}

		async Task ExecuteSaveFeedbackCommand()
		{
			if (IsBusy)
				return;

			if(string.IsNullOrWhiteSpace(Text))
			{
				await page.DisplayAlert("Enter Feedback", "Please enter some feedback for our team.", "OK");
				return;
			}

			Message = "Submitting feedback...";
			IsBusy = true;
			saveFeedbackCommand.ChangeCanExecute ();
			try{
				await dataStore.AddFeedbackAsync(new Feedback
					{
						Text = this.Text,
						FeedbackDate = DateTime.UtcNow,
						VisitDate = Date,
						Rating = Rating,
						ServiceType = ServiceType,
						StoreName = StoreName,
						Name = Name,
						PhoneNumber = PhoneNumber,
						RequiresCall = RequiresCall,
					});
			}catch(Exception ex) {
				page.DisplayAlert ("Uh Oh :(", "Unable to save feedback, please try again.", "OK");
				Xamarin.Insights.Report (ex);
			}
			finally {
				IsBusy = false;
				saveFeedbackCommand.ChangeCanExecute ();
			}

			await page.Navigation.PopAsync ();

		}

		bool requiresCall = false;
		public bool RequiresCall 
		{
			get { return requiresCall; }
			set { SetProperty (ref requiresCall, value);}
		}


		string phone = string.Empty;
		public string PhoneNumber 
		{
			get { return phone; }
			set { SetProperty (ref phone, value);}
		}

		string name = string.Empty;
		public string Name 
		{
			get { return name; }
			set { SetProperty (ref name, value);}
		}

		string message = "Loading...";
		public string Message 
		{
			get { return message; }
			set { SetProperty (ref message, value);}
		}

		string text = string.Empty;
		public string Text 
		{
			get { return text; }
			set { SetProperty (ref text, value);}
		}

		int serviceType = 4;
		int ServiceType
		{
			get { return serviceType; }
			set {
				SetProperty (ref serviceType, value);
			}
		}

		int rating = 10;
		int Rating
		{
			get { return rating; }
			set {
				SetProperty (ref rating, value);
			}
		}

		DateTime date = DateTime.Today;
		DateTime Date
		{
			get { return date; }
			set {
				SetProperty (ref date, value);
			}
		}

		public string StoreName {get;set;}

	}
}

