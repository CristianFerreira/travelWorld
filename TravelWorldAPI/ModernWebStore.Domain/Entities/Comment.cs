using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernWebStore.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }


        public ICollection<SomeComments> Comments { get; set; }


    }
}
