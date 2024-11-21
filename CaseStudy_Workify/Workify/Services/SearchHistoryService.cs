using System;
using Workify.Models;
using Workify.Data;
using Microsoft.EntityFrameworkCore;

namespace Workify.Services;

public class SearchHistoryService : ISearchHistoryService
{
    private readonly ApplicationDbContext _context;

    public SearchHistoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddSearchHistoryAsync(SearchHistory searchHistory)
    {
        await _context.SearchHistories.AddAsync(searchHistory);
        await _context.SaveChangesAsync();
    }

    public async Task<List<SearchHistory>> GetSearchHistoryBySeekerIdAsync(int seekerId)
    {
        return await _context.SearchHistories
            .Where(sh => sh.SeekerId == seekerId)
            .ToListAsync();
    }
}
