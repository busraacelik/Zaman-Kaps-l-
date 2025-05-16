using Entity_Quiz.Entities.Enums;
using Entity_Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Entities
{
	public class CapsuleContent : BaseEntity
	{
		//Encapsulation için özel alanlar
		private string _contentType;
		private string _content;

		/// <summary>
		/// İçerik tipi (ContentType) özelliği. 
		/// Boş olamaz, setter içinde validasyon yapılır.
		/// </summary>
		public string ContentType
		{
			get {  return _contentType; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentException("ContentType cannot be empty.");
				_contentType = value;
			}
		}
		/// <summary>
		/// İçerik tipi (ContentType) özelliği. 
		/// Boş olamaz, setter içinde validasyon yapılır.
		/// </summary>
		public string Content
		{
			get { return _content; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentException("Content cannot be empty.");
				_content = value;
			}
		}
		//içeriğin başlama tarihi
		public DateTime StartDate { get; set; }
		//içeriğin bitiş tarihi
		public DateTime EndDate { get; set; }

		
		//İçerik türünün barındırdığı enum
		public ContentCategory ContentCategory { get; set; }

		// TimeCapsule ile ilişkilendirilmiş dış anahtar (foreign key)
		/// <summary>
		/// İlgili TimeCapsule'ın ID'si.
		/// </summary>
		public int TimeCapsuleId { get; set; }

		// Navigation property:TimeCapsule ile ilişki
		public virtual TimeCapsule TimeCapsule { get; set; }

		/// <summary>
		/// İçeriğin açılma tarihi geçmişse, içerik görünür.
		/// </summary>
		/// <returns>İçerik açılma tarihi geçmişse true, geçmiş değilse false döner.</returns>
		public bool IsVisible()
		{
			return StartDate <= DateTime.Now; // Eğer açılma tarihi geçmişse içerik görünür
		}
		/// <summary>
		/// CapsuleContent nesnesinin kısa bir tanımını döndüren ToString() metodu.
		/// </summary>
		public override string ToString()
		{
			return $"{ContentType}: {Content}";
		}
	}

}
