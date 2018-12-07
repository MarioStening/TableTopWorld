using JLib.Extensions;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TableTopWorld.Core.EntityFramework
{
    public class Data<T> : Data
    {
        private DataDefinition<T> _container;
        public DataDefinition<T> Container
        {
            get => this._container;
            set => this.RaisePropertyChanged(ref this._container , value , this.propertyChanged);
        }
        private T _defaultValue;
        public T DefaultValue
        {
            get => this._defaultValue;
            set => this.RaisePropertyChanged(ref this._defaultValue , value , this.propertyChanged);
        }
        public override object GenericDefaultValue
        {
            get => this.DefaultValue;
            set => this.DefaultValue = (T)value;
        }
        public override DataDefinition GenericContainer
        {
            get => this.Container;
            set => this.Container = value as DataDefinition<T>;
        }

    }


    public abstract class Data : INotifyPropertyChanged
    {
        //abstract
        public abstract DataDefinition GenericContainer { get; set; }
        public abstract object GenericDefaultValue { get; set; }

        private string _name;
        public string Name
        {
            get => this._name;
            set => this.RaisePropertyChanged(ref this._name , value , PropertyChanged,"Name");
        }

        private DerivationModifier _derivationModifier;
        public DerivationModifier DerivationModifier
        {
            get => this._derivationModifier;
            set => this.RaisePropertyChanged(ref this._derivationModifier , value , PropertyChanged);
        }

        private Guid _id;
        public Guid ID
        {
            get => this._id;
            set => this.RaisePropertyChanged(ref this._id , value , PropertyChanged);
        }

        private Data _objects;
        public Data Objects
        {
            get => this._objects;
            set => this.RaisePropertyChanged(ref this._objects , value , PropertyChanged);
        }

        private ObservableCollection<RoleAccessMode> _roleAccessModes;
        public ObservableCollection<RoleAccessMode> RoleAccessModes
        {
            get => this._roleAccessModes;
            set => this.RaisePropertyChanged(ref this._roleAccessModes , value , PropertyChanged);
        }

        protected PropertyChangedEventHandler propertyChanged => PropertyChanged;
        public event PropertyChangedEventHandler PropertyChanged;


    }
}
