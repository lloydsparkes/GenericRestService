using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Sparkles.GenericRestService.Models
{
    public class Objects
    {
        public int Id { get; set; }

        public String Document { get; set; }
        
        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }

        public virtual Resource Resource { get; set; }

        public ViewObject TransformToView()
        {
            return new ViewObject
            {
                Id = Id,
                Document = JToken.Parse(Document),
                CreatedTimestamp = CreatedTimestamp,
                UpdatedTimestamp = UpdatedTimestamp
            };
        }
    }

    public class ViewObject
    {
        public int Id { get; set; }

        public JToken Document { get; set; }

        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }
    }
}