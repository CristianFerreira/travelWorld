﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWebStore.Domain.Entities
{
    public class Continent
    {
   
        public int Id { get; set; }
        public string name { get; set; }
        public virtual ICollection<Country> countries { get; set; }
    }
}
