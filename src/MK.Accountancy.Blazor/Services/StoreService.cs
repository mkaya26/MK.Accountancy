﻿using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.Invoices;
using MK.Accountancy.Parameters;
using MK.Accountancy.Stores;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class StoreService : BaseService<ListStoreDto,SelectStoreDto>,IScopedDependency
    {
        public override void SelectEntity(IEntityDto targetEntity)
        {
            switch (targetEntity)
            {
                case SelectOrganizationParameterDto parameterDto:
                    parameterDto.StoryId = SelectedItem.Id;
                    parameterDto.StoryName = SelectedItem.Name;
                    break;
                    case SelectInvoiceDetailDto invoiceDetailDto:
                    invoiceDetailDto.StoreId = SelectedItem.Id;
                    invoiceDetailDto.StoreCode = SelectedItem.Code;
                    invoiceDetailDto.StoreName = SelectedItem.Name;
                    break;
            }
        }
    }
}