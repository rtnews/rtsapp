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
            return "api/news/GetGlobRep";
        }

        public override string StreamName()
        {
            return "News1Rep.json";
        }

        public override string GetLoadUrl()
        {
            return "api/news/GetGlobPage";
        }

        public override string GetReadUrl()
        {
            return "api/news/UpdateGlobRead";
        }
    }
}
