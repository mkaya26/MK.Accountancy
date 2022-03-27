using Microsoft.EntityFrameworkCore;
using MK.Accountancy.BankAccounts;
using MK.Accountancy.BankDepartments;
using MK.Accountancy.Banks;
using MK.Accountancy.Consts;
using MK.Accountancy.Currents;
using MK.Accountancy.Departments;
using MK.Accountancy.Expenses;
using MK.Accountancy.Invoices;
using MK.Accountancy.Parameters;
using MK.Accountancy.Receipts;
using MK.Accountancy.Safes;
using MK.Accountancy.Services;
using MK.Accountancy.SpecialCodes;
using MK.Accountancy.Stocks;
using MK.Accountancy.Stores;
using MK.Accountancy.Terms;
using MK.Accountancy.Units;
using System.Data;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace MK.Accountancy.Configurations
{
    public static class AccountancyDbContextModelBuilderExtensions
    {
        public static void ConfigureBank(this ModelBuilder builder)
        {
            builder.Entity<Bank>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "Banks", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties
                b.Property(x => x.Code)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxCodeLength);

                b.Property(x => x.Name)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxNameLength);

                b.Property(x => x.SpecialCodeOneId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeTwoId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                b.Property(x => x.Active)
                .HasColumnType(SqlDbType.Bit.ToString());
                #endregion
                #region Indexs
                b.HasIndex(x => x.Code);
                #endregion
                #region Relations
                b.HasOne(x => x.SpecialCodeOne)
                .WithMany(x => x.SpecialCodeOneBanks)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeTwo)
                .WithMany(x => x.SpecialCodeTwoBanks)
                .OnDelete(DeleteBehavior.NoAction);
                #endregion
            });
        }
        public static void ConfigureBankDepartment(this ModelBuilder builder)
        {
            builder.Entity<BankDepartment>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "BankDepartments", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties
                b.Property(x => x.Code)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxCodeLength);

                b.Property(x => x.Name)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxNameLength);

                b.Property(x => x.BankId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeOneId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeTwoId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                b.Property(x => x.Active)
                .HasColumnType(SqlDbType.Bit.ToString());
                #endregion

                #region Indexs
                b.HasIndex(x => x.Code);
                #endregion

                #region Relations
                b.HasOne(x => x.Bank)
                .WithMany(x => x.BankDepartments)
                .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(x => x.SpecialCodeOne)
                .WithMany(x => x.SpecialCodeOneBankDepartments)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeTwo)
                .WithMany(x => x.SpecialCodeTwoBankDepartments)
                .OnDelete(DeleteBehavior.NoAction);
                #endregion
            });
        }
        public static void ConfigureBankAccount(this ModelBuilder builder)
        {
            builder.Entity<BankAccount>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "BankAccounts", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties
                b.Property(x => x.Code)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxCodeLength);

                b.Property(x => x.Name)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxNameLength);

                b.Property(x => x.BankAccountType)
                .IsRequired()
                .HasColumnType(SqlDbType.TinyInt.ToString());

                b.Property(x => x.AccountId)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(BankAccountConst.MaxAccountNumberLength);

                b.Property(x => x.Iban)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(BankAccountConst.MaxIbanNumberLength);

                b.Property(x => x.BankDepartmentId)
                .IsRequired()
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeOneId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeTwoId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.DepartmentId)
                .IsRequired()
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                b.Property(x => x.Active)
                .HasColumnType(SqlDbType.Bit.ToString());
                #endregion

                #region Indexs
                b.HasIndex(x => x.Code);
                #endregion

                #region Relations
                b.HasOne(x => x.BankDepartment)
                .WithMany(x => x.BankAccounts)
                .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(x => x.SpecialCodeOne)
                .WithMany(x => x.SpecialCodeOneBankAccounts)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeTwo)
                .WithMany(x => x.SpecialCodeTwoBankAccounts)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.Department)
                .WithMany(x => x.BankAccounts)
                .OnDelete(DeleteBehavior.Cascade);
                #endregion
            });
        }
        public static void ConfigureUnit(this ModelBuilder builder)
        {
            builder.Entity<Unit>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "Units", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties
                b.Property(x => x.Code)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxCodeLength);

                b.Property(x => x.Name)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxNameLength);

                b.Property(x => x.SpecialCodeOneId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeTwoId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                b.Property(x => x.Active)
                .HasColumnType(SqlDbType.Bit.ToString());
                #endregion

                #region Indexs
                b.HasIndex(x => x.Code);
                #endregion

                #region Relations
                b.HasOne(x => x.SpecialCodeOne)
                .WithMany(x => x.SpecialCodeOneUnits)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeTwo)
                .WithMany(x => x.SpecialCodeTwoUnits)
                .OnDelete(DeleteBehavior.NoAction);
                #endregion
            });
        }
        public static void ConfigureCurrent(this ModelBuilder builder)
        {
            builder.Entity<Current>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "Currents", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties
                b.Property(x => x.Code)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxCodeLength);

                b.Property(x => x.Name)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxNameLength);

                b.Property(x => x.TaxDepartment)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(CurrentConst.MaxTaxOfficeLength);

                b.Property(x => x.TaxNumber)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(CurrentConst.MaxTaxNumberLength);

                b.Property(x => x.Telephone)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxTelephoneLength);

                b.Property(x => x.Address)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxAddressLength);

                b.Property(x => x.SpecialCodeOneId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeTwoId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                b.Property(x => x.Active)
                .HasColumnType(SqlDbType.Bit.ToString());
                #endregion

                #region Indexs
                b.HasIndex(x => x.Code);
                #endregion

                #region Relations
                b.HasOne(x => x.SpecialCodeOne)
                .WithMany(x => x.SpecialCodeOneCurrents)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeTwo)
                .WithMany(x => x.SpecialCodeTwoCurrents)
                .OnDelete(DeleteBehavior.NoAction);
                #endregion
            });
        }
        public static void ConfigureStore(this ModelBuilder builder)
        {
            builder.Entity<Store>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "Stores", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties
                b.Property(x => x.Code)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxCodeLength);

                b.Property(x => x.Name)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxNameLength);

                b.Property(x => x.DepartmentId)
                .IsRequired()
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeOneId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeTwoId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                b.Property(x => x.Active)
                .HasColumnType(SqlDbType.Bit.ToString());
                #endregion

                #region Indexs
                b.HasIndex(x => x.Code);
                #endregion

                #region Relations
                b.HasOne(x => x.SpecialCodeOne)
                .WithMany(x => x.SpecialCodeOneStores)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeTwo)
                .WithMany(x => x.SpecialCodeTwoStores)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.Department)
                .WithMany(x => x.Stores)
                .OnDelete(DeleteBehavior.Cascade);
                #endregion
            });
        }
        public static void ConfigureTerm(this ModelBuilder builder)
        {
            builder.Entity<Term>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "Terms", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties
                b.Property(x => x.Code)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxCodeLength);

                b.Property(x => x.Name)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxNameLength);

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                b.Property(x => x.Active)
                .HasColumnType(SqlDbType.Bit.ToString());
                #endregion

                #region Indexs
                b.HasIndex(x => x.Code);
                #endregion

                #region Relations

                #endregion
            });
        }
        public static void ConfigureInvoice(this ModelBuilder builder)
        {
            builder.Entity<Invoice>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "Invoices", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties

                b.Property(x => x.InvoiceType)
                .IsRequired()
                .HasColumnType(SqlDbType.TinyInt.ToString());

                b.Property(x => x.InvoiceNumber)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(InvoiceConst.MaxInvoiceNumberLength);

                b.Property(x => x.InvoiceDate)
                .IsRequired()
                .HasColumnType(SqlDbType.Date.ToString());

                b.Property(x => x.GrandTotal)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.DiscountTotal)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.SubTotal)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.TaxAmount)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.Netamount)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.MovementNumber)
                .IsRequired()
                .HasColumnType(SqlDbType.Int.ToString());

                b.Property(x => x.CurrentId)
                .IsRequired()
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeOneId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeTwoId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.DepartmentId)
                .IsRequired()
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.TermId)
                .IsRequired()
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                b.Property(x => x.Active)
                .HasColumnType(SqlDbType.Bit.ToString());
                #endregion

                #region Indexs
                b.HasIndex(x => x.InvoiceNumber);
                #endregion

                #region Relations
                b.HasOne(x => x.Current)
                                .WithMany(x => x.Invoices)
                                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeOne)
                .WithMany(x => x.SpecialCodeOneInvoices)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeTwo)
                .WithMany(x => x.SpecialCodeTwoInvoices)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.Department)
                .WithMany(x => x.Invoices)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.Term)
                .WithMany(x => x.Invoices)
                .OnDelete(DeleteBehavior.NoAction);

                #endregion
            });
        }
        public static void ConfigureInvoiceDetail(this ModelBuilder builder)
        {
            builder.Entity<InvoiceDetail>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "InvoiceDetails", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties

                b.Property(x => x.InvoiceId)
                .IsRequired()
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.InvoiceDetailType)
                .IsRequired()
                .HasColumnType(SqlDbType.TinyInt.ToString());

                b.Property(x => x.StockId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.ServiceId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.StoryId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.ExpenseId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.Quantity)
                .IsRequired()
                .HasColumnType(SqlDbType.Decimal.ToString());

                b.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.GrossAmount)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.DiscountAmount)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.GrossAmount)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.NetTotal)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.SubTotal)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.TaxRate)
                .IsRequired()
                .HasColumnType(SqlDbType.Int.ToString());

                b.Property(x => x.TaxTotal)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                #endregion

                #region Indexs
                #endregion

                #region Relations
                b.HasOne(x => x.Invoice)
                                .WithMany(x => x.InvoiceDetails)
                                .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(x => x.Stock)
                .WithMany(x => x.InvoiceDetails)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.Service)
                .WithMany(x => x.InvoiceDetails)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.Expense)
                .WithMany(x => x.InvoiceDetails)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.Store)
                .WithMany(x => x.InvoiceDetails)
                .OnDelete(DeleteBehavior.NoAction);

                #endregion
            });
        }
        public static void ConfigureOrganizationParameter(this ModelBuilder builder)
        {
            builder.Entity<OrganizationParameter>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "OrganizationParameters", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties

                b.Property(x => x.UserId)
                .IsRequired()
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.StoryId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.DepartmentId)
                .IsRequired()
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.TermId)
                .IsRequired()
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                #endregion

                #region Indexs
                #endregion

                #region Relations
                b.HasOne(x => x.Store)
                                .WithMany(x => x.OrganizationParameters)
                                .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(x => x.Term)
                .WithMany(x => x.OrganizationParameters)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.Department)
                .WithMany(x => x.OrganizationParameters)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<OrganizationParameter>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

                #endregion
            });
        }
        public static void ConfigureService(this ModelBuilder builder)
        {
            builder.Entity<Service>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "Services", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties

                b.Property(x => x.Code)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxCodeLength);

                b.Property(x => x.Name)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxNameLength);

                b.Property(x => x.Barcode)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxBarcodeLength);

                b.Property(x => x.TaxRate)
                .IsRequired()
                .HasColumnType(SqlDbType.Int.ToString());

                b.Property(x => x.UnitId)
                .IsRequired()
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.SpecialCodeOneId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeTwoId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                b.Property(x => x.Active)
                .HasColumnType(SqlDbType.Bit.ToString());

                #endregion

                #region Indexs
                b.HasIndex(x => x.Code);
                b.HasIndex(x => x.Barcode);
                #endregion

                #region Relations
                b.HasOne(x => x.Unit)
                                .WithMany(x => x.Services)
                                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeOne)
