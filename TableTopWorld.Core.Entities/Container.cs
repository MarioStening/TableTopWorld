using JLib.Extensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace TableTopWorld.Core.EntityFramework
{
    public class Container : INotifyPropertyChanged
    {
        private static ObservableCollection<Container> registredContainers { get; } = new ObservableCollection<Container>();
        public static ReadOnlyObservableCollection<Container> RegistredContainers { get; } = new ReadOnlyObservableCollection<Container>(registredContainers);
        public ObservableCollection<DataDefinition> Properties { get; } = new ObservableCollection<DataDefinition>();
        public List<DataDefinition> AllProperties
        {
            get
            {
                List<DataDefinition> inheritedDataDefs = this.InheritsFrom.SelectMany(x => x.AllProperties).ToList();
                inheritedDataDefs.AddRange(this.Properties);
                return inheritedDataDefs;
            }
        }
        private Namespace _namespace;
        public Namespace Namespace
        {
            get => this._namespace;
            set => this.RaisePropertyChanged(ref this._namespace , value , PropertyChanged);
        }
        private string _name;
        public string Name
        {
            get => this._name;
            set => this.RaisePropertyChanged(ref this._name , value , PropertyChanged);
        }
        public string QualifiedName => StringExtensions.Join(Namespace.Separator , StringExtensions.ExtendedJoinMode.RemoveNulls , this.Namespace.ToString() , this.Name);
        public ObservableCollection<Container> InheritsFrom { get; } = new ObservableCollection<Container>();

        public event PropertyChangedEventHandler PropertyChanged;

        public Container()
        {
            registredContainers.Add(this);
            this.InheritsFrom.CollectionChanged += (s , args) =>
            {
                this.updateCompleteContent();

                if ( args.OldItems != null )
                    foreach ( object item in args.OldItems )
                        ( item as DataDefinition ).PropertyChanged -= this.updateCompleteContent;

                if ( args.NewItems != null )
                    foreach ( object item in args.NewItems )
                        ( item as DataDefinition ).PropertyChanged += this.updateCompleteContent;
            };
        }
        private void updateCompleteContent(object src , PropertyChangedEventArgs args)
        {
            if ( args.PropertyName.In(nameof(this.AllProperties)) )
                this.updateCompleteContent();
        }
        private void updateCompleteContent()
        {
            PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(nameof(this.AllProperties)));
        }
    }
}
