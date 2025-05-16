using Entity_Quiz.Entities;
using Entity_Quiz.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Services
{
	public class CapsuleService:ICapsuleService
	{
		private readonly IUnitOfWork _unitOfWork;

		// Constructor üzerinden UnitOfWork'i alıyoruz
		public CapsuleService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// Kapsüllerle birlikte içeriği de getiren metod
		public IQueryable<TimeCapsule> GetTimeCapsulesWithContents()
		{
			return _unitOfWork.TimeCapsuleRepo.GetTimeCapsulesWithContents();
		}

		// Kapsülün açılabilen içeriklerini getirir (geçmişteki içerikler)
		public IQueryable<CapsuleContent> GetVisibleContents(int capsuleId)
		{
			return _unitOfWork.CapsuleContentRepo.GetVisibleContents()
												   .Where(c => c.TimeCapsuleId == capsuleId);
		}

		// Kapsülün kilitli içeriklerini getirir (açılma tarihi gelmemiş içerikler)
		public IQueryable<CapsuleContent> GetLockedContents(int capsuleId)
		{
			return _unitOfWork.CapsuleContentRepo.GetLockedContents()
												   .Where(c => c.TimeCapsuleId == capsuleId);
		}

		// Belirli bir tarih aralığına göre kapsülleri getirir
		public IQueryable<TimeCapsule> GetCapsulesByDate(DateTime startDate, DateTime endDate)
		{
			return _unitOfWork.TimeCapsuleRepo.GetTimeCapsulesByDateRange(startDate, endDate);
		}

		// Kullanıcının en son oluşturduğu kapsülü getirir (en son eklenen kapsül)
		public TimeCapsule GetLatestCapsule()
		{
			return _unitOfWork.TimeCapsuleRepo.GetAll().OrderByDescending(t => t.StartedDate)
			.FirstOrDefault();
		}

		public string GetCapsuleOpeningMessage(TimeCapsule capsule)
		{
			// Eğer kapsülün açılma tarihi bugüne eşitse, mesaj döndürüyoruz.
			if (capsule.StartedDate.Date == DateTime.Today)
			{
				return "Bugün açılabilir!";
			}

			// Aksi takdirde, herhangi bir mesaj döndürmüyoruz veya farklı bir mesaj verebiliriz.
			return "Kapsül henüz açılabilir değil.";
		}
	}
}
