using System.ComponentModel;
using System.Runtime.CompilerServices;
using Finance.Annotations;

namespace Finance.ServiceClasses
{
    public class PropertyNotificator : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}