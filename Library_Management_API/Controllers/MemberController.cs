using Library_Management_API.Models;
using Library_Management_API.Repository.implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_API.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMember _member_repository;
        public MemberController(IMember member)
        {
            _member_repository = member;
        }

        // GET: MemberController
        [HttpGet("/api/Member/GetAllMembers")]
        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            var membersList = await _member_repository.GetAllMembers();
            return membersList;
        }

        //public ActionResult Create()
        //{
        //    return View();
        //}

        [HttpPost("/api/Member/InsertMember")]
        public async Task<IActionResult> InsertMember([FromBody] Member memberModel)
        {
            try
            {
                await _member_repository.AddMemberAsync(memberModel);
                return Ok("Member Created");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("/api/Member/GetMemberById/{MemberId}")]
        public async Task<Member> GetMemberById(int MemberId)
        {
            var memberDetails = await _member_repository.GetMemberByIdAsync(MemberId);
            return memberDetails;
        }

        [HttpPut("/api/Member/EditMember")]
        public async Task<IActionResult> EditMember([FromBody] Member memberModel)
        {
            try
            {
                await _member_repository.UpdateMemberAsync(memberModel);
                return Ok("Member is Updated");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("/api/Member/DeleteMember/{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            try
            {
                await _member_repository.DeleteMemberAsync(id);
                return Ok("Member is Deleted");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
