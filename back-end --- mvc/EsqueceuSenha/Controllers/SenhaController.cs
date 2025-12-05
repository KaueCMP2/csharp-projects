using EsqueceuSenha.Data;
using EsqueceuSenha.Models;
using EsqueceuSenha.Services;
using Microsoft.AspNetCore.Mvc;

namespace EsqueceuSenha.controllers
{
    public class SenhaController : Controller
    {
        private readonly AppDbContext _context;
        
        public SenhaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> EnviarCodigoUsu(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                return ViewBag("Prencha todos os campos");
            }

            EmailService emailService = new EmailService(email);
            await emailService.EnviarCodigo();

            var codigo = emailService.CodigoGerado;

            var usuario = _context.Usuarios.FirstOrDefault(u => u.email == email);
            codigoUsuarioSenha codigoSenha = new codigoUsuarioSenha();

            codigoSenha.idUsuario = usuario.id_usuario;
            codigoSenha.codigoSenha = codigo;

            _context.codigoUsuarioSenhas.Add(codigoSenha);
            await _context.SaveChangesAsync();
            return View("Index", "TrocaSenha");            
        }        
    }
}
