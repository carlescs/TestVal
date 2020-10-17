using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;

namespace TestVal.Localization
{
    public class MyHtmlLocalizer:IHtmlLocalizer
    {
        private IStringLocalizer _stringLocalizer;

        public MyHtmlLocalizer(IStringLocalizerFactory stringLocalizerFactory)
        {
            this._stringLocalizer = stringLocalizerFactory.Create(null);
        }
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new System.NotImplementedException();
        }

        public LocalizedString GetString(string name)
        {
            return _stringLocalizer[name];
        }

        public LocalizedString GetString(string name, params object[] arguments)
        {
            return _stringLocalizer[name, arguments];
        }

        public IHtmlLocalizer WithCulture(CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }

        public LocalizedHtmlString this[string name]
        {
            get
            {
                var str = GetString(name);
                return new LocalizedHtmlString(name,str.Value,str.ResourceNotFound);
            }
        }

        public LocalizedHtmlString this[string name, params object[] arguments]
        {
            get
            {
                var str = GetString(name,arguments);
                return new LocalizedHtmlString(name, str.Value, str.ResourceNotFound);
            }
        }
    }
}