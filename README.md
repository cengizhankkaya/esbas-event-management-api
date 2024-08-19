# ESBAŞ Stajı Backend Projesi

Bu proje, ESBAŞ'taki bir staj kapsamında geliştirilmiştir. Proje, bir proximity (yakınlık) kart okuyucusunu MSSQL veritabanı ile entegre eden ve ASP.NET Core Web API ile Entity Framework Core kullanarak geliştirilmiş bir backend API'dir. Bu API, hem Flutter hem de React uygulamaları için etkinlik yönetimi işlevsellikleri sunmayı amaçlamaktadır.

## Proje Genel Bakış

ESBAŞ Etkinlik Yönetim Sistemi API'si, etkinlikler, kullanıcılar ve ilgili bilgileri etkin bir şekilde yönetmek için geliştirildi. Bu API, mobil (Flutter) ve web (React) uygulamalarını desteklemek üzere tasarlanmıştır. Kullanıcılar, etkinlikler ve departmanlar gibi çeşitli varlıklar için CRUD işlemlerini yönetir ve güvenli bir erişim sağlamak için güvenlik önlemleri uygular.


## Özellikler

- **Proximity Kart Entegrasyonu: API, proximity kart okuyucusu ile entegre edilmiştir. Bu özellik, katılımcı girişlerini otomatik olarak yakalar ve doğrular. Bu, etkinlik alanlarına hızlı ve güvenli bir şekilde erişim sağlar.
- **Veritabanı Etkileşimi: Backend, Entity Framework Core kullanarak MSSQL veritabanı ile etkileşime girer. Bu, sistemin büyük veri kümelerini verimli bir şekilde işlemesini ve Flutter ve React uygulamaları arasında kesintisiz bilgi erişimi sağlamasını mümkün kılar.
- **API Uç Noktaları:
- User_DepartmentDTO: Kullanıcı departmanlarını yönetmek için tam CRUD işlemleri.
- User_GenderDTO: Kullanıcı cinsiyet bilgilerini yönetmek için tam CRUD işlemleri.
- User_IsOfficeEmployeeDTO: Bir kullanıcının ofis çalışanı olup olmadığını izlemek için CRUD yetenekleri.
- UsersDTO: Kullanıcı yönetimi için tam CRUD işlemleri.
- Event_LocationDTO: Etkinlik yerlerini yönetmek.
- Event_TypeDTO: Etkinlik türlerini tanımlamak ve yönetmek.
- Events_UsersDTO: Kullanıcıları etkinliklere bağlamak ve katılımlarını yönetmek.
- EventsDTO: Etkinlik yönetimi, oluşturma, güncelleme ve silme işlemlerini içerir.
- **Güvenlik: API, yalnızca yetkili kullanıcıların veriye erişmesini veya veriyi değiştirmesini sağlamak için kimlik doğrulama ve yetkilendirme gibi güvenlik önlemlerini uygular. Bu, kullanıcı ve etkinlik bilgilerinin bütünlüğünü ve gizliliğini korumak için önemlidir.

## Kullanılan Teknolojiler

- ASP.NET Core Web API: RESTful API'yi oluşturmak için kullanılan ana framework.
- Entity Framework Core: Veritabanı etkileşimleri için kullanılan ORM.
- MSSQL Server: Tüm verilerin saklandığı ilişkisel veritabanı yönetim sistemi.
- Swagger: API dokümantasyonu ve testleri için kullanılan araç.

## Başlangıç

Projeyi yerel ortamınızda kurmak ve çalıştırmak için aşağıdaki talimatları izleyin. Projedeki sql tablolarına ve yapısına ESBAS_UPDATED.sql dosyasından ulaşılabilir.

### Gereksinimler

- .NET SDK  - ASP.NET Core projesini derlemek ve çalıştırmak için gerekli.
- MSSQL Server - Veritabanını yönetmek için gerekli.
- Postman  - API uç noktalarını test etmek için kullanılabilir.

### API Kullanımı

API, hem Flutter hem de React uygulamaları tarafından tüketilmek üzere tasarlanmıştır. Uç noktaları test etmek ve verilerin nasıl yapılandırıldığını anlamak için Postman veya Swagger UI'ı kullanabilirsiniz.

### Lisans

Bu proje MIT Lisansı altında lisanslanmıştır - detaylar için LICENSE dosyasına bakın.

![Ekran görüntüsü 2024-08-19 125626](https://github.com/user-attachments/assets/7fc81cf3-09f4-4c86-8e1e-d23e4433c860)


![22](https://github.com/user-attachments/assets/c50a544e-b302-4d6c-ae2d-29ac5cbd94be)




