namespace NET200703.ZSGC.POCOModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Studio")]
    public partial class Studio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Studio()
        {
            Game = new HashSet<Game>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(64)]
        public string sName { get; set; }

        [Required]
        [StringLength(64)]
        public string sTel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Game> Game { get; set; }
    }
}
