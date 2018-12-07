using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableTopWorld.Core.EntityFramework
{
    public class RoleAccessMode
    {
        public AccessMode AccessMode { get; set; }

        public Role Role { get; set; }
    }
}