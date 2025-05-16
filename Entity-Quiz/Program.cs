using Entity_Quiz.Entities.Enums;
using Entity_Quiz.Entities;
using Entity_Quiz.Repository.Implementations;
using Entity_Quiz.Data;

namespace Entity_Quiz
{
	/// <summary>
	/// Modüler yapı için UnitOfWork ve Repository pattern kullanılarak kod bakımı kolaylaştırıldı.
	/// Kapsül ve içerik arasında ilişki kurularak veriler tutarlı bir şekilde işlendi.
	/// Menü tabanlı etkileşim ile kullanıcıların işlemleri kolayca yapması sağlandı.
	/// Entity Framework ile veritabanı işlemleri kolaylaştırıldı ve verilerin güvenliği sağlandı.
	/// </summary>

	internal class Program
	{
		private static UnitOfWork _unitOfWork = new UnitOfWork(new AppDbContext());

		static void Main(string[] args)
		{

			SeedData();//Başlangıç verilerini ekler

			//konsol menüsünü gösterir
			while (true)
			{
				Console.Clear();
				Console.WriteLine("Konsol Menüsü:");
				Console.WriteLine("1. Yeni kapsül oluştur");
				Console.WriteLine("2. Kapsüle içerik ekle");
				Console.WriteLine("3. Tüm kapsülleri listele");
				Console.WriteLine("4. Açılma tarihi geçmiş kapsülleri görüntüle");
				Console.WriteLine("5. Kapsül Detayları (İçeriğiyle birlikte) listele");
				Console.WriteLine("6. Rapor: En fazla içeriğe sahip kapsüller");
				Console.WriteLine("7. Rapor: En çok kullanılan içerik türü");
				Console.WriteLine("0. Çıkış");
				Console.Write("Seçiminizi yapın: ");
				//kullanıcı seçimini alır
				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						CreateTimeCapsule();
						break;
					case "2":
						AddContentToCapsule();
						break;
					case "3":
						ListAllCapsules();
						break;
					case "4":
						ListPastCapsules();
						break;
					case "5":
						ListCapsuleDetails();
						break;
					case "6":
						ReportMostContentCapsules();
						break;
					case "7":
						ReportMostUsedContentType();
						break;
					case "0":
						return;
					default:
						Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
						break;
				}
				Console.WriteLine("\nDevam etmek için bir tuşa basın...");
				Console.ReadKey();
			}
		}
		//yeni kapsül oluşturur
		private static void CreateTimeCapsule()
		{
			Console.WriteLine("Yeni Kapsül Oluştur");
			Console.Write("Başlık: ");
			string title = Console.ReadLine();

			Console.Write("Açıklama: ");
			string description = Console.ReadLine();

			Console.Write("Başlangıç Tarihi (yyyy-MM-dd): ");
			DateTime startDate = DateTime.Parse(Console.ReadLine());

			Console.Write("Bitiş Tarihi (yyyy-MM-dd): ");
			DateTime endDate = DateTime.Parse(Console.ReadLine());

			var capsule = new TimeCapsule
			{
				Title = title,
				Description = description,
				StartedDate = startDate,
				EndedDate = endDate
			};
			//kapsül veritabanına eklenir.
			_unitOfWork.TimeCapsuleRepo.Add(capsule);
			_unitOfWork.SaveChanges();

			Console.WriteLine("Yeni kapsül başarıyla oluşturuldu!");
		}
		//kapsüle içerik ekler
		private static void AddContentToCapsule()
		{
			Console.WriteLine("Kapsüle İçerik Ekle");
			Console.Write("Kapsül ID: ");
			int capsuleId = int.Parse(Console.ReadLine());
			//kapsülü idsine göre alır
			var capsule = _unitOfWork.TimeCapsuleRepo.GetById(capsuleId);

			if (capsule == null)
			{
				Console.WriteLine("Kapsül bulunamadı!");
				return;
			}

			Console.Write("İçerik Türü (Message, ImageDescription, Thought, Memory): ");
			var contentCategory = (ContentCategory)Enum.Parse(typeof(ContentCategory), Console.ReadLine(), true);

			Console.Write("İçerik Türü: ");
			string contentType = Console.ReadLine();

			Console.Write("İçerik: ");
			string content = Console.ReadLine();

			var capsuleContent = new CapsuleContent
			{
				TimeCapsuleId = capsuleId,
				ContentType = contentType,
				Content = content,
				ContentCategory = contentCategory,
				StartDate = capsule.StartedDate,
				EndDate = capsule.EndedDate
			};
			// İçerik veritabanına eklenir
			_unitOfWork.CapsuleContentRepo.Add(capsuleContent);
			_unitOfWork.SaveChanges();

			Console.WriteLine("İçerik başarıyla eklendi!");
		}
		// Tüm kapsülleri listeler
		private static void ListAllCapsules()
		{
			var capsules = _unitOfWork.TimeCapsuleRepo.GetAll().ToList();

			if (!capsules.Any())
			{
				Console.WriteLine("Hiç kapsül bulunmamaktadır.");
				return;
			}

			foreach (var capsule in capsules)
			{
				Console.WriteLine(capsule);
			}
		}
		// Açılma tarihi geçmiş kapsülleri listeler
		private static void ListPastCapsules()
		{
			var pastCapsules = _unitOfWork.TimeCapsuleRepo.GetTimeCapsulesByDateRange(DateTime.MinValue, DateTime.Now).ToList();

			if (!pastCapsules.Any())
			{
				Console.WriteLine("Açılma tarihi geçmiş kapsül bulunmamaktadır.");
				return;
			}

			foreach (var capsule in pastCapsules)
			{
				Console.WriteLine(capsule);
			}
		}
		// Kapsülün detaylarını (içeriğiyle birlikte) listeler
		private static void ListCapsuleDetails()
		{
			Console.Write("Kapsül ID: ");
			int capsuleId = int.Parse(Console.ReadLine());

			var capsule = _unitOfWork.TimeCapsuleRepo.GetById(capsuleId);

			if (capsule == null)
			{
				Console.WriteLine("Kapsül bulunamadı!");
				return;
			}

			Console.WriteLine($"Kapsül Başlık: {capsule.Title}");
			foreach (var content in capsule.Contents)
			{
				Console.WriteLine($"İçerik Türü: {content.ContentType}, İçerik: {content.Content}");
			}
		}
		// En fazla içeriğe sahip kapsülleri raporlar
		private static void ReportMostContentCapsules()
		{
			var report = _unitOfWork.TimeCapsuleRepo.GetAll()
				.OrderByDescending(t => t.Contents.Count)
				.Take(5)
				.ToList();

			Console.WriteLine("En fazla içeriğe sahip kapsüller:");
			foreach (var capsule in report)
			{
				Console.WriteLine($"{capsule.Title} - İçerik Sayısı: {capsule.Contents.Count}");
			}
		}
		// En çok kullanılan içerik türlerini raporlar
		private static void ReportMostUsedContentType()
		{
			var report = _unitOfWork.CapsuleContentRepo.GetAll()
				.GroupBy(c => c.ContentCategory)
				.OrderByDescending(g => g.Count())
				.Select(g => new { Category = g.Key, Count = g.Count() })
				.ToList();

			Console.WriteLine("En çok kullanılan içerik türleri:");
			foreach (var item in report)
			{
				Console.WriteLine($"{item.Category}: {item.Count}");
			}
		}
		// Başlangıç verilerini ekler
		private static void SeedData()
		{
			// Eğer daha önce eklenmişse tekrar ekleme
			if (_unitOfWork.TimeCapsuleRepo.GetAll().Any())
				return;

			var capsule1 = new TimeCapsule
			{
				Title = "İlk Kapsül",
				Description = "Bu ilk örnek kapsüldür.",
				StartedDate = new DateTime(2023, 1, 1),
				EndedDate = new DateTime(2024, 1, 1),
			};

			var capsule2 = new TimeCapsule
			{
				Title = "İkinci Kapsül",
				Description = "Bu ikinci örnek kapsüldür.",
				StartedDate = new DateTime(2022, 6, 1),
				EndedDate = new DateTime(2023, 6, 1),
			};

			_unitOfWork.TimeCapsuleRepo.Add(capsule1);
			_unitOfWork.TimeCapsuleRepo.Add(capsule2);
			_unitOfWork.SaveChanges();

			var content1 = new CapsuleContent
			{
				TimeCapsuleId = capsule1.Id,
				ContentType = "Not",
				Content = "İlk kapsüle ait ilk içerik.",
				ContentCategory = ContentCategory.Message,
				StartDate = capsule1.StartedDate,
				EndDate = capsule1.EndedDate
			};

			var content2 = new CapsuleContent
			{
				TimeCapsuleId = capsule1.Id,
				ContentType = "Fotoğraf",
				Content = "İlk kapsüle ait ikinci içerik.",
				ContentCategory = ContentCategory.ImageDescription,
				StartDate = capsule1.StartedDate,
				EndDate = capsule1.EndedDate
			};

			var content3 = new CapsuleContent
			{
				TimeCapsuleId = capsule2.Id,
				ContentType = "Anı",
				Content = "İkinci kapsüle ait bir içerik.",
				ContentCategory = ContentCategory.Memory,
				StartDate = capsule2.StartedDate,
				EndDate = capsule2.EndedDate
			};

			var content4 = new CapsuleContent
			{
				TimeCapsuleId = capsule2.Id,
				ContentType = "Düşünce",
				Content = "İkinci kapsüle ait diğer içerik.",
				ContentCategory = ContentCategory.Thought,
				StartDate = capsule2.StartedDate,
				EndDate = capsule2.EndedDate
			};

			_unitOfWork.CapsuleContentRepo.Add(content1);
			_unitOfWork.CapsuleContentRepo.Add(content2);
			_unitOfWork.CapsuleContentRepo.Add(content3);
			_unitOfWork.CapsuleContentRepo.Add(content4);

			_unitOfWork.SaveChanges();

			Console.WriteLine("Örnek veriler başarıyla eklendi.");
		}


	}
}
