using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Repository.Interfaces
{
	public interface IUnitOfWork
	{
		// ITimeCapsuleRepo türündeki repository'e erişim sağlar
		ITimeCapsuleRepo TimeCapsuleRepo { get; }
		// ICapsuleContentRepo türündeki repository'e erişim sağlar
		ICapsuleContentRepo CapsuleContentRepo { get; }
		// Yapılan değişiklikleri veritabanına kaydeder
		int SaveChanges();
	}
}
