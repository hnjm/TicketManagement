﻿using FootballTicketManagement.Application.Contracts.Persistance;
using FootballTicketManagement.Domain;
using FootballTicketManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FootballTicketManagement.Persistence.Repositories;

public class TicketRequestRepository : GenericRepository<TicketRequest>, ITicketRequestRepository
{
    public TicketRequestRepository(FmDatabaseContext context) : base(context)
    {
    }

    public async Task<TicketRequest> GetTicketWithDetails(int id)
    {
        var ticketRequests = await _context.TicketRequests
            .Include(q => q.TicketType)
            .FirstOrDefaultAsync(q => q.Id == id);

        return ticketRequests;
    }

    public async Task<List<TicketRequest>> GetTicketWithDetails()
    {
        var ticketRequests = await _context.TicketRequests
            .Include(q => q.TicketType)
            .ToListAsync();

        return ticketRequests;
    }

    public async Task<List<TicketRequest>> GetTicketWithDetails(string userId)
    {
        var ticketRequests = await _context.TicketRequests
            .Where(q => q.RequestingClientId == userId)
            .Include(q => q.TicketType)
            .ToListAsync();

        return ticketRequests;
    }
}