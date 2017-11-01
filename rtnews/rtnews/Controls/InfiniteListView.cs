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

        public static readonly BindableProperty SelectItemCommandProperty
            = BindableProperty.Create("SelectItemCommand", typeof(ICommand), typeof(InfiniteListView));

        public ICommand SelectItemCommand
        {
            get { return (ICommand)GetValue(SelectItemCommandProperty); }
            set { SetValue(SelectItemCommandProperty, value); }
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

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (SelectItemCommand != null && SelectItemCommand.CanExecute(null))
            {
                SelectItemCommand.Execute(e.SelectedItem);
            }

            if (this.SelectedItem == null)
                return;
            this.SelectedItem = null;
        }

        public InfiniteListView()
        {
            ItemAppearing += OnItemAppearing;
            ItemSelected += OnItemSelected;
        }
    }
}
