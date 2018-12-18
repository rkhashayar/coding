using HRSS.ManageMyNotes.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSS.ManageMyNotes.Repository
{
    public class ManageMyNotesDbContext : DbContext
    {
        const string ConnectionString = "Data Source=.;Initial Catalog=ManageMyNotes;Integrated Security=true";
        public ManageMyNotesDbContext() : base(ConnectionString)
        {

        }
        public virtual DbSet<Note> Notes { get; set; }

    }
}
