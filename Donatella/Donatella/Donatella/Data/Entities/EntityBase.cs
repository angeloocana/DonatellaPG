using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Donatella.Data.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }

        public DateTime DtInclusao { get; set; }

        public DateTime? DtAlteracao { get; set; }

        public virtual DateTime? DtInativacao { get; set; }
    }
}