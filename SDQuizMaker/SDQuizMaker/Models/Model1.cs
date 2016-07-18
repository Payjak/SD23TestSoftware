namespace SDQuizMaker.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<tbianswer> tbianswers { get; set; }
        public virtual DbSet<tbinstance> tbinstances { get; set; }
        public virtual DbSet<tbintake> tbintakes { get; set; }
        public virtual DbSet<tbiquestion> tbiquestions { get; set; }
        public virtual DbSet<tbprogram> tbprograms { get; set; }
        public virtual DbSet<tbresponse> tbresponses { get; set; }
        public virtual DbSet<tbresponsedetail> tbresponsedetails { get; set; }
        public virtual DbSet<tbtanswer> tbtanswers { get; set; }
        public virtual DbSet<tbtemplate> tbtemplates { get; set; }
        public virtual DbSet<tbtquestion> tbtquestions { get; set; }
        public virtual DbSet<tbuser> tbusers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbianswer>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<tbinstance>()
                .Property(e => e.ClassID)
                .IsUnicode(false);

            modelBuilder.Entity<tbinstance>()
                .Property(e => e.ClassID)
                .IsUnicode(false);

            modelBuilder.Entity<tbintake>()
                .Property(e => e.ClassID)
                .IsUnicode(false);

            modelBuilder.Entity<tbiquestion>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<tbiquestion>()
                .Property(e => e.Explanation)
                .IsUnicode(false);

            modelBuilder.Entity<tbprogram>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tbresponse>()
                .Property(e => e.Score)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbresponse>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<tbtanswer>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<tbtemplate>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tbtquestion>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<tbtquestion>()
                .Property(e => e.Explanation)
                .IsUnicode(false);

            modelBuilder.Entity<tbuser>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<tbuser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tbuser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tbuser>()
                .Property(e => e.AccessLevel)
                .IsUnicode(false);
        }
    }
}
