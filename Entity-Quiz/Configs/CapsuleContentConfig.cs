using Entity_Quiz.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Quiz.Configs
{
	/// <summary>
	/// CapsuleContent varlığı için Fluent API konfigürasyonu.
	/// </summary>
	public class CapsuleContentConfig : IEntityTypeConfiguration<CapsuleContent>
	{
		/// <summary>
		/// CapsuleContent varlığının konfigürasyonunu yapar.
		/// </summary>
		/// <param name="builder">EntityTypeBuilder nesnesi, varlık yapılandırması için kullanılır.</param>
		public void Configure(EntityTypeBuilder<CapsuleContent> builder)
		{ 
			// Id alanını birincil anahtar (Primary Key) olarak tanımla
			builder.HasKey(c => c.Id);
			// ContentType alanının zorunlu olduğunu ve maksimum uzunluğunun 100 karakter olduğunu belirtir
			builder.Property(c => c.ContentType)
				   .IsRequired()
				   .HasMaxLength(100);
			// Content alanının zorunlu olduğunu ve maksimum uzunluğunun 1000 karakter olduğunu belirtir
			builder.Property(c => c.Content)
				   .IsRequired()
				   .HasMaxLength(1000);
			// ContentCategory alanının zorunlu olduğunu belirtir
			builder.Property(c => c.ContentCategory)
				   .IsRequired();
			// StartDate alanının zorunlu olduğunu belirtir
			builder.Property(c => c.StartDate)
				   .IsRequired();

			// EndDate alanının zorunlu olduğunu belirtir
			builder.Property(c => c.EndDate)
				   .IsRequired();
		}
	}
}