.WithMany(x => x.SpecialCodeOneServices)
.OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeTwo)
                .WithMany(x => x.SpecialCodeTwoServices)
                .OnDelete(DeleteBehavior.NoAction);

                #endregion
            });
        }
        public static void ConfigureSafe(this ModelBuilder builder)
        {
            builder.Entity<Safe>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "Safes", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties

                b.Property(x => x.Code)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxCodeLength);

                b.Property(x => x.Name)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxNameLength);

                b.Property(x => x.DepartmentId)
                .IsRequired()
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeOneId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeTwoId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                b.Property(x => x.Active)
                .HasColumnType(SqlDbType.Bit.ToString());

                #endregion

                #region Indexs
                b.HasIndex(x => x.Code);
                #endregion

                #region Relations
                b.HasOne(x => x.Department)
                                .WithMany(x => x.Safes)
                                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeOne)
.WithMany(x => x.SpecialCodeOneSafes)
.OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeTwo)
                .WithMany(x => x.SpecialCodeTwoSafes)
                .OnDelete(DeleteBehavior.NoAction);

                #endregion
            });
        }
        public static void ConfigureReceipt(this ModelBuilder builder)
        {
            builder.Entity<Receipt>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "Receipts", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties

                b.Property(x => x.ReceiptType)
                .IsRequired()
                .HasColumnType(SqlDbType.TinyInt.ToString());

                b.Property(x => x.BankAccountId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.BankTotal)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.BillTotal)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.CashTotal)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.ChequeTotal)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.CurrentId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.PostTotal)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.ReceiptDate)
                .IsRequired()
                .HasColumnType(SqlDbType.Date.ToString());

                b.Property(x => x.ReceiptNumber)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(ReceiptConst.MaxReceiptLength);

                b.Property(x => x.SafeId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.TermId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.DepartmentId)
                .IsRequired()
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeOneId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeTwoId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                b.Property(x => x.Active)
                .HasColumnType(SqlDbType.Bit.ToString());

                #endregion

                #region Indexs
                b.HasIndex(x => x.ReceiptNumber);
                #endregion

                #region Relations
                b.HasOne(x => x.Department)
                                .WithMany(x => x.Receipts)
                                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeOne)
