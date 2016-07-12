namespace HomeworkCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderItem")]
    public partial class OrderItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderItem()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string ItemName { get; set; }

        [Required]
        [StringLength(120)]
        public string Producer { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public bool IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
