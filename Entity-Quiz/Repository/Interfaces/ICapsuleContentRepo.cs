using Entity_Quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Repository.Interfaces
{
	// ICapsuleContentRepo, CapsuleContent türü için generic repo işlemleri sağlar
	public interface ICapsuleContentRepo:IGenericRepo<CapsuleContent>
	{
		// Görünür içerikleri sorgulamak için bir metod
		public IQueryable<CapsuleContent> GetVisibleContents();
		// Kilitli içerikleri sorgulamak için bir metod
		public IQueryable<CapsuleContent> GetLockedContents();
	}
}
