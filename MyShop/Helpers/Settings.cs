// Helpers/Settings.cs
using System;
using Xamarin.Essentials;

namespace MyShop
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        #region Setting Constants

        private const string NeedSyncFeedbackKey = "need_sync_feedback";
        private static readonly bool NeedSyncFeedbackDefault = false;

        private const string LastSyncKey = "last_sync";
        private static readonly DateTime LastSyncDefault = DateTime.Now.AddDays(-30);



        #endregion

#if DEBUG
        //always refresh in debug
        public static bool NeedsSync
        {
            get { return true; }
        }
#else
		public static bool NeedsSync
		{
			get { return LastSync < DateTime.Now.AddDays (-3); }
		}
#endif
        
        public static DateTime LastSync
        {
            get => new DateTime(Preferences.Get(LastSyncKey, LastSyncDefault.ToUniversalTime().Ticks), DateTimeKind.Utc);
            set => Preferences.Set(LastSyncKey, value.ToUniversalTime().Ticks);
        }

        public static bool NeedSyncFeedback
        {
            get => Preferences.Get(NeedSyncFeedbackKey, NeedSyncFeedbackDefault);
            set => Preferences.Set(NeedSyncFeedbackKey, value);
        }

    }
}