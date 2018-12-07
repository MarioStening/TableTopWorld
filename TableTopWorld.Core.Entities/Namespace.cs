using JLib.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;


namespace TableTopWorld.Core.EntityFramework
{
    public class Namespace : INotifyPropertyChanged
    {
        private static ObservableCollection<Namespace> registredNamespaces { get; } = new ObservableCollection<Namespace>();
        public static ReadOnlyObservableCollection<Namespace> RegistredNamespaces { get; } = new ReadOnlyObservableCollection<Namespace>(registredNamespaces);
        public static string Separator = ".";
        public static ReadOnlyCollection<char> InvalidSymbols { get; } = new ReadOnlyCollection<char>(new char[] { '.' , ' ' });

        public event PropertyChangedEventHandler PropertyChanged;
        

        private string _name;
        public string Name
        {
            get => this._name;
            set
            {
                this.invalidNameCheck(value);
                this.RaisePropertyChanged(ref this._name , value.Trim() , PropertyChanged);
            }
        }
        private void invalidNameCheck(string name)
        {
            //empty
            if ( string.IsNullOrWhiteSpace(name) )
                throw new InvalidOperationException("the namespace must not be empty");

            //prohibbited symbol
            int invalidIndex = name.Trim().IndexOfAny(InvalidSymbols.ToArray());
            if ( invalidIndex != -1 )
                throw new InvalidOperationException($"invalid symbol found at {invalidIndex}. Invalid symbols are: '{string.Join("', '" , InvalidSymbols)}'.");
        }
        private Namespace _majorNamespace;
        public Namespace MajorNamespace
        {
            get => this._majorNamespace;
            set => this.RaisePropertyChanged(ref this._majorNamespace , value , PropertyChanged);
        }
        internal void RemoveContentRegistration(Container container)
        {
            this.content.Remove(container);
            if(this.Content)
        }
        internal void AddContentRegistration(Container container) => this.content.Add(container);
        private ObservableCollection<Container> content { get; } = new ObservableCollection<Container>();
        public ReadOnlyObservableCollection<Container> Content { get; }
        public override string ToString() => StringExtensions.Join(Separator , StringExtensions.ExtendedJoinMode.RemoveNulls , this.MajorNamespace?.ToString() , this.Name);

        public static Namespace Parse(string namespaceString)
        {
            Namespace majorNamespace = null;
            foreach ( string subNamespace in namespaceString.Split(Separator) )
            {
                IEnumerable<Namespace> currentNamespaces = RegistredNamespaces.Where(x => x.Name == subNamespace && x.MajorNamespace == majorNamespace);

                Namespace currentNamespace = null;
                switch ( currentNamespaces.Count() )
                {
                    case 0:
                        currentNamespace = new Namespace(subNamespace , majorNamespace);
                        break;
                    case 1:
                        currentNamespace = currentNamespaces.FirstOrDefault();
                        break;
                    case var _ when ( currentNamespaces.Count() > 1 ):
                        throw new Exception("multiple identical namespaces found");
                }
                majorNamespace = currentNamespace;
            }
            return majorNamespace;
        }

        private Namespace(string name , Namespace majorNamespace)
        {
            this.Name = name;
            this.MajorNamespace = majorNamespace;
            this.Content = new ReadOnlyObservableCollection<Container>(this.content);

            registredNamespaces.Add(this);
        }
    }
}
