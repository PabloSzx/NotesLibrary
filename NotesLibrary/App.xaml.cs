using Xamarin.Forms;

namespace NotesLibrary
{
	public partial class App : Application
	{
		public App()
		{
			MainPage = new NavigationPage(new HomePage());
		}
	}
}
