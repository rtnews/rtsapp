﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace rtnews
{
    public class HomeRep : NewsRep<HomeRep>
    {
        public override string StreamName()
        {
            return "HomeRep.json";
        }

        protected override string GetUrl()
        {
            return "api/news/GetHomeRep";
        }

        public override void RunInit()
        {
            base.RunInit();

            foreach (var i in mImageNewsList)
            {
                i.RunInit();
            }
        }
    }
}
