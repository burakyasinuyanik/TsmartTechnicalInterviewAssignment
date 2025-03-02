Ürün Yönetimi API
Bu proje, ASP.NET Core 9 kullanarak geliştirilmiş bir Ürün Yönetimi API'sini içermektedir. API, temel ürün işlemleri (ekleme, güncelleme, silme, listeleme) ile kullanıcı doğrulama (JWT tabanlı) işlemleri sağlar. Ayrıca, projede FluentValidation, Mapper, Minimal API, Swagger, ve Entity Framework Core kullanılmıştır.

Özellikler
FluentValidation: API'ye gelen verilerin doğruluğunu kontrol etmek için kullanılmıştır.
Mapper: Model ile DTO (Data Transfer Object) dönüşümleri için kullanılmıştır.
Minimal API: API endpoint'leri minimal yapı ile oluşturulmuştur.
Swagger: API dokümantasyonu için Swagger entegrasyonu yapılmıştır.
JWT Authentication: Kullanıcı doğrulaması JWT tabanlıdır.
Veritabanı: SQL Server kullanılarak veritabanı işlemleri yapılmaktadır.
Proje Gereksinimleri
.NET Core 9 veya daha yeni bir sürümü
SQL Server veya başka bir ilişkisel veritabanı (Bağlantı dizesi ayarlanabilir)
FluentValidation ve AutoMapper NuGet paketleri
Başlangıç
Projeyi Çalıştırma
Projeyi Klonlayın:

Git kullanarak projeyi klonlayın.



.NET Core projesindeki bağımlılıkları yüklemek için terminal veya komut satırında aşağıdaki komutu çalıştırın:

bash
Kopyala
dotnet restore
Veritabanı Bağlantı Ayarları:

Projeyi çalıştırmadan önce appsettings.json dosyasındaki SQL Server bağlantı dizesini kendi veritabanı bağlantınızla değiştirmeniz gerekmektedir.

![image](https://github.com/user-attachments/assets/d0961813-3d45-4381-b717-799691062406)

Veritabanı Migrasyonu:

Veritabanı şemasını oluşturmak için ConnectionStrings ayarını yaptıktan sonra programı çalıştırmanız yeterlidir. Program kendisi migration işlemi sağlayacaktır


Projeyi başlatmak için terminalde aşağıdaki komutu kullanın:

dotnet run
Uygulama başarıyla çalıştıktan sonra, API endpoint'lerine erişmek için tarayıcınızda "applicationUrl": "https://localhost:7272/swagger/index.html;http://localhost:5143/swagger/index.html"

API Dokümantasyonu
API'nizi test etmek ve kullanmak için Swagger arayüzüne aşağıdaki URL üzerinden erişebilirsiniz:
https://localhost:7272/swagger/index.html
https://documenter.getpostman.com/view/30810332/2sAYdimoVw

Kullanıcı Girişi ve JWT
API'ye erişim sağlamak için kullanıcı adı ve şifre ile giriş yapılması gerekmektedir. Başarılı bir girişte, JWT token'ı döndürülür ve bu token, diğer API çağrılarında kimlik doğrulama için kullanılır.
Kullanıcılar
{
  "email": "admin@admin.com",
  "password": "Password12**"
}
{
  "email": "musteri@musteri.com",
  "password": "Password12**"
}
{
  "email": "yetkisiz@yetkisiz.com",
  "password": "Password12**"
}
API Endpoint'leri
GET /api/products
Tüm ürünleri listeler.
![image](https://github.com/user-attachments/assets/818d3d15-8acc-4300-8184-54f189d66f66)

GET /api/products/{id}
Belirli bir ID'ye sahip ürünü getirir.

POST /api/products
Yeni bir ürün ekler. JSON formatında ürün bilgisi gönderilir.

PUT /api/products/{id}
Belirli bir ID'ye sahip ürünü günceller. Güncellenmek istenen bilgiler JSON formatında gönderilir.

DELETE /api/products/{id}
Belirli bir ID'ye sahip ürünü siler (soft delete işlemi yapar).

POST /api/auth/login
Kullanıcı girişi yapar ve JWT token döndürür.

Swagger üzerinden test etmek için başarılı bir şekilde token aldıntan sonra sağ üstte bulunan Authorize kısmına tıklayarak aşağıdaki şekilde başarılı almış olduğunuz tokeni Bearer bir boşuk bırakıp
ilgili Endpointleri test edebilirsiniz.
![image](https://github.com/user-attachments/assets/56e9190e-5482-4a5c-ac37-be8f2de33a79)
