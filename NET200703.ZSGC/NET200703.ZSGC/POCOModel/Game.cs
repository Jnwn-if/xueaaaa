namespace NET200703.ZSGC.POCOModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Game")]
    public partial class Game
    {
        public int id { get; set; }

        public int gTid { get; set; }

        public int gSId { get; set; }

        [Required]
        [StringLength(128)]
        public string gName { get; set; }

        public double gPrice { get; set; }

        public bool gState { get; set; }

        public virtual Studio Studio { get; set; }

        public virtual GType GType { get; set; }
    }
}
