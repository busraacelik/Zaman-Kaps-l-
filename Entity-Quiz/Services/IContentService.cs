using Entity_Quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Services
{
	public interface IContentService
	{
		// İçerik metnine göre arama yapar
	IQueryable<CapsuleContent> SearchContentByKeyword(string keyword);
	}
}
