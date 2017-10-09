using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtnews
{
    public class News1Rep : NewsRep<News1Rep>
    {
        protected override string GetUrl()
        {
            return "api/values/GetNews1Rep";
        }

        public override string StreamName()
        {
            return "News1Rep.json";
        }
    }
}
