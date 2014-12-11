﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace Tapas
{

    [Serializable]
    public class PortableNode
    {
        //private PortableNodeCollection portableNodeCollection;
        //public PortableNodeCollection PortableNodeCollection
        //{
        //    set
        //    {
        //        portableNodeCollection = value;
        //    }
        //}
        public PortableNode()
        {
            //this.Children = new List<PortableNode>();
            //this.ContentSet = new List<PortableNode>();
            this.Properties = new List<object>();
            this.PropertiesDictionary = new Dictionary<string, object>();
        }

        [JsonIgnore]
        public object ContentType { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatorId { get; set; }
        public string CreatorName { get; set; }
        public string DocumentTypeAlias { get; set; }
        public int DocumentTypeId { get; set; }
        public int GetIndex()
        {
            throw new NotImplementedException();
        }
        public object GetProperty(string alias, bool recurse)
        {
            throw new NotImplementedException();
        }
        public object GetProperty(string alias)
        {
            throw new NotImplementedException();
        }
        public int Id { get; set; }
        public bool IsDraft { get; set; }

        [JsonIgnore]
        public object ItemType { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        
        public int ParentId { get; set; }
        public string Path { get; set; }
        [JsonIgnore]
        public ICollection<object> Properties { get; set; }
        [JsonProperty(PropertyName = "Properties")]
        public Dictionary<string, object> PropertiesDictionary { get; set; }
        public int SortOrder { get; set; }
        public int TemplateId { get; set; }
        public string TemplateAlias { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Url { get; set; }
        public string UrlName { get; set; }
        public Guid Version { get; set; }
        public int WriterId { get; set; }
        public string WriterName { get; set; }

        [JsonIgnore]
        public object this[string alias]
        {
            get { return null; }
            set { ; }
        }
        
    }
}