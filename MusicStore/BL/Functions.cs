using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.BL
{
    public class Functions
    {
        public static string GetUrlSwitcher(string clang, string rlang)
        {
            if (clang == rlang)
            {
                return HttpContext.Current.Request.RawUrl + "#";
            }
            else
            {
                return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path) + "?" + "lang=" + rlang;
            }
        }
    }
}