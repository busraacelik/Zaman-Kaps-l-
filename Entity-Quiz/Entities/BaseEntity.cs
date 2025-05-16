using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Models
{
	/// <summary>
	/// Tüm varlık sınıflarının kalıtım alacağı soyut temel sınıf.
	/// Ortak özellikler burada tanımlanır: Id, başlangıç ve bitiş tarihleri.
	/// </summary>
	public abstract class BaseEntity
	{
        public int Id { get; set; }
        public DateTime StartedDate { get; set; } = DateTime.Now; //kapsülün başlangıç tarihi
        public DateTime EndedDate { get; set; }//kapsülün bitiş tarihi
		
		/// <summary>
		/// Başlangıç ve bitiş tarihlerini ayarlamak için kullanılan yardımcı metod.
		/// Bitiş tarihi başlangıç tarihinden önce olamaz.
		/// </summary>
		/// <param name="start">Başlangıç tarihi</param>
		/// <param name="end">Bitiş tarihi</param>
		public void SetDates(DateTime start, DateTime end)
		{
			if (end <= start)
				throw new ArgumentException("EndDate must be after StartDate.");

			StartedDate = start;
			EndedDate = end;
		}
	}
}
