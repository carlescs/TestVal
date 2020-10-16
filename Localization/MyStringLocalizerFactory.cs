using System;
using System.Diagnostics;
using Microsoft.Extensions.Localization;

namespace TestVal.Localization
{
    public class MyStringLocalizerFactory:IStringLocalizerFactory
    {
        public IStringLocalizer Create(string baseName, string location)
        {
            return new MyStringLocalizer();
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return new MyStringLocalizer();
        }
    }
}