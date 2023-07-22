## Sipay API
# Sipay API, finansal işlemleri sorgulama ve yönetme yeteneği sağlayan bir RESTful web servisidir.

Başlıca Özellikler:
İşlemleri farklı kriterlere göre sorgulama.
Otomatik nesne dönüşümü için AutoMapper entegrasyonu.
Entity Framework Core ile veritabanı işlemleri.


# TransactionController
Bu Controller, finansal işlemleri sorgulamak için kullanılır.

GET /sipy/api/Transaction/GetByParameter:
Birden fazla sorgu parametresine göre işlemleri filtreleyerek getirir.
Parametreler opsiyoneldir; belirtilen parametrelerle filtreleme yapılır.
Örnek: İşlemleri bir hesap numarasına ve belirli bir kredi miktarına göre filtrelemek için /sipy/api/Transaction/GetByParameter?accountNumber=12345&minAmountCredit=100 şeklinde bir sorgu oluşturabilirsiniz.


Filtreleme Detayları: GET /sipy/api/Transaction/GetByParameter
Bu endpoint, çeşitli kriterlere göre işlemleri filtrelemek için kullanılır. İşte filtre kriterleri ve kullanımları:

* accountNumber: Spesifik bir hesap numarasına göre işlemleri getirir.
* minAmountCredit: Bu miktarın üzerinde kredi miktarına sahip işlemleri getirir.
* maxAmountCredit: Bu miktarın altında kredi miktarına sahip işlemleri getirir.
* minAmountDebit: Bu miktarın üzerinde borç miktarına sahip işlemleri getirir.
* maxAmountDebit: Bu miktarın altında borç miktarına sahip işlemleri getirir.
* description: İşlem açıklamasında belirtilen metni içeren işlemleri getirir.
* beginDate: Belirtilen tarihten sonraki işlemleri getirir.
* endDate: Belirtilen tarihe kadar olan işlemleri getirir.
* referenceNumber: Spesifik bir referans numarasına göre işlemleri getirir.
* Filtreleme Örnekleri:
* Belirli bir hesap numarasına ve kredi miktar aralığına göre filtreleme:
    /sipy/api/Transaction/GetByParameter?accountNumber=12345&minAmountCredit=100&maxAmountCredit=500

* Belirli bir tarih aralığındaki işlemleri getirme:
/sipy/api/Transaction/GetByParameter?beginDate=2022-01-01&endDate=2022-12-31

* Açıklamasında belirli bir kelimeyi içeren işlemleri getirme:
/sipy/api/Transaction/GetByParameter?description=maaş
