using HRSS.ManageMyNotes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSS.ManageMyNotes.Model
{
    public class Note : ModelBase<Guid>
    {
        public virtual string Text { get; set; }
    }
}
