using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebUser.Common;
using WebUser.Models;
using WebUser.Models.Enums;
using WebUser.ModelsDto;
using WebUser.Repositories.Interfaces;
using WebUser.Services.Interfaces;

namespace WebUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IRelationshipService _relationService;
        private readonly ITransactionProvider _transactionProvider;

        public UserController(IMapper mapper, IUserService userService, IRoleService roleService, 
            IRelationshipService relationService, ITransactionProvider transactionProvider)
        {
            _mapper = mapper;
            _userService = userService;     
            _roleService = roleService;
            _relationService = relationService;
            _transactionProvider = transactionProvider;
        }        

        [HttpGet, Route("{userId:int}")]
        public async Task<IActionResult> GetUserWithRolesAsync(int userId)
        {
            var user = await _userService.GetByIdAsync(userId);
            var result = _mapper.Map<UserReturnDto>(user);
            return Ok(result);
        }

        [HttpGet, Route("list/page/{page:int}")]
        public async Task<IActionResult> GetListAsync(int page, Field? sortedField, bool? isAsc, Field? filterField, string? pattern)
        {
            var result = await _userService.GetPageAsync(page, sortedField, isAsc, filterField, pattern);
            
            return Ok(new Page<UserReturnDto>(_mapper.Map<List<UserReturnDto>>(result.Data), 
                result.TotalCount, result.CurrentPage, result.PageSize));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(NewUserDto newUser)
        {
            if(!await _roleService.RolesExistAsync(newUser.RolesId))
            {
                return BadRequest("Model with nonexistent role");
            }

            var user = _mapper.Map<User>(newUser);
            user.Relations = newUser.RolesId
                .Select(x => new Relationship()
                {
                    UserId = user.Id,
                    RoleId = x
                })
                .ToList();

            await _userService.InsertAsync(user);

            return Ok(new
            {
                UserId = user.Id
            });
        }

        [HttpPut, Route("update")]
        public async Task<IActionResult> UpdateUser(UserDto user)
        {
            var userModel = _mapper.Map<User>(user);
            if (!await _userService.ExistsByIdAsync(userModel.Id))
            {
                BadRequest("There isn't such user");
            }
            var relations = user.Roles.Select(x => new Relationship()
            {
                UserId = user.Id,
                RoleId = x
            }).ToList();

            await _transactionProvider.DoTransaction(async () =>
            {
                await _userService.UpdateAsync(userModel);
                await _relationService.DeleteByUserAsync(userModel.Id);
                await _relationService.InsertAsync(relations);
            });
            
            return Ok("Successfully");
        }

        [HttpPut, Route("addRole")]
        public async Task<IActionResult> AddRelationAsync(NewRelationDto relation)
        {
            var user = await _userService.GetByIdAsync(relation.UserId);
            if (user.Relations.Any(x => x.RoleId == relation.RoleId))
            {
                return BadRequest("User already has this role");
            }
            var relationModel = _mapper.Map<Relationship>(relation);
            await _relationService.InsertAsync(relationModel);

            return Ok("Successfully");
        }

        [HttpDelete, Route("{userId:int}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await _userService.GetByIdAsync(userId);
            if (user == null)
            {
                NotFound("User isn't found");
            }
            await _userService.DeleteUserAsync(user);
            return Ok("Successfully");
        }
    }
}
