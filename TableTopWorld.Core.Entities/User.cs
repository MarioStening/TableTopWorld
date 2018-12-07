using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace TableTopWorld.Core.EntityFramework
{
    public class User
    {
        public ObservableCollection<Data> Data { get; } = new ObservableCollection<Data>();
    }
}