using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wish.Domain.Abstractions;
using Wish.Domain.Constants;
using static Wish.Domain.Enums.Types;

namespace Wish.Domain.Entities
{
    [Table(Tables.Materials)]
    public class Material : BaseEntity
    {
        [Column(Columns.Type)]
        public MaterialType Type { get; set; }

        [Column(Columns.Title)]
        public string Title { get; set; }
    }
}
