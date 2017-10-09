using rtnews.Strings;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace rtnews
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return StringTable.ResourceManager.GetString(Text);
        }

        public string Text { get; set; }
    }
}
