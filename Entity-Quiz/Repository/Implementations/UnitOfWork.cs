using Entity_Quiz.Data;
using Entity_Quiz.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Repository.Implementations
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _context;

		public UnitOfWork(AppDbContext context)
		{
			_context = context;
			TimeCapsuleRepo = new TimeCapsuleRepo(_context);
			CapsuleContentRepo = new CapsuleContentRepo(_context); 
		}
		// ITimeCapsuleRepo türündeki repository'ye erişim sağlar
		public ITimeCapsuleRepo TimeCapsuleRepo {  get; private set; }
		// ICapsuleContentRepo türündeki repository'ye erişim sağlar
		public ICapsuleContentRepo CapsuleContentRepo {  get; private set; }
		// Yapılan değişiklikleri veritabanına kaydeder
		public int SaveChanges()
		{
			return _context.SaveChanges();
		}
	}
}
