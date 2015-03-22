﻿namespace SupermarketsChain.Oracle
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MEASURES")]
    public class MEASURE
    {
        public MEASURE()
        {
            this.PRODUCTS = new HashSet<PRODUCT>();
        }

        [Key]
        public int ID { get; set; }

        public string NAME { get; set; }

        public virtual ICollection<PRODUCT> PRODUCTS { get; set; }

    }
}
