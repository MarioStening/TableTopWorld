using JLib.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace TableTopWorld.Core.EntityFramework
{
    public class DataDefinition<T> : DataDefinition
    {
        public DataDefinition()
        {
        }
    }
    public abstract class DataDefinition : INotifyPropertyChanged
    {
        private string _name = string.Empty;
        public string Name
        {
            get => this._name;
            set => this.RaisePropertyChanged(ref this._name , value , PropertyChanged);
        }
        private ObservableCollection<RoleAccessMode> _roleAccessMode;
        public ObservableCollection<RoleAccessMode> RoleAccessMode
        {
            get => this._roleAccessMode;
            set => this.RaisePropertyChanged(ref this._roleAccessMode , value , PropertyChanged);
        }
        private Container _container = null;
        public Container Container
        {
            get => this._container;
            set => this.RaisePropertyChanged(ref this._container , value , PropertyChanged);
        }
        private DerivationModifier _derivationModifier = DerivationModifier.None;
        public DerivationModifier DerivationModifier
        {
            get => this._derivationModifier;
            set => this.RaisePropertyChanged(ref this._derivationModifier , value , PropertyChanged);
        }

        private bool _isStatic = false;
        public bool IsStatic
        {
            get => this._isStatic;
            set => this.RaisePropertyChanged(ref this._isStatic , value , PropertyChanged);
        }


        public ObservableCollection<Data> Data { get; } = new ObservableCollection<Data>();

        protected PropertyChangedEventHandler propertyChanged => PropertyChanged;
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
