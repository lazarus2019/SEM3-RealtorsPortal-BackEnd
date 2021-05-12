using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class ProjectSem3DBContext : DbContext
    {
        public ProjectSem3DBContext()
        {
        }

        public ProjectSem3DBContext(DbContextOptions<ProjectSem3DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdPackage> AdPackages { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CustomerContact> CustomerContacts { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Mailbox> Mailboxes { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberPackageDetail> MemberPackageDetails { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsCategory> NewsCategories { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyImage> PropertyImages { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HRH3A92\\SQLEXPRESS;Database=ProjectSem3DB;user id=sa;password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdPackage>(entity =>
            {
                entity.HasKey(e => e.PackageId);

                entity.ToTable("Ad_Package");

                entity.Property(e => e.PackageId).HasColumnName("Package_Id");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.NameAdPackage)
                    .HasColumnType("text")
                    .HasColumnName("Name_AdPackage");

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.Name).HasColumnType("text");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("City_Id");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.RegionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Region_Id");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK_City_Region");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CountryId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Country_Id");

                entity.Property(e => e.Name).HasColumnType("text");
            });

            modelBuilder.Entity<CustomerContact>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.ToTable("Customer_Contact");

                entity.Property(e => e.ContactId).HasColumnName("Contact_Id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CustomerContent)
                    .HasColumnType("text")
                    .HasColumnName("Customer_Content");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Phone");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CustomerContacts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Customer_Contact_Category");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.InvoiceId).HasColumnName("Invoice_Id");

                entity.Property(e => e.Created).HasColumnType("date");

                entity.Property(e => e.MemberAId).HasColumnName("MemberA_Id");

                entity.Property(e => e.MemberBId).HasColumnName("MemberB_Id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PaymentId).HasColumnName("Payment_Id");

                entity.Property(e => e.PropertyId).HasColumnName("Property_Id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.MemberA)
                    .WithMany(p => p.InvoiceMemberAs)
                    .HasForeignKey(d => d.MemberAId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Member");

                entity.HasOne(d => d.MemberB)
                    .WithMany(p => p.InvoiceMemberBs)
                    .HasForeignKey(d => d.MemberBId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Member1");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Payment");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Property");
            });

            modelBuilder.Entity<Mailbox>(entity =>
            {
                entity.HasKey(e => e.MailId);

                entity.ToTable("Mailbox");

                entity.Property(e => e.MailId).HasColumnName("Mail_Id");

                entity.Property(e => e.FullName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Message).HasColumnType("text");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyId).HasColumnName("Property_Id");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Mailboxes)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK_Mailbox_Property");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Member_Role");
            });

            modelBuilder.Entity<MemberPackageDetail>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.PackageId })
                    .HasName("PK_Account_Package_Detail");

                entity.ToTable("Member_Package_Detail");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.PackageId).HasColumnName("Package_Id");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("Expiry_Date");

                entity.Property(e => e.PaymentId).HasColumnName("Payment_Id");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberPackageDetails)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Package_Detail_Account");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.MemberPackageDetails)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Package_Detail_Ad_Package");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.MemberPackageDetails)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Member_Package_Detail_Payment");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_News_News_Category");
            });

            modelBuilder.Entity<NewsCategory>(entity =>
            {
                entity.ToTable("News_Category");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("Payment_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Payment_Method");

                entity.Property(e => e.PaypalCard)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Paypal_Card");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("text")
                    .HasColumnName("Total_Price");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("Property");

                entity.Property(e => e.PropertyId).HasColumnName("Property_Id");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BedNumber).HasColumnName("Bed_Number");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CityId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("City_Id");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.RoomNumber).HasColumnName("Room_Number");

                entity.Property(e => e.SoldDate)
                    .HasColumnType("date")
                    .HasColumnName("Sold_Date");

                entity.Property(e => e.StatusId).HasColumnName("Status_Id");

                entity.Property(e => e.Title).HasColumnType("text");

                entity.Property(e => e.UploadDate)
                    .HasColumnType("date")
                    .HasColumnName("Upload_Date");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Property_Category");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Property_City");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_Property_Member");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Property_Status");
            });

            modelBuilder.Entity<PropertyImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.ToTable("Property_Image");

                entity.Property(e => e.ImageId).HasColumnName("Image_Id");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Path)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyId).HasColumnName("Property_Id");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.PropertyImages)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK_Property_Image_Property");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region");

                entity.Property(e => e.RegionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Region_Id");

                entity.Property(e => e.CountryId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Country_Id");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Region_Country");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("Setting");

                entity.Property(e => e.SettingId).HasColumnName("Setting_Id");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("Status_Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
