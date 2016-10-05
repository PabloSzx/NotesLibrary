using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NotesLibrary
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();

			nuevoButton.Clicked += nuevoButton_Clicked;

			datosListView.ItemSelected += DatosListView_ItemSelected;
			datosListView.ItemTemplate = new DataTemplate(typeof(SongCell));
			using (var datos = new DataAccess())
			{
				datosListView.ItemsSource = datos.GetSongs();
			}
		}

		public async void nuevoButton_Clicked(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(nombresEntry.Text)) 
			{ 
				await DisplayAlert("Error","Debe ingresar nombres","Aceptar");
				nombresEntry.Focus();
				return;
			}

			Song song = new Song
			{
				Name = nombresEntry.Text,
				Text = textEntry.Text
			};

			using (var datos = new DataAccess())
			{
				datos.InsertSong(song);
				datosListView.ItemsSource = datos.GetSongs();
			}
			nombresEntry.Text = string.Empty;
			textEntry.Text = string.Empty;
			await DisplayAlert("Mensaje", "Cancion ingresada correctamente", "Aceptar");

		}

		void DatosListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			Navigation.PushAsync(new EditPage((Song)e.SelectedItem));
		}
	}
}
