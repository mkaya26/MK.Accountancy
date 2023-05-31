using System;

namespace MK.Accountancy.Permissions;

public static class AccountancyPermissions
{
    public const string GroupName = "Accountancy";
    //
    public const string CreateConst = ".Create";
    public const string UpdateConst = ".Update";
    public const string DeleteConst = ".Delete";
    public const string PrintConst = ".Print";
    public const string TransactionConst = ".Transaction";
    //
    public static class Bank_
    {
        public const string Default = $"{GroupName}.{nameof(Bank_)}";
        //
        public const string Create = Default + CreateConst;
        public const string Update = Default + UpdateConst;
        public const string Delete = Default + DeleteConst;
        public const string Transaction = Default + TransactionConst;
    }
    //
    public static class BankAccount
    {
        public const string Default = $"{GroupName}.{nameof(BankAccount)}";
        //
        public const string Create = Default + CreateConst;
        public const string Update = Default + UpdateConst;
        public const string Delete = Default + DeleteConst;
        public const string Transaction = Default + TransactionConst;
    }
    //
    public static class BankDepartment
    {
        public const string Default = $"{GroupName}.{nameof(BankDepartment)}";
        //
        public const string Create = Default + CreateConst;
        public const string Update = Default + UpdateConst;
        public const string Delete = Default + DeleteConst;
    }
    //
    public static class Unit
    {
        public const string Default = $"{GroupName}.{nameof(Unit)}";
        //
        public const string Create = Default + CreateConst;
        public const string Update = Default + UpdateConst;
        public const string Delete = Default + DeleteConst;
    }
    //
    public static class Current
    {
        public const string Default = $"{GroupName}.{nameof(Current)}";
        //
        public const string Create = Default + CreateConst;
        public const string Update = Default + UpdateConst;
        public const string Delete = Default + DeleteConst;
        public const string Transaction = Default + TransactionConst;
    }
    //
    public static class Term
    {
        public const string Default = $"{GroupName}.{nameof(Term)}";
        //
        public const string Create = Default + CreateConst;
        public const string Update = Default + UpdateConst;
        public const string Delete = Default + DeleteConst;
    }
    //
    public static class Invoice
    {
        public const string Default = $"{GroupName}.{nameof(Invoice)}";
        //
        public const string Create = Default + CreateConst;
        public const string Update = Default + UpdateConst;
        public const string Delete = Default + DeleteConst;
        public const string Print = Default + PrintConst;
    }
    //
    public static class Store
    {
        public const string Default = $"{GroupName}.{nameof(Store)}";
        //
        public const string Create = Default + CreateConst;
        public const string Update = Default + UpdateConst;
        public const string Delete = Default + DeleteConst;
        public const string Transaction = Default + TransactionConst;
    }
    //
    public static class Service
    {
        public const string Default = $"{GroupName}.{nameof(Service)}";
        //
        public const string Create = Default + CreateConst;
        public const string Update = Default + UpdateConst;
        public const string Delete = Default + DeleteConst;
        public const string Transaction = Default + TransactionConst;
    }
    //
    public static class Safe
    {
        public const string Default = $"{GroupName}.{nameof(Safe)}";
        //
        public const string Create = Default + CreateConst;
        public const string Update = Default + UpdateConst;
        public const string Delete = Default + DeleteConst;
        public const string Transaction = Default + TransactionConst;
    }
    //
    public static class Receipt
    {
        public const string Default = $"{GroupName}.{nameof(Receipt)}";
        //
        public const string Create = Default + CreateConst;
        public const string Update = Default + UpdateConst;
        public const string Delete = Default + DeleteConst;
        public const string Print = Default + PrintConst;
    }
    //
    public static class Expense
    {
        public const string Default = $"{GroupName}.{nameof(Expense)}";
        //
        public const string Create = Default + CreateConst;
        public const string Update = Default + UpdateConst;
        public const string Delete = Default + DeleteConst;
        public const string Transaction = Default + TransactionConst;
    }
    //
    public static class PaymentDocument
    {
        public const string Default = $"{GroupName}.{nameof(PaymentDocument)}";
        //
        public const string Create = Default + CreateConst;
        public const string Update = Default + UpdateConst;
        public const string Delete = Default + DeleteConst;
    }
    //
    public static class SpecialCode
    {
        public const string Default = $"{GroupName}.{nameof(SpecialCode)}";
        //
        public const string Create = Default + CreateConst;
        public const string Update = Default + UpdateConst;
        public const string Delete = Default + DeleteConst;
    }
    //
    public static class Stock
    {
        public const string Default = $"{GroupName}.{nameof(Stock)}";
        //
        public const string Create = Default + CreateConst;
        public const string Update = Default + UpdateConst;
        public const string Delete = Default + DeleteConst;
        public const string Transaction = Default + TransactionConst;
    }
    //
    public static class Department
    {
        public const string Default = $"{GroupName}.{nameof(Department)}";
        //
        public const string Create = Default + CreateConst;
        public const string Update = Default + UpdateConst;
        public const string Delete = Default + DeleteConst;
    }
    //
    public static class Management
    {
        public const string Default = $"{GroupName}.{nameof(Management)}";
    }
    //
    public static class Setting
    {
        public const string Default = $"{GroupName}.{nameof(Setting)}";
    }
}
