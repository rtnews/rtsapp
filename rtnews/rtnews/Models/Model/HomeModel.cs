using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace rtnews
{
    public class HomeModel
    {
        public List<ImageNews> ImageNewsList
        {
            get
            {
                return mImageNewsList;
            }
        }

        public List<TextNews> TextNewsList
        {
            get
            {
                return mTextNewsList;
            }
        }

        public INavigation Navigation
        {
            get
            {
                return mNavigation;
            }
            set
            {
                mNavigation = value;
            }
        }

        public HomeModel()
        {
            mImageNewsList = new List<ImageNews>();
            mTextNewsList = new List<TextNews>();
        }

        List<ImageNews> mImageNewsList;
        List<TextNews> mTextNewsList;

        INavigation mNavigation;
    }
}
