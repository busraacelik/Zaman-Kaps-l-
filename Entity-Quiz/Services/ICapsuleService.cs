using Entity_Quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Services
{
	public interface ICapsuleService
	{
		// Kapsüller ve içeriği ile ilgili verileri getirir.
		IQueryable<TimeCapsule> GetTimeCapsulesWithContents();

		// Görünür içerikleri getirir (açılma tarihi geçmiş içerikler).
		IQueryable<CapsuleContent> GetVisibleContents(int capsuleId);

		// Şifreli (kilitli) içerikleri getirir (açılma tarihi gelmemiş içerikler).
		IQueryable<CapsuleContent> GetLockedContents(int capsuleId);

		// Belirli bir tarih aralığına göre kapsülleri getirir.
		IQueryable<TimeCapsule> GetCapsulesByDate(DateTime startDate, DateTime endDate);

		// Kullanıcının en son oluşturduğu kapsülü getirir.
		TimeCapsule GetLatestCapsule();
	}
}
