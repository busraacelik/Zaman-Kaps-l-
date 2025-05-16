using Entity_Quiz.Data;
using Entity_Quiz.Entities;
using Entity_Quiz.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Repository.Implementations
{
	public class TimeCapsuleRepo: GenericRepo<TimeCapsule>, ITimeCapsuleRepo
	{
		public TimeCapsuleRepo(AppDbContext context) : base(context) { }
		//zaman kapsüllerini belirli bir tarih aralığında filtreler
		public IQueryable<TimeCapsule> GetTimeCapsulesByDateRange(DateTime startDate, DateTime endDate)
		{
			return _context.TimeCapsules
						   .Where(t => t.StartedDate >= startDate && t.EndedDate <= endDate);
		}

		public IQueryable<TimeCapsule> GetTimeCapsulesWithContents()
		{
			return _context.TimeCapsules
						   .Include(t => t.Contents); // Eager loading içerikleri de dahil eder
		}

	}
}
