using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcheryFrontend
{
    public partial class User
    {
        public int Id { get; set; }

        public string vname { get; set; }

        public string lname { get; set; }

        public string nickname { get; set; }

        public string? fullname => vname + " " + lname;
    }
}
