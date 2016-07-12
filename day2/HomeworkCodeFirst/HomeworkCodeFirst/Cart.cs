namespace HomeworkCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int Discount { get; set; }

        public virtual Order Order { get; set; }
    }
}
