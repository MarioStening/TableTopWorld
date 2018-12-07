using System.Collections.Generic;
using System.Collections.ObjectModel;
//using JLib.Extensions;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TableTopWorld.Core.EntityFramework;

namespace TableTopWorld.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Data SelectedData => this.lstVw_Data.SelectedItem as Data;
        public ObservableCollection<Data> Data => this.SelectedDataDefinition.FirstOrDefault().Data;

        public IEnumerable<DataDefinition> SelectedDataDefinition => this.lstVw_DataDef.SelectedItems.Cast<DataDefinition>();
        public ObservableCollection<DataDefinition> DataDefinitions => this.selectedContainer.FirstOrDefault()?.Properties;

        public IEnumerable<Container> selectedContainer => this.lstVw_Container.SelectedItems.Cast<Container>();
        public ObservableCollection<Container> Containers { get; } = new ObservableCollection<Container>();
        public MainWindow()
        {
            this.InitializeComponent();


        }
        private void removeSelection<T>(ListView lstvw , ObservableCollection<T> itemSrc)
        {
            if ( lstvw.SelectedItem == null )
                return;

            int oldIndex = lstvw.SelectedIndex;
            itemSrc.RemoveAt(oldIndex);
            lstvw.SelectedIndex = this.getSaveIndex(itemSrc.Count , oldIndex);
        }

        private int getSaveIndex(int elementCount , int index)
        {
            if ( index >= elementCount )
                return elementCount - 1;
            else
                return index;
        }

        #region Data
        private void btn_AddData_Clicked(object sender , RoutedEventArgs e)
        {
            Data<int> newData = new Data<int>();
            this.Data?.Add(newData);
            this.lstVw_Data.SelectedItem = newData;
        }
        private void btn_RemoveData_Clicked(object sender , RoutedEventArgs e)
        {
            this.removeSelection(this.lstVw_Data , this.Data);
        }
        private void lstVw_Data_SelectionChanged(object sender , SelectionChangedEventArgs e)
        {

        }
        #endregion
        #region Data definition
        private void btn_AddDataDefinition_Clicked(object sender , RoutedEventArgs e)
        {
            DataDefinition<int> newDataDefinition = new DataDefinition<int>();
            this.DataDefinitions?.Add(newDataDefinition);
            this.lstVw_DataDef.SelectedItem = newDataDefinition;
        }
        private void btn_RemoveDataDefinition_Clicked(object sender , RoutedEventArgs e)
        {
            this.removeSelection(this.lstVw_DataDef , this.DataDefinitions);
        }
        private void lstVw_DataDef_SelectionChanged(object sender , SelectionChangedEventArgs e)
        {
            this.lstVw_Data.ItemsSource = this.SelectedDataDefinition?.FirstOrDefault()?.Data;
        }
        #endregion
        #region container
        private void btn_AddContainer_Clicked(object sender , RoutedEventArgs e)
        {
            Container newContainer = new Container();
            this.Containers?.Add(newContainer);
            this.lstVw_Container.SelectedValue = newContainer;
        }
        private void btn_RemoveContainer_Clicked(object sender , RoutedEventArgs e)
        {
            this.removeSelection(this.lstVw_Container , this.Containers);
        }
        private void lstVw_Container_SelectionChanged(object sender , SelectionChangedEventArgs e)
        {
            if ( this.selectedContainer?.Count() != 1 )
                this.lstVw_DataDef.ItemsSource = null;
            else
                this.lstVw_DataDef.ItemsSource = this.selectedContainer?.FirstOrDefault()?.Properties;
        }
        #endregion
    }
}
