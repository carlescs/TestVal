using System;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;

namespace TestVal.Localization
{
    public class MyHtmlLocalizerFactory:IHtmlLocalizerFactory
    {
        private IStringLocalizerFactory _stringLocalizerFactory;

        public MyHtmlLocalizerFactory(IStringLocalizerFactory stringLocalizerFactory)
        {
            _stringLocalizerFactory = stringLocalizerFactory;
        }

        public IHtmlLocalizer Create(string baseName, string location)
        {
            return new MyHtmlLocalizer(_stringLocalizerFactory);
        }

        public IHtmlLocalizer Create(Type resourceSource)
        {
            return new MyHtmlLocalizer(_stringLocalizerFactory);
        }
    }
}