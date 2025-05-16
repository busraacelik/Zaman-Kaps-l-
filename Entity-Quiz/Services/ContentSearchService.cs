using Entity_Quiz.Entities;
using Entity_Quiz.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Services
{
	public class ContentSearchService:IContentService
	{
		private readonly ICapsuleContentRepo _capsuleContentRepo;

		// Constructor üzerinden repository sınıfı alınıyor
		public ContentSearchService(ICapsuleContentRepo capsuleContentRepo)
		{
			_capsuleContentRepo = capsuleContentRepo;
		}

		// Arama anahtar kelimesine göre içerikleri filtreler
		public IQueryable<CapsuleContent> SearchContentByKeyword(string keyword)
		{
			// İçerik metninde anahtar kelimenin geçtiği içerikleri döndürür
			return _capsuleContentRepo.GetAll()
									  .Where(c => c.Content.Contains(keyword));
		}
	}
}
