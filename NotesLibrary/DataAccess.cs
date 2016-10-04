using System;
using SQLite.Net;
using Xamarin.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace NotesLibrary
{
	public class DataAccess : IDisposable
	{
		private SQLiteConnection connection;



		public DataAccess()
		{
			var config = DependencyService.Get<IConfig>();
			connection = new SQLiteConnection(config.Plataforma, Path.Combine(config.DirectorioDB, "Songs.db3"));

			connection.CreateTable<Song>();
		}
		public void InsertSong(Song song)
		{ 
			connection.Insert(song);
		}
		public void UpdateSong(Song song)
		{
			connection.Update(song);
		}

		public void DeleteSong(Song song)
		{
			connection.Delete(song);
		}

		public Song GetSong(int Id)
		{
			return connection.Table<Song>().FirstOrDefault(c => c.Id == Id);
		}

		public List<Song> GetSongs() 
		{
			return connection.Table<Song>().OrderBy(c => c.Name).ToList();
		}
		public void Dispose()
		{
			connection.Dispose();
		}
	}
}
