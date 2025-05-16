using Entity_Quiz.Data;
using Entity_Quiz.Entities;
using Entity_Quiz.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Repository.Interfaces
{
	public interface ITimeCapsuleRepo : IGenericRepo<TimeCapsule>
	{
		//zaman kapsüllerindeki belli bir tarih aralığını filtreler
		IQueryable<TimeCapsule> GetTimeCapsulesByDateRange(DateTime startDate, DateTime endDate);
		//içeriklerle birlikte tüm zaman kapsüllerini getirir
		IQueryable<TimeCapsule> GetTimeCapsulesWithContents();
	}
}
