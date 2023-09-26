using System;
using System.Collections.Generic;

namespace CongresoSlade.Domain.Entities
{
    public partial class Area : BaseEntity
    {
        public Guid Id { get; set; }
        public string? Nombre { get; set; }
    }
}
