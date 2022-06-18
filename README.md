# Site Management
React Projesi : https://github.com/KaderArslan/SiteManagement_Frontend_React

## Proje:
Bir sitede yöneticisiniz. Sitenizde yer alan dairelerin aidat ve ortak kullanım elektrik, su ve doğalgaz
faturalarının yönetimini bir sistem üzerinden yapacaksınız.

### Projede kullanılacaklar:
---
- [x] Web projesi backend için .Net Core, frontend için React.js kullanın.
- [x] Sistemin yönetimi/database için MS SQL Server kullanın.
- [x] Kredi kartı servisi için. Veriler mongodb de tutulacak. Servis .Net WebApi olarak yazılacaktır.

### Kullanılan Teknolojiler
---
<img src="https://img.shields.io/badge/-diagrams-F08705?logo=diagrams.net&logoColor=fff"> <img src="https://img.shields.io/badge/-MsSQL-CC2927?logo=microsoftsqlserver&logoColor=fff"> <img src="https://img.shields.io/badge/-MongoDB-29b930?logo=mongodb&logoColor=fff"> <img src="https://img.shields.io/badge/-.Net5-512BD4?logo=.net&logoColor=fff"> <img src="https://img.shields.io/badge/-Json%20Web%20Tokens-000000?logo=jsonwebtokens&logoColor=fff"> <img src="https://img.shields.io/badge/-Postman-FF6C37?logo=postman&logoColor=fff"> <img src="https://img.shields.io/badge/-Swagger-85EA2D?logo=swagger&logoColor=fff"> <img src="https://img.shields.io/badge/-VS-5C2D91?logo=visualstudio&logoColor=fff">

### .NetCore Projesi için Yapılanlar:
---
● Admin/Yönetici
- [x] Daire bilgilerini girebilir.
- [x] İkamet eden kullanıcı bilgilerini girer.
- [x] Daire başına ödenmesi gereken aidat ve fatura bilgilerini girer(Aylık olarak). Toplu veya tek tek atama yapılabilir.
- [x] Gelen ödeme bilgilerini görür.
- [x] Gelen mesajları görür.
- [x] Mesajların okunmuş/okunmamış/yeni mesaj olduğu anlaşılmalı.
- [ ] Aylık olarak borç-alacak listesini görür.
- [x] Kişileri listeler, düzenler, siler.
- [x] Daire/konut bilgilerini listeler, düzenler siler.

● Kullanıcı
- [x] Kendisine atanan fatura ve aidat bilgilerini görür.
- [x] Sadece kredi kartı ile ödeme yapabilir.
- [x] Yöneticiye mesaj gönderebilir.
- [x] Mesajların okunmuş/okunmamış/yeni mesaj olduğu anlaşılmalı.
- [x] Yaptığı ödemelerini görür.

● Daire/Konut bilgilerinde
- [x] Hangi blokda
- [x] Durumu (Dolu-boş)
- [x] Tipi (2+1 vb.)
- [x] Bulunduğu kat
- [x] Daire numarası
- [x] Daire sahibi veya kiracı

● Kullanıcı bilgilerinde
- [x] Ad-soyad
- [x] TCNo
- [x] E-Mail
- [x] Telefon
- [x] Araç bilgisi(varsa plaka no)

## Uygulama Görselleri
### MSSQL DataBase Diagram
---
![Database Diagram](https://github.com/KaderArslan/SiteManagement_Backend.NetCore/blob/master/screenshots/DatabaseDiagram.png)
#### Admin Login; İki farklı giriş senaryosu gerçekleştirdim. Admin Login ve User Login. Girişleri farklı ver görüntüledikleri farklı olacak şekilde proje geliştirildi.
```
{
  "adminEmail": "kaderarslandev@gmail.com",
  "adminPassword": "12345678"
}
```
![Admin Login](https://github.com/KaderArslan/SiteManagement_Backend.NetCore/blob/master/screenshots/adminlogin.png)
#### User Login
```
{
  "userEmail": "safak@gmail.com",
  "userPassword": "12345678"
}
```
![User Login](https://github.com/KaderArslan/SiteManagement_Backend.NetCore/blob/master/screenshots/userlogin.png)
---
#### Apartment User: Kullanıcı giriş yaptıktan sonra görüntüleyebileceği Apartman bilgileri;
![Apartment User](https://github.com/KaderArslan/SiteManagement_Backend.NetCore/blob/master/screenshots/apartmentuser.png)
#### Apartment Admin: Admin giriş yaptıktan sonra görüntüleyebileceği Apartman bilgileri;
![Apartment Admin](https://github.com/KaderArslan/SiteManagement_Backend.NetCore/blob/master/screenshots/apartmentadmin.png)
---
#### Bill User: Kullanıcı giriş yaptıktan sonra görüntüleyebileceği Fatura bilgileri;
![Bill User](https://github.com/KaderArslan/SiteManagement_Backend.NetCore/blob/master/screenshots/billuser.png)
#### Bill Admin: Admin giriş yaptıktan sonra görüntüleyebileceği Fatura bilgileri;
![Bill Admin](https://github.com/KaderArslan/SiteManagement_Backend.NetCore/blob/master/screenshots/billadmin.png)
---
#### Message User: Kullanıcı giriş yaptıktan sonra görüntüleyebileceği Mesajlaşma bilgileri;
![Message User](https://github.com/KaderArslan/SiteManagement_Backend.NetCore/blob/master/screenshots/messageuser.png)
#### Message Admin: Admin giriş yaptıktan sonra görüntüleyebileceği Mesajlaşma bilgileri;
![Message Admin](https://github.com/KaderArslan/SiteManagement_Backend.NetCore/blob/master/screenshots/messageadmin.png)
---
#### User User: Kullanıcı giriş yaptıktan sonra görüntüleyebileceği Kullanıcı bilgileri;
![User User](https://github.com/KaderArslan/SiteManagement_Backend.NetCore/blob/master/screenshots/useruser.png)
#### User Admin: Admin giriş yaptıktan sonra görüntüleyebileceği Kullanıcı bilgileri;
![User Admin](https://github.com/KaderArslan/SiteManagement_Backend.NetCore/blob/master/screenshots/useradmin.png)
---
### Postman ile sorguları get post metodlarını görebilmeniz için [postman_collection](https://github.com/KaderArslan/SiteManagement_Backend.NetCore/blob/master/SiteManagement.postman_collection.json) dosyasını postmaninize import ederek kullanabilirsiniz.
#### Postman Admin Login: Login olduktan sonra üretilen accesstoken bilgisine diğer gerçekleştirmek istediğiniz metodların Authorization Bearer Token bölümüne yapıştırarak sorgularınızı gerçekleştirebilirsiniz.
![Postman Login](https://github.com/KaderArslan/SiteManagement_Backend.NetCore/blob/master/screenshots/postmanlogin.png)

### Uygulama burada açılacaktır:
---
SiteManagement.WebApi: ```http://localhost:54620``` değişiklik gösterebilir.
SiteManagement.MongoDbApi: ```http://localhost:1606``` değişiklik gösterebilir.
