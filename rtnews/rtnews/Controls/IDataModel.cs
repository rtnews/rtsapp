using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtnews
{
    public interface IDataModel
    {
        void RunRefresh();

        void RunLoading();
    }
}
