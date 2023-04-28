﻿using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Receipts;
using System;
using Volo.Abp.DependencyInjection;
using static MK.Blazor.Core.Helpers.Functions;

namespace MK.Accountancy.Blazor.Services
{
    public class ReceiptMoventService : BaseMoventService<SelectReceiptDetailDto>, IScopedDependency
    {
        public ReceiptService ReceiptService { get; set; }
        public AppService AppService { get; set; }

        public override void BeforeUpdate()
        {
            if(ReceiptService.ReceiptType == ReceiptType.Collection || (SelectedItem.DocumentStatu != DocumentStatu.Endorsed && SelectedItem.DocumentStatu != DocumentStatu.Collected))
            {
                DataSource = SelectedItem;
                EditPageVisible = true;
            }
        }

        public override void BeforeInsert()
        {
            DataSource = new SelectReceiptDetailDto
            {
                PaymentType = PaymentType.Cheque,
                ExpiryDate = DateTime.Now.Date,
                TrackingNumber = CreateId()
            };
            EditPageVisible = true;
        }
    }
}
