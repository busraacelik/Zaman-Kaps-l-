using Entity_Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Entities
{
	public class TimeCapsule : BaseEntity
	{
		//Encapsulation için özel alanlar
		private string _title;
		private string _description;

		/// <summary>
		/// Zaman kapsülünün başlığını temsil eden özellik.
		/// Başlık boş olamaz, setter içinde validasyon yapılır.
		/// </summary>
		public string Title
		{
			get { return _title; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("Başlık boş geçilemez");
				_title = value;

			}

		}
		/// <summary>
		/// Zaman kapsülünün açıklamasını temsil eden özellik.
		/// Eğer değer null ise boş bir string olarak atanır.
		/// </summary>
		public string? Description
		{
			get { return _description; }

			set
			{
				_description = value;
			}
		}
		// CapsuleContent koleksiyonu, TimeCapsule ile ilişkili içeriklerin listesini tutar.
		
		public virtual ICollection<CapsuleContent> Contents { get; set; } = new List<CapsuleContent>();

		public override string ToString()
		{
			return $"Capsule: {Title} ({StartedDate.ToShortDateString()} - {EndedDate.ToShortDateString()})";
		}

	}
}
