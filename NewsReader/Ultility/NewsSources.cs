using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsReader.Ultility
{
    public static class NewsSources
    {
        private static readonly string[] Tag = new[]
                                            {
                                                "vnexpress",
                                                "dantri",
                                                "vietnamnet",
                                                "kenh14",
                                                "gamek",
                                                "gemk"
                                            };

        private static readonly string[] Title = new[]
                                                     {
                                                         "VnExpress",
                                                         "Dân trí",
                                                         "Vietnamnet",
                                                         "Kênh 14",
                                                         "GameK",
                                                         "GenK"
                                                     };

        private static readonly string[] Description = new[]
                                                 {
                                                     "Thông tin nhanh & mới nhất được cập nhật hàng giờ. Tin tức Việt Nam & thế giới về xã hội, kinh doanh, pháp luật, khoa học, công nghệ, sức khoẻ, đời sống, văn hóa,...",
                                                     "Tin tức, sự kiện, thời sự mới nhất cập nhật liên tục trong ngày.",
                                                     "Tin tức, thông tin cập nhật liên tục. Trong nước, Quốc tế, Chính trị, Xã hội, Đời sống, Văn hóa, Giải trí, Thể thao...",
                                                     "Trang tin tức giải trí - xã hội Việt Nam - Quốc Tế. Đưa tin nhanh nhất : thời trang, video ngôi sao, phim ảnh, tình yêu, học đường, các chuyển động xã hội.",
                                                     "Kênh cung cấp những thông tin mới nhất về Game mới được phát hành, Reviews các tựa Games hay đang chơi, công nghệ Game trong nước và thế giới.",
                                                     "GenK là Website uy tín số 1 Việt Nam cung cấp cho bạn những thông tin mới nhất về công nghệ và thế giới Internet,tin tức sản phẩm cong nghe mới."
                                                 };
        public static string GetTitle(string sourceTag)
        {
            for (int index = 0; index < Tag.Length; index++)
            {
                var t = Tag[index];
                if (t.ToLower() == sourceTag.ToLower())
                {
                    return Title[index];
                }
            }
            return string.Empty;
        }

        public static string GetDescription(string sourceTag)
        {
            for (int index = 0; index < Tag.Length; index++)
            {
                var t = Tag[index];
                if (t.ToLower() == sourceTag.ToLower())
                {
                    return Description[index];
                }
            }
            return string.Empty;
        }
    }
}
