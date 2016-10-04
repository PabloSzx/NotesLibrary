using System;
using SQLite.Net.Interop;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(NotesLibrary.iOS.Config))]

namespace NotesLibrary.iOS
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
			get {
				if (string.IsNullOrEmpty(_DirectorioDB)) 
				{
					var directorio = System.Environment.GetFolderPath(
						Environment.SpecialFolder.Personal);
					_DirectorioDB = System.IO.Path.Combine(directorio, "..", "Library");
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
					_Plataforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();

				}
				return _Plataforma;
			}
		}
	}
}
