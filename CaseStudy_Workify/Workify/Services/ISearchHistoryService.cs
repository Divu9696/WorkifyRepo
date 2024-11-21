using System;
using Workify.Models;

namespace Workify.Services;

public interface ISearchHistoryService
{
    Task AddSearchHistoryAsync(SearchHistory searchHistory);
    Task<List<SearchHistory>> GetSearchHistoryBySeekerIdAsync(int seekerId);
}
