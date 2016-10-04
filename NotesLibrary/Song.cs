using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace NotesLibrary
{
	public class Song
	{
		[PrimaryKey, AutoIncrement]
		public int Id
		{
			get;
			set;
		}
		public string Name
		{
			get;
			set;
		}
		public string Text
		{
			get;
			set;
		}

		public override string ToString()
		{
			return string.Format("{0} {1}]", Name, Text);
		}
		public Song()
		{
		}
	}
}
