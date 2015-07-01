using System;
using MyShop;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;

namespace MyShopAdmin
{
	public class FeedbackListViewModel : BaseViewModel
	{

		readonly IDataStore dataStore;
		public ObservableCollection<Feedback> Feedbacks { get; set;}
		public ObservableCollection<Grouping<string, Feedback>> FeedbacksGrouped { get; set; }
		public FeedbackListViewModel (Page page) : base(page)
		{
			Title = "Feedback";
			dataStore = DependencyService.Get<IDataStore> ();
			Feedbacks = new ObservableCollection<Feedback> ();
			FeedbacksGrouped = new ObservableCollection<Grouping<string, Feedback>> ();
		}

		private ICommand getFeedbackCommand;
		public ICommand GetFeedbackCommand
		{
			get {
				return getFeedbackCommand ??
				(getFeedbackCommand = new Command (async () => await ExecuteGetFeedbackCommand ()));
			}
		}

		public async Task ExecuteGetFeedbackCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try{
				Feedbacks.Clear();

				var feedbacks = await dataStore.GetFeedbackAsync ();
				foreach(var feedback in feedbacks)
				{
					
					Feedbacks.Add(feedback);
				}

				Sort();

			}catch(Exception ex) {

				Xamarin.Insights.Report (ex);
				page.DisplayAlert ("Uh oh :(", "Unable to get feedback, pull to refresh when online", "OK");
			}
			finally {
				IsBusy = false;
			}

		}

		private void Sort()
		{

			FeedbacksGrouped.Clear();
			var sorted = from feedback in Feedbacks
				orderby feedback.FeedbackDate
				group feedback by feedback.StoreName into feedbackGroup
				select new Grouping<string, Feedback>(feedbackGroup.Key, feedbackGroup);

			foreach(var sort in sorted)
				FeedbacksGrouped.Add(sort);
		}

		public async Task DeleteFeedback(Feedback feedback)
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try {
				await dataStore.RemoveFeedbackAsync(feedback);
				Feedbacks.Remove(feedback);
				Sort();
			} catch(Exception ex) {
				page.DisplayAlert ("Uh Oh :(", "Unable to delete feedback.", "OK");
				Xamarin.Insights.Report (ex);
			}
			finally {
				IsBusy = false;

			}
		}
	}
}

