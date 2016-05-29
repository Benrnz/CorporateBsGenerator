using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CorporateBsGenerator.Annotations;

namespace CorporateBsGenerator
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string doNotUseIcon;
        private bool doNotUseIsBusy;
        private bool doNotUseIsNotBusy;
        private string doNotUseSubtitle;
        private string doNotUseTitle;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Icon
        {
            get { return this.doNotUseIcon; }
            set { SetProperty(ref this.doNotUseIcon, value); }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        /// <value><c>true</c> if this instance is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy
        {
            get { return this.doNotUseIsBusy; }
            set
            {
                if (SetProperty(ref this.doNotUseIsBusy, value)) IsNotBusy = !this.doNotUseIsBusy;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is not busy, ie ready.
        /// </summary>
        /// <value><c>true</c> if this instance is not busy; otherwise, <c>false</c>.</value>        
        public bool IsNotBusy
        {
            get { return this.doNotUseIsNotBusy; }
            private set { SetProperty(ref this.doNotUseIsNotBusy, value); }
        }

        public string Subtitle
        {
            get { return this.doNotUseSubtitle; }
            set { SetProperty(ref this.doNotUseSubtitle, value); }
        }

        public string Title
        {
            get { return this.doNotUseTitle; }
            set { SetProperty(ref this.doNotUseTitle, value); }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(
            ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
            return true;
        }
    }
}