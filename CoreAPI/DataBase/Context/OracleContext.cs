using CoreAPI.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.DataBase.Context
{
    public class OracleContext : DbContext
    {
        public virtual DbSet<TempTable1> TempTable1 { get; set; }
        public virtual DbSet<TempTable2> TempTable2 { get; set; }

        public OracleContext()
        {

        }

        public OracleContext(DbContextOptions<OracleContext> options)
            : base(options)
        {
            this.Database.GetDbConnection().StateChange += Connection_StateChange;

        }

        void Connection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            if (e.CurrentState != ConnectionState.Open)
                return;

            var connection = (Oracle.ManagedDataAccess.Client.OracleConnection)sender;
            Oracle.ManagedDataAccess.Client.OracleGlobalization info = connection.GetSessionInfo();

            info.Sort = "TURKISH_AI";
            info.Comparison = "LINGUISTIC";

            connection.SetSessionInfo(info);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.0.0.4)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=OKDB)));Persist Security Info=True;User Id=AVLOWN;Password=admokdb*1881!;", options => options.UseOracleSQLCompatibility("11"));
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=HOST)(PORT=PORT))(CONNECT_DATA=(SERVICE_NAME=DB)));Persist Security Info=True;User Id=DBUSER;Password=DBPASS;", options => options.UseOracleSQLCompatibility("11"));
                //var lf = new LoggerFactory();
                //lf.AddProvider(new MyLoggerProvider());
                //optionsBuilder.UseLoggerFactory(lf);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TempTable1>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SYS_C00239827");
                entity.HasIndex(e => e.Id).HasName("SYS_C00239827").IsUnique();
            });

            modelBuilder.Entity<TempTable2>(entity =>
            {
                entity.HasKey(e => e.EntityCode).HasName("SYS_C00239830");
                entity.HasIndex(e => e.EntityCode).HasName("SYS_C00239830").IsUnique();
            });
        }
    }
}
