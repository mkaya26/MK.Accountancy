﻿using Microsoft.EntityFrameworkCore;
using MK.Accountancy.BankAccounts;
using MK.Accountancy.BankDepartments;
using MK.Accountancy.Banks;
using MK.Accountancy.Configurations;
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
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace MK.Accountancy.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class AccountancyDbContext :
    AbpDbContext<AccountancyDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<BankDepartment> BankDepartments { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<Current> Currents { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Expense> Epenses { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<OrganizationParameter> OrganizationParameters { get; set; }
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<Safe> Safes { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<SpecialCode> SpecialCodes { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Term> Terms { get; set; }
    public DbSet<Unit> Units { get; set; }
    public AccountancyDbContext(DbContextOptions<AccountancyDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.ConfigureBank();
        builder.ConfigureBankDepartment();
        builder.ConfigureBankAccount();
        builder.ConfigureUnit();
        builder.ConfigureCurrent();
        builder.ConfigureStore();
        builder.ConfigureTerm();
        builder.ConfigureInvoice();
        builder.ConfigureInvoiceDetail();
        builder.ConfigureOrganizationParameter();
        builder.ConfigureService();
        builder.ConfigureSafe();
        builder.ConfigureReceipt();
        builder.ConfigureReceiptDetail();
        builder.ConfigureExpense();
        builder.ConfigureSpecialCode();
        builder.ConfigureStock();
        builder.ConfigureDepartment();
    }
}
