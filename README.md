## Projenin Çalıştırılması
```
1- Komut satırını açın ve proje dizinine locate olun.
2- Komut satırına 'Docker-Compose run' yazıp enter tuşuna basın
3- visual studio da projeyi açın
4- Set a startup project olaran 'LgwCase.Services.Product.API' seçin
5- Package manager console da default Proje olarak LgwCase.Services.Product.Infrastructure seçin
6- Package manager console da 2Update-Database' komutunu çalıştırın
```

## Projenin ile ilgili açıklamalar
```
Proje .net 5.0 da geliştirlimiştir
Token yönetimi için Identtiy Server 4 kullanılmıştır.
Gateway olarak Oselot kütüphanesinden faydalanılmıştır.
Proje mikroservis mimarasi üzerine inşa edilmiştir.
Validation için Fluen Validation kütüphanesi kullanılmıştır.
```

## Endpoin açıklamaları
```
Bu bölümde verilecek olan port bilgilerinin hepsi proje dizininde SolutionItems klasörü altındaki Port.txt klasöründe mevcuttur.
SolutionItems klasörü altında ki **Postman_LogiwaCase.json** dosyasında postman collection'ı paylaşılmıştır.
Services Ports:
	-ProductAPI => 5017
	-identityserver=> 5001
	-gateway=> 5000

İdentityServer: http://localhost:5001/connect/token
GateWay: http://localhost:5000
ProductAPI: http://localhost:5017/api/Product/{actionname}
ProductAPI(GateWay üzerinden): http://localhost:5000/Services/Product/Product/{actionName}
```

## Kullanıcı açıklamarı
```
Proje ayağa kalkarken token alabilmesi için bir adet kullanıcı oluşturulmaktadır(UserName: user@logiwa.com, Password:Password12-).
Bu kullanıcı ile identity serverdan (http://localhost:5001/connect/token) token alınabilinecektir.Postman colllectionında detaylı endpoinlere ulaşacabilirsiniz.
Alınan token ile diğer endpoinlere çağrıda bulunabilirsiniz
```

## Docker ile token alınması durumunda
```
Bu durumda eğer hata alırsanız **identitydb ve productdb** containerları dışındaki tüm containerları durdurun.
Visiual Studio üzerinde projeyi açın. Tüm projeleri set a startup olarak ayrı ayı çalıştırıp run edin.
Visiual Studio da solution properties de 3 projede ayağa kalkacak şekilde ayarlayın.
Postman collectionındaki endpointlere çağrıda bulunun(Öncelikle token alan end pointten token alıp, ilgili enppointeki servise token'ı OAuth 2.0 olarak ekleyin).
```

######  Unit teslerinin yazılması zaman sıkıntısı nedeniyle yapılamadı.
###### Teşekkürler :)




