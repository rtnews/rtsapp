using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace rtnews
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (null == PropertyChanged) return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
