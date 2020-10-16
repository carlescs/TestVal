using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Security;
using Microsoft.Extensions.Localization;

namespace TestVal.Localization
{
    public class MyStringLocalizer:IStringLocalizer
    {
        private Dictionary<string,Dictionary<string,string>> translations=new Dictionary<string, Dictionary<string, string>>
        {
            {"hello",new Dictionary<string, string>{{"en","Hola"},{"de","Adeu"}}},
            {"second",new Dictionary<string, string>{{"en","Hola2"},{"de","Adeu2"}}}
        };
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new System.NotImplementedException();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }

        public LocalizedString this[string name] => GetLocalizedString(name);

        private LocalizedString GetLocalizedString(string name)
        {
            var culture = CultureInfo.CurrentCulture.ToString();
            if (translations.TryGetValue(name, out var item))
            {
                return item.TryGetValue(culture,out var translation) 
                    ? new LocalizedString(name, translation) 
                    : new LocalizedString(name, $"~{name}~", true);
            }

            return new LocalizedString(name, $"#{name}#", true);
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var localizedString = GetLocalizedString(name);
                return new LocalizedString(name, string.Format(localizedString.Value, arguments),localizedString.ResourceNotFound);
            }
        }
    }
}