using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NotesLibrary
{
	public partial class EditPage : ContentPage
	{
		private Song song;
		public EditPage(Song song)
		{
			InitializeComponent();
			this.song = song;

			ActualizarButton.Clicked += ActualizarButton_Clicked;

			BorrarButton.Clicked += BorrarButton_Clicked;

			TextEntry.Focused += TextEntry_Focused;

			NombreEntry.Text = song.Name;
			TextEntry.Text = song.Text;
		}

		public async void ActualizarButton_Clicked(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(NombreEntry.Text))
			{
				await DisplayAlert("Error", "Debe ingresar nombres", "Aceptar");
				NombreEntry.Focus();
				return;
			}

			Song _song = new Song
			{
				Id = song.Id,
				Name = NombreEntry.Text,
				Text = TextEntry.Text
			};

			using (var datos = new DataAccess())
			{
				datos.UpdateSong(_song);
			}
			NombreEntry.Text = string.Empty;
			TextEntry.Text = string.Empty;
			await DisplayAlert("Mensaje", "Cancion actualizada correctamente", "Aceptar");
			await Navigation.PushAsync(new HomePage());
		}

		public async void BorrarButton_Clicked(object sender, EventArgs e)
		{
			var rta = await DisplayAlert("Confirmacion", "Desea Borrar el empleado?", "Si", "No");
			if (!rta) return;

			using (var datos = new DataAccess())
			{ 
				datos.DeleteSong(song);
			};

			await DisplayAlert("Confirmacion", "Cancion borrada correctamente", "Aceptar");
			await Navigation.PushAsync(new HomePage());
		}

		void TextEntry_Focused(object sender, FocusEventArgs e)
		{
			TextEntry.Unfocus();

		}
	}
}
