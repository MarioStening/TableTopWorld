using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableTopWorld.Core.EntityFramework
{
    public enum AccessMode
    {
        Read,
        Write,
        ReadWrite,
        Hidden
    }
}