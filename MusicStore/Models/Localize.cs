using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Localize
    {

        //private static MusicStoreDataContext db = new MusicStoreDataContext();
        private static Repository<Localize> context = new Repository<Localize>();

        [Key, Column(Order = 1, TypeName = "varchar")]
        [StringLength(maximumLength: 25, MinimumLength = 2)]
        public string LocalizeKey { get; set; }
        [Key, Column(Order = 2, TypeName = "varchar")]
        [StringLength(maximumLength: 5, MinimumLength = 2)]
        public string LanguageKey { get; set; }
        public string LocalizeValue { get; set; }
        public Language Language { get; set; }

        public static string GetLocalize(string clang, string key)
        {
            try
            {
                var data = context.DbSet.Where(c => c.LocalizeKey.Equals(key) && c.LanguageKey.Contains(clang)).FirstOrDefault();
                if (data != null
                    && !string.IsNullOrEmpty(data.LocalizeValue))
                {
                    return data.LocalizeValue;
                }
                return key.Replace("@", "") + "";
            }
            catch (Exception)
            {
                return key.Replace("@", "") + "";
            }
        }

    }
}