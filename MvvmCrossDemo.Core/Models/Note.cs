using System;

namespace MvvmCrossDemo.Core.Models
{
	public class Note
	{
		public string Title { get; set; }
		public string Detail { get; set; }
		public string Summary { 
			get 
			{ 
				return Detail.Substring(0, Detail.Length > 50 ? 49 : Detail.Length - 1) + "..."; 
			} 
		}
	}
}
