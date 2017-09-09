using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Language
    {
        //private static MusicStoreDataContext db = new MusicStoreDataContext();
        private static Repository<Language> context = new Repository<Language>();

        [Key, Column(Order = 2, TypeName = "varchar")]
        [StringLength(maximumLength: 5, MinimumLength = 2)]
        public string LanguageKey { get; set; }
        public string LanguageValue { get; set; }
        public string ImageUrl { get; set; }
        public bool IsEnable { get; set; }
        public bool IsDefault { get; set; }
        public int Order { get; set; }

        public static List<Language> GetLanguageList()
        {
            var data = context.GetAll().OrderBy(o=>o.Order).ToList();
            return data;
        }

        public static string GetDefaultLanguage
        {
            get
            {
                var data = context.DbSet.Where(l => l.IsDefault == true).FirstOrDefault();
                return data.LanguageKey;
            }
        }
        public static string GetCurrentLanguage
        {
            get
            {
                var lang = HttpContext.Current.Request.QueryString["lang"];
                var clang = "";
                if (!string.IsNullOrEmpty(lang))
                {
                    clang = lang;
                }
                else
                {
                    clang = Language.GetDefaultLanguage;
                }
                return clang;
            }
        }
    }
}