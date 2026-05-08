using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ToDoList.Data;
using ToDoList.Models.DTOs.Auth;
using ToDoList.Models.DTOs.UsuarioDto;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly AuthService _authService;
        private readonly UsuarioService _usuarioService;

        public AuthController(AppDbContext context, AuthService authService, UsuarioService usuarioService)
        {
            _context = context;
            _authService = authService;
            _usuarioService = usuarioService;
        }

        // GET /api/auth/{id}
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponseDto>> GetById(Guid id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            return usuario is not null ? Ok(usuario) : NotFound();
        }

        // POST /api/auth/register
        [HttpPost("register")]
        public async Task<ActionResult<UsuarioResponseDto>> Post(UsuarioCreateDto dto)
        {
            try
            {
                var novoUsuario = await _usuarioService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = novoUsuario.Id }, novoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST /api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.PasswordHash))
                return Unauthorized(new { message = "E-mail ou senha invalidos." });

            var token = _authService.GerarToken(usuario);

            return Ok(new
            {
                token,
                usuario = new { usuario.Id, usuario.Nome, usuario.Email }
            });
        }

        // PUT /api/auth/perfil  — requer autenticação
        [Authorize]
        [HttpPut("perfil")]
        public async Task<IActionResult> AtualizarPerfil([FromBody] AtualizarPerfilDto dto)
        {
            var idStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(idStr, out var usuarioId))
                return Unauthorized(new { message = "Token invalido." });

            var usuario = await _context.Usuarios.FindAsync(usuarioId);
            if (usuario is null)
                return NotFound(new { message = "Usuario nao encontrado." });

            usuario.Nome = dto.Nome.Trim();

            if (!string.IsNullOrWhiteSpace(dto.NovaSenha))
                usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NovaSenha);

            await _context.SaveChangesAsync();

            return Ok(new { usuario.Id, usuario.Nome, usuario.Email });
        }
    }
}