.WithMany(x => x.SpecialCodeOneReceipts)
.OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeTwo)
                .WithMany(x => x.SpecialCodeTwoReceipts)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.BankAccount)
                .WithMany(x => x.Receipts)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.Safe)
                .WithMany(x => x.Receipts)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.Current)
                .WithMany(x => x.Receipts)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.Term)
                .WithMany(x => x.Receipts)
                .OnDelete(DeleteBehavior.NoAction);
                #endregion
            });
        }
        public static void ConfigureReceiptDetail(this ModelBuilder builder)
        {
            builder.Entity<ReceiptDetail>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "ReceiptDetails", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties

                b.Property(x => x.PaymentType)
                .IsRequired()
                .HasColumnType(SqlDbType.TinyInt.ToString());

                b.Property(x => x.BankAccountId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SafeId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.ChequeAccountNumber)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(ReceiptDetailConst.MaxChequeAccountNumberLength);

                b.Property(x => x.ChequeBankDepartmentId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.ChequeBankId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.DocumentNo)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(ReceiptDetailConst.MaxDocumentNoLength);

                b.Property(x => x.DocumentStatu)
                .IsRequired()
                .HasColumnType(SqlDbType.TinyInt.ToString());

                b.Property(x => x.Endorser)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(ReceiptDetailConst.MaxEndorserLength);

                b.Property(x => x.ExpiryDate)
                .IsRequired()
                .HasColumnType(SqlDbType.Date.ToString());

                b.Property(x => x.MyDocument)
                .HasColumnType(SqlDbType.Bit.ToString());

                b.Property(x => x.Price)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.PrincipalDebtor)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(ReceiptDetailConst.MaxPrincipalDebtorLength);

                b.Property(x => x.ReceiptId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.TrackingNumber)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(ReceiptDetailConst.MaxTrackingNumberLength);

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                #endregion

                #region Indexs
                b.HasIndex(x => x.TrackingNumber);
                #endregion

                #region Relations
                b.HasOne(x => x.Safe)
                                .WithMany(x => x.ReceiptDetails)
                                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.BankAccount)
