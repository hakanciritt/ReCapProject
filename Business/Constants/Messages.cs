using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public const string Added = "Eklendi";
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
    }
}
