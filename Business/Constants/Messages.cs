using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public const string BrandAdded = "Marka Eklendi";
        public const string CarUpdated = "Araba başarıyla güncellendi";
        public const string Added = "Marka Eklendi";
        public const string Deleted = "Silindi";
        public const string Updated = "Güncellendi";
        public const string ImageInsertionLimitExceeded = "Resim yükleme sınırı aşıldı";
        public const string UserRegistered = "Başarıyla kaydolundu";
        public const string UserNotFound = "Kullanıcı bulunamadı";
        public const string PasswordError = "Şifre eşleşmiyor";
        public const string SuccessfulLogin = "Başarıyla giriş yapıldı";
        public const string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public const string AccessTokenCreated = "Token oluşturuldu";
        public const string AuthorizationDenied = "Yetkisiz deneme";
        public const string RentStatus = "Araç belirtilen tarih aralığında başkası tarafından kiralanmış";
    }
}
