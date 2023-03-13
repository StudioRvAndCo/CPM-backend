using CPMApi.Models;
using CPMApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly MembersService _membersService;

    public MembersController(MembersService membersService) => _membersService = membersService;

    [HttpGet, Authorize]
    public async Task<List<Member>> Get() => await _membersService.GetAsync();

    [HttpGet("{id:length(24)}"), Authorize]
    public async Task<ActionResult<Member>> Get(string id)
    {
        var member = await _membersService.GetAsync(id);

        if (member is null)
        {
            return NotFound();
        }

        return member;
    }

    [HttpPost, Authorize]
    public async Task<IActionResult> Post(Member newMember)
    {
        await _membersService.CreateAsync(newMember);

        return CreatedAtAction(nameof(Get), new { id = newMember.Id }, newMember);
    }

    [HttpPut("{id:length(24)}"), Authorize]
    public async Task<IActionResult> Update(string id, Member updatedMember)
    {
        var member = await _membersService.GetAsync(id);

        if (member is null)
        {
            return NotFound();
        }

        updatedMember.Id = member.Id;

        await _membersService.UpdateAsync(id, updatedMember);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}"), Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var member = await _membersService.GetAsync(id);

        if (member is null)
        {
            return NotFound();
        }

        await _membersService.RemoveAsync(id);

        return NoContent();
    }
}