.WithMany(x => x.ReceiptDetails)
.OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.ChequeBank)
                .WithMany(x => x.ChequeReceiptDetails)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.ChequeBankDepartment)
                .WithMany(x => x.ChequeReceiptDetails)
                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.Receipt)
                .WithMany(x => x.ReceiptDetails)
                .OnDelete(DeleteBehavior.NoAction);
                #endregion
            });
        }
        public static void ConfigureExpense(this ModelBuilder builder)
        {
            builder.Entity<Expense>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "Expenses", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties

                b.Property(x => x.Active)
                .IsRequired()
                .HasColumnType(SqlDbType.Bit.ToString());

                b.Property(x => x.Barcode)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxBarcodeLength);

                b.Property(x => x.Code)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxCodeLength);

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                b.Property(x => x.Name)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxNameLength);

                b.Property(x => x.SpecialCodeOneId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeTwoId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.TaxRate)
                .IsRequired()
                .HasColumnType(SqlDbType.Int.ToString());

                b.Property(x => x.UnitId)
                .IsRequired()
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                #endregion

                #region Indexs
                b.HasIndex(x => x.Code);
                #endregion

                #region Relations
                b.HasOne(x => x.Unit)
                                .WithMany(x => x.Expenses)
                                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeOne)
.WithMany(x => x.SpecialCodeOneExpenses)
.OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeTwo)
                .WithMany(x => x.SpecialCodeTwoExpenses)
                .OnDelete(DeleteBehavior.NoAction);

                #endregion
            });
        }
        public static void ConfigureSpecialCode(this ModelBuilder builder)
        {
            builder.Entity<SpecialCode>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "SpecialCodes", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties
                b.Property(x => x.Code)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxCodeLength);

                b.Property(x => x.Name)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxNameLength);

                b.Property(x => x.CardType)
                .IsRequired()
                .HasColumnType(SqlDbType.TinyInt.ToString());

                b.Property(x => x.SpecialCodeType)
                .IsRequired()
                .HasColumnType(SqlDbType.TinyInt.ToString());

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                b.Property(x => x.Active)
                .HasColumnType(SqlDbType.Bit.ToString());
                #endregion
                #region Indexs
                b.HasIndex(x => x.Code);
                #endregion
                #region Relations

                #endregion
            });
        }
        public static void ConfigureStock(this ModelBuilder builder)
        {
            builder.Entity<Stock>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "Stocks", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties

                b.Property(x => x.Code)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxCodeLength);

                b.Property(x => x.Name)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxNameLength);

                b.Property(x => x.Barcode)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxBarcodeLength);

                b.Property(x => x.TaxRate)
                .IsRequired()
                .HasColumnType(SqlDbType.Int.ToString());

                b.Property(x => x.UnitId)
                .IsRequired()
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnType(SqlDbType.Money.ToString());

                b.Property(x => x.SpecialCodeOneId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.SpecialCodeTwoId)
                .HasColumnType(SqlDbType.UniqueIdentifier.ToString());

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                b.Property(x => x.Active)
                .HasColumnType(SqlDbType.Bit.ToString());

                #endregion

                #region Indexs
                b.HasIndex(x => x.Code);
                b.HasIndex(x => x.Barcode);
                #endregion

                #region Relations
                b.HasOne(x => x.Unit)
                                .WithMany(x => x.Stocks)
                                .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeOne)
.WithMany(x => x.SpecialCodeOneStocks)
.OnDelete(DeleteBehavior.NoAction);

                b.HasOne(x => x.SpecialCodeTwo)
                .WithMany(x => x.SpecialCodeTwoStocks)
                .OnDelete(DeleteBehavior.NoAction);

                #endregion
            });
        }
        public static void ConfigureDepartment(this ModelBuilder builder)
        {
            builder.Entity<Department>(b =>
            {
                b.ToTable(AccountancyConsts.DbTablePrefix + "Departments", AccountancyConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                                           //
                #region Properties
                b.Property(x => x.Code)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxCodeLength);

                b.Property(x => x.Name)
                .IsRequired()
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MaxNameLength);

                b.Property(x => x.Description)
                .HasColumnType(SqlDbType.VarChar.ToString())
                .HasMaxLength(EntityConst.MacDescriptionLength);

                b.Property(x => x.Active)
                .HasColumnType(SqlDbType.Bit.ToString());
                #endregion
                #region Indexs
                b.HasIndex(x => x.Code);
                #endregion
                #region Relations
                #endregion
            });
        }
    }
}
