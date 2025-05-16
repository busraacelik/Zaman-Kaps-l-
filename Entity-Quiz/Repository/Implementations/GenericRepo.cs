using Entity_Quiz.Data;
using Entity_Quiz.Models;
using Entity_Quiz.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Repository.Implementations
{
	/// <summary>
	/// GenericRepo sınıfı, Entity Framework Core kullanarak temel CRUD (Create, Read, Update, Delete) işlemleri için genel bir repository sağlar.
	/// Bu sınıf, BaseEntity'den türetilen türlerle çalışacak şekilde tasarlanmıştır ve her tür için veritabanı işlemlerini yönetir.
	/// </summary>
	public class GenericRepo<T> :IGenericRepo<T> where T :BaseEntity
	{
		protected readonly AppDbContext _context;

		public GenericRepo(AppDbContext context)
		{
			_context = context;
		}

		public IQueryable<T> GetAll()=>_context.Set<T>();
		
		public T? GetById(int id) => _context.Set<T>().Find(id);

		public IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition, bool track = true)
		{
			var query = _context.Set<T>().Where(condition);
			if (!track)
			{
				query = query.AsNoTracking(); // Eğer track false ise, veriler izlenmez
			}
			return query;
		}

		public void Add(T entity)=> _context.Set<T>().Add(entity);

		public void Update(T entity) => _context.Set<T>().Update(entity);

		public void Delete(int id)
		{
			var entity = GetById(id);
			if (entity != null)
			{
				_context.Set<T>().Remove(entity);
			}
		}

		public int SaveChanges() => _context.SaveChanges();

	}
}
