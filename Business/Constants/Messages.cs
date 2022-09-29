using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Araba Eklendi";
        public static string Deleted = "Araba Silindi";
        public static string Updated = "Araba Güncellendi";
        public static string CarAddedError = "Araba en az 2 karakter olmalı ve günlük fiyat 0'dan fazla olmalıdır.";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string Failed = "Araba teslim edilmemiş";
        public static string ArabaListele = "Araba Listelendi";
        public static string BrandEkelendi = "Brand ekelendi";
        public static string BrandGuncellendi = "Brand güncellendi";
        public static string BrandSilindi = "Brand silindi";
        public static string RenkEklendi = "Renk eklendi";
        public static string RenkGuncellendi = "Renk Güncellendi";
        public static string RenkSilindi = "Renk Silindi";
        public static string CarCouldNotUpdated = "Araba güncellenemedi";
        public static string AuthorizationDenied = "Erişim reddedildi";
        public static string AccessTokenCreated = "Erişime  izin verildi";
        public static string UserNotFound = "Böyle bir kullanıcı yok";
       public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserRegistered = "Kullanıcı Kayıtlı";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
    }
}
