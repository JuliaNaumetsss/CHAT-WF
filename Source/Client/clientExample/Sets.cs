using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientExample
{
    public static class Sets
    {
        public enum UserRole
        {
            Regular,
            Admin
        }

        public static FormRegister RegisterInstance { get; set; }
    }
}
