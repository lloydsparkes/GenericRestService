using Newtonsoft.Json.Linq;
using Sparkles.GenericRestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sparkles.GenericRestService.Controllers
{
    [RoutePrefix("api")]
    public class ResourceController : ApiController
    {
        private DatabaseContext _db = new DatabaseContext();

        [HttpGet]
        [Route("{resource}")]
        public IEnumerable<ViewObject> GetAll(String resource)
        {
            var res = _db.Resources.Where(r => r.Name == resource).FirstOrDefault();
            if (res == null)
            {
                return new List<ViewObject>();
            }
            return res.Objects.Select(o => o.TransformToView());
        }

        [HttpGet]
        [Route("{resource}/{id:int}")]
        public ViewObject Get(String resource, int id)
        {
            var res = _db.Resources.Where(r => r.Name == resource).FirstOrDefault();
            if (res == null) { return null; }

            var obj = res.Objects.Where(o => o.Id == id).FirstOrDefault();
            if (obj == null) { return null; }

            return obj.TransformToView();
        }

        [HttpDelete]
        [Route("{resource}/{id:int}")]
        public bool Delete(String resource, int id)
        {
            var res = _db.Resources.Where(r => r.Name == resource).FirstOrDefault();
            if (res == null) { return false; }

            var obj = res.Objects.Where(o => o.Id == id).FirstOrDefault();
            if (obj == null) { return false; }

            _db.Objects.Remove(obj);
            _db.SaveChanges();

            return true;
        }

        [HttpPut]
        [HttpPost]
        [Route("{resource}")]
        public int Create(String resource, [FromBody]JToken document) 
        {
            var res = _db.Resources.Where(r => r.Name == resource).FirstOrDefault();
            if (res == null) {
                res = new Resource { Name = resource };
                _db.Resources.Add(res);
                _db.SaveChanges();
            }

            var obj = new Objects { Resource = res, Document = document.ToString(), CreatedTimestamp = DateTime.Now, UpdatedTimestamp = DateTime.Now };
            _db.Objects.Add(obj);
            _db.SaveChanges();

            return obj.Id;
        }

        [HttpPut]
        [HttpPost]
        [Route("{resource}/{id:int}")]
        public bool Update(String resource, int id, [FromBody]JToken document) 
        {
            var res = _db.Resources.Where(r => r.Name == resource).FirstOrDefault();
            if (res == null) { return false; }

            var obj = res.Objects.Where(o => o.Id == id).FirstOrDefault();
            if (obj == null) { return false; }

            obj.Document = document.ToString();
            _db.SaveChanges();

            return true;
        }
    }
}
