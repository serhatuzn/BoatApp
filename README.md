# BoatApp 🛥️

**BoatApp** projesine hoş geldiniz! Bu uygulama, MVVM (Model-View-ViewModel) tasarım deseni kullanılarak geliştirilmiş bir WPF (Windows Presentation Foundation) projesidir. 🚀

## 📂 Proje Yapısı

```
BoatApp/
├── App.xaml                     # Uygulama tanımı ve kaynaklar
├── App.xaml.cs                  # Uygulama yaşam döngüsü olayları
├── Boat.xaml                    # Boat görünüm tanımı
├── Boat.xaml.cs                 # Boat.xaml için kod tarafı
├── MainWindow.xaml              # Ana pencere görünüm tanımı
├── MainWindow.xaml.cs           # MainWindow.xaml için kod tarafı
├── Properties/                  # Uygulama ayarları ve kaynaklar
│   ├── AssemblyInfo.cs          # Derleme bilgileri
│   ├── Resources.Designer.cs    # Otomatik oluşturulan kaynaklar
│   ├── Resources.resx           # Kaynak tanımları
│   └── Settings.Designer.cs     # Uygulama ayarları
├── ViewModels/                  # ViewModel sınıfları
│   └── BoatViewModel.cs         # Boat için ViewModel
└── Models/                      # Model sınıfları
    └── Boat.cs                  # Boat veri yapısı
```

## 🛠️ Özellikler

- **MVVM Mimarisi**: Sorumlulukların temiz bir şekilde ayrılmasını sağlar.
- **Tekne Yönetimi**: Tekne ile ilgili verilerin etkili bir şekilde yönetimi.
- **WPF Arayüzü**: XAML kullanılarak modern ve duyarlı bir kullanıcı arayüzü.

## 🚀 Başlarken

### Gereksinimler

- **Visual Studio** (WPF geliştirme iş yükü ile)
- .NET Framework veya .NET Core SDK

### Kurulum

1. Depoyu klonlayın:
   ```bash
   git clone https://github.com/your-repo/BoatApp.git
   ```
2. Çözümü Visual Studio'da açın.
3. Uygulamayı derleyin ve çalıştırın.

## 📁 Önemli Dosyalar

- `Boat.cs`: Tekneler için veri yapısını tanımlar.
- `BoatViewModel.cs`: Boat görünümü için mantık ve veri bağlama işlemlerini içerir.
- `Boat.xaml`: Boat görünümü için XAML dosyası.

## 🤝 Katkıda Bulunun

Katkılar memnuniyetle karşılanır! Lütfen depoyu çatallayın ve bir pull request gönderin. Büyük değişiklikler için, önce bir sorun açarak yapmak istediğiniz değişiklikleri tartışın.

## 📜 Lisans

Bu proje MIT Lisansı altında lisanslanmıştır. Daha fazla bilgi için LICENSE dosyasına bakın.

---

