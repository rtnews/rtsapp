using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtnews
{
    public class News0Rep : NewsRep<News0Rep>
    {
        protected override string GetUrl()
        {
            return "api/values/GetNews0Rep";
        }

        public override string StreamName()
        {
            return "News0Rep.json";
        }
    }
}
