using MK.Accountancy.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MK.Accountancy.Permissions;

public class AccountancyPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var localizePrefix = "Permission";
        var mainGroup = context.AddGroup(AccountancyPermissions.GroupName, L($"{localizePrefix}:{AccountancyPermissions.GroupName}"));
        //
        var bank = mainGroup.AddPermission(AccountancyPermissions.Bank_.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.Bank_)}"));

        bank.AddChild(AccountancyPermissions.Bank_.Create, 
            L($"{localizePrefix}:{nameof(AccountancyPermissions.Bank_)}{AccountancyPermissions.CreateConst}"));
        bank.AddChild(AccountancyPermissions.Bank_.Update, L($"{localizePrefix}:{nameof(AccountancyPermissions.Bank_)}{AccountancyPermissions.UpdateConst}"));
        bank.AddChild(AccountancyPermissions.Bank_.Delete, L($"{localizePrefix}:{nameof(AccountancyPermissions.Bank_)}{AccountancyPermissions.DeleteConst}"));
        bank.AddChild(AccountancyPermissions.Bank_.Transaction, L($"{localizePrefix}:{nameof(AccountancyPermissions.Bank_)}{AccountancyPermissions.TransactionConst}"));
        //
        var bankAccount = mainGroup.AddPermission(AccountancyPermissions.BankAccount.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.BankAccount)}"));
        bankAccount.AddChild(AccountancyPermissions.BankAccount.Create, L($"{localizePrefix}:{nameof(AccountancyPermissions.BankAccount)}{AccountancyPermissions.CreateConst}"));
        bankAccount.AddChild(AccountancyPermissions.BankAccount.Update, L($"{localizePrefix}:{nameof(AccountancyPermissions.BankAccount)}{AccountancyPermissions.UpdateConst}"));
        bankAccount.AddChild(AccountancyPermissions.BankAccount.Delete, L($"{localizePrefix}:{nameof(AccountancyPermissions.BankAccount)}{AccountancyPermissions.DeleteConst}"));
        bankAccount.AddChild(AccountancyPermissions.BankAccount.Transaction, L($"{localizePrefix}:{nameof(AccountancyPermissions.BankAccount)}{AccountancyPermissions.TransactionConst}"));
        //
        var bankDepartment = mainGroup.AddPermission(AccountancyPermissions.BankDepartment.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.BankDepartment)}"));
        bankDepartment.AddChild(AccountancyPermissions.BankDepartment.Create, L($"{localizePrefix}:{nameof(AccountancyPermissions.BankDepartment)}{AccountancyPermissions.CreateConst}"));
        bankDepartment.AddChild(AccountancyPermissions.BankDepartment.Update, L($"{localizePrefix}:{nameof(AccountancyPermissions.BankDepartment)}{AccountancyPermissions.UpdateConst}"));
        bankDepartment.AddChild(AccountancyPermissions.BankDepartment.Delete, L($"{localizePrefix}:{nameof(AccountancyPermissions.BankDepartment)}{AccountancyPermissions.DeleteConst}"));
        //
        var unit = mainGroup.AddPermission(AccountancyPermissions.Unit.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.Unit)}"));
        unit.AddChild(AccountancyPermissions.Unit.Create, L($"{localizePrefix}:{nameof(AccountancyPermissions.Unit)}{AccountancyPermissions.CreateConst}"));
        unit.AddChild(AccountancyPermissions.Unit.Update, L($"{localizePrefix}:{nameof(AccountancyPermissions.Unit)}{AccountancyPermissions.UpdateConst}"));
        unit.AddChild(AccountancyPermissions.Unit.Delete, L($"{localizePrefix}:{nameof(AccountancyPermissions.Unit)}{AccountancyPermissions.DeleteConst}"));
        //
        var current = mainGroup.AddPermission(AccountancyPermissions.Current.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.Current)}"));
        current.AddChild(AccountancyPermissions.Current.Create, L($"{localizePrefix}:{nameof(AccountancyPermissions.Current)}{AccountancyPermissions.CreateConst}"));
        current.AddChild(AccountancyPermissions.Current.Update, L($"{localizePrefix}:{nameof(AccountancyPermissions.Current)}{AccountancyPermissions.UpdateConst}"));
        current.AddChild(AccountancyPermissions.Current.Delete, L($"{localizePrefix}:{nameof(AccountancyPermissions.Current)}{AccountancyPermissions.DeleteConst}"));
        current.AddChild(AccountancyPermissions.Current.Transaction, L($"{localizePrefix}:{nameof(AccountancyPermissions.Current)}{AccountancyPermissions.TransactionConst}"));
        //
        var term = mainGroup.AddPermission(AccountancyPermissions.Term.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.Term)}"));
        term.AddChild(AccountancyPermissions.Term.Create, L($"{localizePrefix}:{nameof(AccountancyPermissions.Term)}{AccountancyPermissions.CreateConst}"));
        term.AddChild(AccountancyPermissions.Term.Update, L($"{localizePrefix}:{nameof(AccountancyPermissions.Term)}{AccountancyPermissions.UpdateConst}"));
        term.AddChild(AccountancyPermissions.Term.Delete, L($"{localizePrefix}:{nameof(AccountancyPermissions.Term)}{AccountancyPermissions.DeleteConst}"));
        //
        var invoice = mainGroup.AddPermission(AccountancyPermissions.Invoice.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.Invoice)}"));
        invoice.AddChild(AccountancyPermissions.Invoice.Create, L($"{localizePrefix}:{nameof(AccountancyPermissions.Invoice)}{AccountancyPermissions.CreateConst}"));
        invoice.AddChild(AccountancyPermissions.Invoice.Update, L($"{localizePrefix}:{nameof(AccountancyPermissions.Invoice)}{AccountancyPermissions.UpdateConst}"));
        invoice.AddChild(AccountancyPermissions.Invoice.Delete, L($"{localizePrefix}:{nameof(AccountancyPermissions.Invoice)}{AccountancyPermissions.DeleteConst}"));
        invoice.AddChild(AccountancyPermissions.Invoice.Print, L($"{localizePrefix}:{nameof(AccountancyPermissions.Invoice)}{AccountancyPermissions.PrintConst}"));
        //
        var store = mainGroup.AddPermission(AccountancyPermissions.Store.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.Store)}"));
        store.AddChild(AccountancyPermissions.Store.Create, L($"{localizePrefix}:{nameof(AccountancyPermissions.Store)}{AccountancyPermissions.CreateConst}"));
        store.AddChild(AccountancyPermissions.Store.Update, L($"{localizePrefix}:{nameof(AccountancyPermissions.Store)}{AccountancyPermissions.UpdateConst}"));
        store.AddChild(AccountancyPermissions.Store.Delete, L($"{localizePrefix}:{nameof(AccountancyPermissions.Store)}{AccountancyPermissions.DeleteConst}"));
        store.AddChild(AccountancyPermissions.Store.Transaction, L($"{localizePrefix}:{nameof(AccountancyPermissions.Store)}{AccountancyPermissions.TransactionConst}"));
        //
        var service = mainGroup.AddPermission(AccountancyPermissions.Service.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.Service)}"));
        service.AddChild(AccountancyPermissions.Service.Create, L($"{localizePrefix}:{nameof(AccountancyPermissions.Service)}{AccountancyPermissions.CreateConst}"));
        service.AddChild(AccountancyPermissions.Service.Update, L($"{localizePrefix}:{nameof(AccountancyPermissions.Service)}{AccountancyPermissions.UpdateConst}"));
        service.AddChild(AccountancyPermissions.Service.Delete, L($"{localizePrefix}:{nameof(AccountancyPermissions.Service)}{AccountancyPermissions.DeleteConst}"));
        service.AddChild(AccountancyPermissions.Service.Transaction, L($"{localizePrefix}:{nameof(AccountancyPermissions.Service)}{AccountancyPermissions.TransactionConst}"));
        //
        var safe = mainGroup.AddPermission(AccountancyPermissions.Safe.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.Safe)}"));
        safe.AddChild(AccountancyPermissions.Safe.Create, L($"{localizePrefix}:{nameof(AccountancyPermissions.Safe)}{AccountancyPermissions.CreateConst}"));
        safe.AddChild(AccountancyPermissions.Safe.Update, L($"{localizePrefix}:{nameof(AccountancyPermissions.Safe)}{AccountancyPermissions.UpdateConst}"));
        safe.AddChild(AccountancyPermissions.Safe.Delete, L($"{localizePrefix}:{nameof(AccountancyPermissions.Safe)}{AccountancyPermissions.DeleteConst}"));
        safe.AddChild(AccountancyPermissions.Safe.Transaction, L($"{localizePrefix}:{nameof(AccountancyPermissions.Safe )}{AccountancyPermissions.TransactionConst}"));
        //
        var receipt = mainGroup.AddPermission(AccountancyPermissions.Receipt.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.Receipt)}"));
        receipt.AddChild(AccountancyPermissions.Receipt.Create, L($"{localizePrefix}:{nameof(AccountancyPermissions.Receipt)}{AccountancyPermissions.CreateConst}"));
        receipt.AddChild(AccountancyPermissions.Receipt.Update, L($"{localizePrefix}:{nameof(AccountancyPermissions.Receipt)}{AccountancyPermissions.UpdateConst}"));
        receipt.AddChild(AccountancyPermissions.Receipt.Delete, L($"{localizePrefix}:{nameof(AccountancyPermissions.Receipt)}{AccountancyPermissions.DeleteConst}"));
        receipt.AddChild(AccountancyPermissions.Receipt.Print, L($"{localizePrefix}:{nameof(AccountancyPermissions.Receipt)}{AccountancyPermissions.TransactionConst}"));
        //
        var expense = mainGroup.AddPermission(AccountancyPermissions.Expense.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.Expense)}"));
        expense.AddChild(AccountancyPermissions.Expense.Create, L($"{localizePrefix}:{nameof(AccountancyPermissions.Expense)}{AccountancyPermissions.CreateConst}"));
        expense.AddChild(AccountancyPermissions.Expense.Update, L($"{localizePrefix}:{nameof(AccountancyPermissions.Expense)}{AccountancyPermissions.UpdateConst}"));
        expense.AddChild(AccountancyPermissions.Expense.Delete, L($"{localizePrefix}:{nameof(AccountancyPermissions.Expense)}{AccountancyPermissions.DeleteConst}"));
        expense.AddChild(AccountancyPermissions.Expense.Transaction, L($"{localizePrefix}:{nameof(AccountancyPermissions.Expense)}{AccountancyPermissions.TransactionConst}"));
        //
        var paymentDocument = mainGroup.AddPermission(AccountancyPermissions.PaymentDocument.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.PaymentDocument)}"));
        paymentDocument.AddChild(AccountancyPermissions.PaymentDocument.Create, L($"{localizePrefix}:{nameof(AccountancyPermissions.PaymentDocument)}{AccountancyPermissions.CreateConst}"));
        paymentDocument.AddChild(AccountancyPermissions.PaymentDocument.Update, L($"{localizePrefix}:{nameof(AccountancyPermissions.PaymentDocument)}{AccountancyPermissions.UpdateConst}"));
        paymentDocument.AddChild(AccountancyPermissions.PaymentDocument.Delete, L($"{localizePrefix}:{nameof(AccountancyPermissions.PaymentDocument)}{AccountancyPermissions.DeleteConst}"));
        //
        var specialCode = mainGroup.AddPermission(AccountancyPermissions.SpecialCode.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.SpecialCode)}"));
        specialCode.AddChild(AccountancyPermissions.SpecialCode.Create, L($"{localizePrefix}:{nameof(AccountancyPermissions.SpecialCode)}{AccountancyPermissions.CreateConst}"));
        specialCode.AddChild(AccountancyPermissions.SpecialCode.Update, L($"{localizePrefix}:{nameof(AccountancyPermissions.SpecialCode)}{AccountancyPermissions.UpdateConst}"));
        specialCode.AddChild(AccountancyPermissions.SpecialCode.Delete, L($"{localizePrefix}:{nameof(AccountancyPermissions.SpecialCode)}{AccountancyPermissions.DeleteConst}"));
        //
        var stock = mainGroup.AddPermission(AccountancyPermissions.Stock.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.Stock)}"));
        stock.AddChild(AccountancyPermissions.Stock.Create, L($"{localizePrefix}:{nameof(AccountancyPermissions.Stock)}{AccountancyPermissions.CreateConst}"));
        stock.AddChild(AccountancyPermissions.Stock.Update, L($"{localizePrefix}:{nameof(AccountancyPermissions.Stock)}{AccountancyPermissions.UpdateConst}"));
        stock.AddChild(AccountancyPermissions.Stock.Delete, L($"{localizePrefix}:{nameof(AccountancyPermissions.Stock)}{AccountancyPermissions.DeleteConst}"));
        stock.AddChild(AccountancyPermissions.Stock.Transaction, L($"{localizePrefix}:{nameof(AccountancyPermissions.Stock)}{AccountancyPermissions.TransactionConst}"));
        //
        var department = mainGroup.AddPermission(AccountancyPermissions.Department.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.Department)}"));
        paymentDocument.AddChild(AccountancyPermissions.Department.Create, L($"{localizePrefix}:{nameof(AccountancyPermissions.Department)}{AccountancyPermissions.CreateConst}"));
        paymentDocument.AddChild(AccountancyPermissions.Department.Update, L($"{localizePrefix}:{nameof(AccountancyPermissions.Department)}{AccountancyPermissions.UpdateConst}"));
        paymentDocument.AddChild(AccountancyPermissions.Department.Delete, L($"{localizePrefix}:{nameof(AccountancyPermissions.Department)}{AccountancyPermissions.DeleteConst}"));
        //
        var management = mainGroup.AddPermission(AccountancyPermissions.Management.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.Management)}"));
        //
        var setting = mainGroup.AddPermission(AccountancyPermissions.Setting.Default, L($"{localizePrefix}:{nameof(AccountancyPermissions.Setting)}"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AccountancyResource>(name);
    }
}
