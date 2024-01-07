# vCard Generator

Bu proqram, RandomUser.me API-dən təsadüfi istifadəçi məlumatları çəkmək və bu məlumatları istifadə edərək vCard (Virtual Contact File) yaratmaq üçün nəzərdə tutulmuş bir C# konsol tətbiqidir.

## Xüsusiyyətləri

- RandomUser.me API-dən təsadüfi istifadəçi məlumatları çəkir.
- Çəkilən məlumatları vCard formatına çevirir.
- Yaradılan vCard-ları `.vcf` uzantılı fayllar kimi saxlayır.
- İstifadəçidən yaradılacaq vCard sayını soruşur.
- Yaradılan hər bir vCard üçün bənzərsiz bir fayl adı istifadə edir.

## İstifadəsi

Proqramı işlətmək üçün aşağıdakı addımları izləyin:

1. Visual Studio-da layihəni açın.
2. NuGet Package Manager vasitəsilə `Newtonsoft.Json` paketini layihənizə əlavə edin.
3. Tətbiqi başladın.
4. Konsol ekranında yaradılacaq vCard sayını daxil edin.
5. Proqram hər bir vCard üçün ayrı bir `.vcf` faylı yaradacaq və bunları `vCards` adlı bir qovluğa saxlayacaqdır.

## Tələblər

- .NET Core 3.1 və ya daha yüksək versiya.
- `Newtonsoft.Json` paketi.
