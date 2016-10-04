using System;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(NotesLibrary.Droid.Config))]

namespace NotesLibrary.Droid
{
	public class Config : IConfig
	{
		public Config()
		{
		}

		private string _DirectorioDB;

		private ISQLitePlatform _Plataforma;

		public string DirectorioDB
		{
			get
			{
				if (string.IsNullOrEmpty(_DirectorioDB))
				{
					_DirectorioDB = System.Environment.GetFolderPath(
						System.Environment.SpecialFolder.Personal);
				}
				return _DirectorioDB;
			}
		}

		public ISQLitePlatform Plataforma
		{
			get
			{
				if (_Plataforma == null)
				{
					_Plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
				}
				return _Plataforma;
			}
		}
	}
}
