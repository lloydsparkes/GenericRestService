using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sparkles.GenericRestService.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public virtual ICollection<Objects> Objects { get; set; }
    }
}