using Entity_Quiz.Configs;
using Entity_Quiz.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Data
{
	/// <summary>
	/// Uygulamanın veritabanı bağlamını temsil eder. 
	/// Entity Framework Core kullanarak TimeCapsule ve CapsuleContent tablolarını yönetir.
	/// </summary>
	public class AppDbContext:DbContext
	{
		public DbSet<TimeCapsule> TimeCapsules{ get; set; }
		public DbSet<CapsuleContent> Capsules{ get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFCoreQuizDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
		}
		/// <summary>
		/// Veritabanı modeli oluşturulurken çağrılır ve konfigürasyonlar burada yapılır.
		/// TimeCapsule ve CapsuleContent için özel yapılandırmalar uygulanır.
		/// </summary>
		/// <param name="modelBuilder">ModelBuilder nesnesi</param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new TimeCapsuleConfig());
			modelBuilder.ApplyConfiguration(new CapsuleContentConfig());
			base.OnModelCreating(modelBuilder);
		}

	}
}
