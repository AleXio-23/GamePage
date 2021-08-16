using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Game.Domain.Shared
{
    public abstract class BaseEntity<T>
    {
        [XmlIgnore]
        public T Id { get; set; }
    }
}
