﻿using Blazored.LocalStorage;
using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Services.Base;

namespace TicketManagement.Blazor.UI.Services;

public class TicketAllocationService : BaseHttpService, ITicketAllocationService
{
    public TicketAllocationService(IClient client, ILocalStorageService localStorageService) : base(client, localStorageService)
    {
    }
}