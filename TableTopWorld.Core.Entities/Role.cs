using System.Collections.Generic;

namespace TableTopWorld.Core.EntityFramework
{
    public class Role
    {
        public List<User> Users { get; set; }

        public Role DerivedFrom { get; set; }
    }
}