// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ShopBoxApp.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string ClientIdKey = "ClientId_key";
		private static readonly string ClientIdDefault = string.Empty;
        private const string AccessTokenKey = "AccessToken_key";
        private static readonly string AccessTokenDefault = string.Empty;
        
        #endregion

         public static string AccessToken
        {
			get
			{
				return AppSettings.GetValueOrDefault(AccessTokenKey, AccessTokenDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(AccessTokenKey, value);
			}
		}
        public static string ClientId
		{
			get
			{
				return AppSettings.GetValueOrDefault(ClientIdKey, ClientIdDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(ClientIdKey, value);
			}
		}

	}
}