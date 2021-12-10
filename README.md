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
Proje mikroservis mimarasi üzerine inşa edilmiştir
```

## Endpoin açıklamaları
```
Bu bölümde verilecek olan port bilgilerinin hepsi proje dizininde SolutionItems klasörü altındaki Port.txt klasöründe mevcuttur.
SolutionItems klasörü altında ki **Postman_LogiwaCase.json** dosyasında postman collection'ı paylaşılmıştır.
Services Ports:
	-ProductAPI => 5017
	-identityserver=> 5001
	-gateway=> 5000
```

##



