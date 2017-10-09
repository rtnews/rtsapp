using System.Collections;
using System.Windows.Input;
using Xamarin.Forms;

namespace rtnews
{
    public class InfiniteListView : ListView
    {
        public static readonly BindableProperty LoadMoreCommandProperty
            = BindableProperty.Create("LoadMoreCommand", typeof(ICommand), typeof(InfiniteListView));

        public ICommand LoadMoreCommand
        {
            get { return (ICommand)GetValue(LoadMoreCommandProperty); }
            set { SetValue(LoadMoreCommandProperty, value); }
        }

        void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var items = ItemsSource as IList;

            if (items != null && e.Item == items[items.Count - 1])
            {
                if (LoadMoreCommand != null && LoadMoreCommand.CanExecute(null))
                {
                    LoadMoreCommand.Execute(null);
                }
            }
        }

        public InfiniteListView()
        {
            ItemAppearing += OnItemAppearing;
        }
    }
}
