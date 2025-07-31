# TaskFlow.Api

## Proje Amacı
TaskFlow.Api, kullanıcıların görev (task) oluşturup, düzenleyip, tamamlamasını sağlayan basit ama ölçeklenebilir bir Task Management Web API uygulamasıdır. Modern yazılım geliştirme yaklaşımlarını uygulamak, temiz kod ve test odaklı geliştirmeyi teşvik etmek amacıyla oluşturulmuştur.

##  Kullanılan Teknolojiler
| Teknoloji                | Açıklama                                              |
|-------------------------|------------------------------------------------------|
| ASP.NET Core 8          | Web API geliştirmek için modern, hızlı framework      |
| xUnit                   | Birim testleri için popüler test framework           |
| Entity Framework Core   | Veri erişimi ve ORM aracı                            |
| SQLite                  | Hafif, taşınabilir veritabanı                        |
| Docker                  | Konteynerizasyon                                     |
| Git + GitHub            | Versiyon kontrolü ve kod paylaşımı                   |
| Swagger / Swashbuckle   | API dökümantasyonu ve test arabirimi                 |

## Proje Yapısı
```
TaskFlow.Api/
├── Controllers/
├── Models/
├── DTOs/
├── Services/
├── Repositories/
├── Data/
├── Program.cs
├── Dockerfile
├── .dockerignore
├── .gitignore
├── TaskFlow.Api.csproj

TaskFlow.Tests/
├── TaskServiceTests.cs
├── TaskFlow.Tests.csproj
```

## API Özellikleri
### Görev (Task) Modeli
- Id: int
- Title: string
- Description: string?
- IsCompleted: bool
- CreatedAt: DateTime
- DueDate: DateTime?

### Endpointler (RESTful)
| Yöntem | URL                | Açıklama                |
|--------|--------------------|-------------------------|
| GET    | /api/tasks         | Tüm görevleri getir     |
| GET    | /api/tasks/{id}    | Görev detayını getir    |
| POST   | /api/tasks         | Yeni görev oluştur      |
| PUT    | /api/tasks/{id}    | Görev güncelle          |
| DELETE | /api/tasks/{id}    | Görevi sil              |
## Test Stratejisi
- Test Framework: xUnit
- Test Edilecekler:
  - TaskService iş kuralları
  - CRUD işlemlerinin başarı ve hata senaryoları
  - Model validasyonları

##  Docker Kullanımı
```bash
docker build -t taskflow-api .
docker run -p 5000:80 taskflow-api
```

##  Swagger UI
Uygulama çalıştığında Swagger arayüzü ile test edilebilir:
http://localhost:5000/swagger

## Geliştirme Aşamaları
- Proje yapısı oluşturuldu
- Temel modeller ve veritabanı yapısı hazırlandı
- CRUD controller’lar geliştirildi
- Unit test projesi eklendi ve testler yazıldı
- Docker desteği eklendi
- Swagger dökümantasyonu hazırlandı

##  Gelecek Geliştirmeler (Opsiyonel)
- Kullanıcı doğrulama (JWT ile Authentication)
- Görev etiketleme (Tagging)
- Görev öncelik seviyesi (Priority)
- E-posta ile bildirim 
