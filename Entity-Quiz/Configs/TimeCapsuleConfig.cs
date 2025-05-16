using Entity_Quiz.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Configs
{
	/// <summary>
	/// TimeCapsule varlığı için veritabanı yapılandırması.
	/// EF Core Fluent API ile tabloya özel kurallar tanımlanır.
	/// </summary>
	public class TimeCapsuleConfig : IEntityTypeConfiguration<TimeCapsule>
	{
		/// <summary>
		/// TimeCapsule varlığının veritabanı yapılandırmasını gerçekleştirir.
		/// </summary>
		/// <param name="builder">EntityTypeBuilder nesnesi, TimeCapsule varlığını yapılandırmak için kullanılır.</param>
		public void Configure(EntityTypeBuilder<TimeCapsule> builder)
		{
			// Id özelliğini birincil anahtar (primary key) olarak belirler
			builder.HasKey(t => t.Id);

			// Title özelliğinin zorunlu olduğunu ve maksimum uzunluğunun 100 karakter olduğunu belirtir
			builder.Property(t => t.Title)
				   .IsRequired()
				   .HasMaxLength(100);

			// Description özelliği için maksimum uzunluğun 500 karakter olduğunu belirtir
			// Bu alan isteğe bağlıdır (null olabilir)
			builder.Property(t => t.Description)
				   .HasMaxLength(500);
			// StartedDate özelliğinin zorunlu olduğunu belirtir
			builder.Property(t => t.StartedDate)
				   .IsRequired();

			// EndedDate özelliğinin zorunlu olduğunu belirtir
			builder.Property(t => t.EndedDate)
				   .IsRequired();

			// TimeCapsule ile CapsuleContent arasında bire çok ilişki tanımlanır
			// Bir kapsül birden fazla içerik barındırabilir (One-to-Many)
			// Kapsül silinirse, bağlı tüm içerikler de silinir (Cascade Delete)
			builder.HasMany(t => t.Contents)
				   .WithOne(c => c.TimeCapsule)
				   .HasForeignKey(c => c.TimeCapsuleId)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
