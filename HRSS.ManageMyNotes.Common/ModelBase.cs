using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSS.ManageMyNotes.Common
{
    public class ModelBase<T> :EntityBase, IModelBase<T>
    {
        public virtual T ID { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime LastUpdatedDate { get; set; }
    }
    public interface IModelBase<T>
    {
        T ID { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime LastUpdatedDate { get; set; }
    }
    public class EntityBase { }
}
