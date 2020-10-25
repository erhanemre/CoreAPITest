using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreAPI.DataBase.Entities
{
    [Table("TEMP_TABLE_2")]
    public class TempTable2
    {
        [Column("ENTITY_CODE", TypeName = "VARCHAR2(10)")]
        public string EntityCode { get; set; }
        [Column("FLAG", TypeName = "NUMBER(3)")]
        public decimal Flag { get; set; }
    }
}
