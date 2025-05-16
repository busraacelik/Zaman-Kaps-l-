using Entity_Quiz.Data;
using Entity_Quiz.Entities;
using Entity_Quiz.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Repository.Implementations
{
	public class CapsuleContentRepo : GenericRepo<CapsuleContent>, ICapsuleContentRepo
	{
		public CapsuleContentRepo(AppDbContext context) : base(context) { }

		// Şifreli olmayan içerikleri al (Geçmiş tarihli içerikler)
		public IQueryable<CapsuleContent> GetVisibleContents()
		{
			return GetAll().Where(c => c.IsVisible()); // Açılma tarihi geçmiş içerikler
		}

		// Şifreli içerikleri al (Gelecek tarihli içerikler)
		public IQueryable<CapsuleContent> GetLockedContents()
		{
			return GetAll().Where(c => !c.IsVisible()); // Açılma tarihi henüz gelmemiş içerikler
		}
	}
}
