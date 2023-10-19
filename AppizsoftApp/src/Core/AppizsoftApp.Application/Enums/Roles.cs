namespace AppizsoftApp.Application.Enums
{

    [Flags]
    public enum Roles
    {
        None = 0, // Hiçbir rol atanmamış.
        SuperAdmin = 1, // En yüksek yetkilendirme seviyesine sahip yönetici.
        Admin = 2, // Yönetici yetkilerine sahip kullanıcı.
        User = 4, // Temel kullanıcı yetkilerine sahip kullanıcı.
        Editor = 8, // İçerik düzenleme yetkilerine sahip kullanıcı.
        Support = 16, // Destek ekibi üyesi.
        Restricted_User = 32, // Sınırlı yetkilere sahip kullanıcı.
        Subscriber = 64, // Abone rolüne sahip kullanıcı.

        // Proje Yönetimi ve Geliştirme Rolleri
        ProjectManager = 128, // Proje yöneticisi.
        Developer = 256, // Yazılım geliştirici.
        QA_Engineer = 512, // Kalite kontrol mühendisi.

        // Pazarlama ve Satış Rolleri
        Marketing = 1024, // Pazarlama ekibi üyesi.
        Sales = 2048, // Satış ekibi üyesi.

        // Müşteri Hizmetleri ve Finans Rolleri
        CustomerService = 4096, // Müşteri hizmetleri yetkilisi.
        Finance = 8192, // Finans departmanı çalışanı.

        // İnsan Kaynakları ve Hukuk Rolleri
        HR = 16384, // İnsan kaynakları departmanı yetkilisi.
        Legal = 32768, // Hukuk departmanı çalışanı.

        // Proje Paydaşları ve Danışmanlar
        ProjectClient = 65536, // Proje müşterisi.
        Consultant = 131072, // Danışman.

        // Özel İş Roller
        ProductOwner = 524288, // Ürün sahibi, Scrum veya Agile projelerinde.
        DataAnalyst = 1048576, // Veri analisti, veri analizi ve raporlama.
        DataScientist = 2097152, // Veri bilimci, veri madenciliği ve tahminleme.
        ContentCreator = 4194304, // İçerik oluşturucu, içerik üretimi ve yönetimi.
        GraphicDesigner = 8388608, // Grafik tasarımcı, görsel içerik tasarımı.
        NetworkAdministrator = 16777216, // Ağ yöneticisi, ağ altyapısı ve güvenlik.
        SystemAdministrator = 33554432, // Sistem yöneticisi, sunucu ve sistem yönetimi.
        Vendor = 67108864, // Tedarikçi, dış kaynak kullanımı.
        ProjectStakeholder = 134217728 // Proje paydaşı, projeyi etkileyen kişiler.
    }

}
