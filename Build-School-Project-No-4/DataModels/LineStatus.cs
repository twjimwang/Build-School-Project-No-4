namespace Build_School_Project_No_4.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LineStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LineStatus()
        {
            Members = new HashSet<Members>();
        }

        public int LineStatusId { get; set; }

        [StringLength(50)]
        public string LineStatusName { get; set; }

        public string LineStatusImg { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Members> Members { get; set; }
    }
}
