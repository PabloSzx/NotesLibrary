using System;
using Xamarin.Forms;

namespace NotesLibrary
{
	public class SongCell : ViewCell
	{
		
		public SongCell()
		{
			var NameLabel = new Label
			{
				TextColor = Color.Black,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.FillAndExpand

			};
			NameLabel.SetBinding(Label.TextProperty, new Binding("Name"));
			var TextLabel = new Label
			{
				TextColor = Color.Gray,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand

			};
			TextLabel.SetBinding(Label.TextProperty, new Binding("Text"));

			var Panel_1 = new StackLayout
			{
				Children = { NameLabel },
				Orientation = StackOrientation.Vertical


			};
			var Panel_2 = new StackLayout
			{
				Children = { TextLabel },
				Orientation = StackOrientation.Vertical

			};
			View = new StackLayout
			{
				Children = { Panel_1, Panel_2 },
				Orientation = StackOrientation.Vertical


			};



		}
	}
}
