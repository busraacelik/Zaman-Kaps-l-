using Entity_Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Repository.Interfaces
{
	public interface IGenericRepo<T>where T : BaseEntity
	{
		// Tüm veriyi getirir
		IQueryable<T> GetAll();
		// ID'ye göre tek bir varlık getirir (nullable dönüş tipi)
		T? GetById(int id);
		// Koşula göre veri çeker
		IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition, bool track = true);
		// Yeni varlık ekler
		void Add(T entity);
		// Varlığı günceller
		void Update(T entity);
		// ID'ye göre varlık siler
		void Delete(int id);
		// Değişiklikleri kaydeder
		int SaveChanges(); 
	}
}
