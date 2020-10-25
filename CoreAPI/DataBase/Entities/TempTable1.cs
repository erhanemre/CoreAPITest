using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreAPI.DataBase.Entities
{
    [Table("TEMP_TABLE_1")]
    public class TempTable1
    {
        [Column("ID", TypeName = "NUMBER(11)")]
        public Int64 Id { get; set; }
        [Column("ENTITY_CODE", TypeName = "VARCHAR2(10)")]
        public string EntityCode { get; set; }
    }
}
