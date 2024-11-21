using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workify.Models;
using Workify.Services;

namespace Workify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchHistoryController : ControllerBase
    {
        private readonly ISearchHistoryService _searchHistoryService;

    public SearchHistoryController(ISearchHistoryService searchHistoryService)
    {
        _searchHistoryService = searchHistoryService;
    }

    [HttpPost]
    public async Task<IActionResult> AddSearchHistory([FromBody] SearchHistory searchHistory)
    {
        await _searchHistoryService.AddSearchHistoryAsync(searchHistory);
        return CreatedAtAction(nameof(GetSearchHistoryBySeekerId), new { seekerId = searchHistory.SeekerId }, searchHistory);
    }

    [HttpGet("seeker/{seekerId}")]
    public async Task<IActionResult> GetSearchHistoryBySeekerId(int seekerId)
    {
        var history = await _searchHistoryService.GetSearchHistoryBySeekerIdAsync(seekerId);
        return Ok(history);
    }
    }
}
