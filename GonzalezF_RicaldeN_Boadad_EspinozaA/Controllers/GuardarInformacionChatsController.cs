using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GonzalezF_RicaldeN_Boadad_EspinozaA.Data;
using GonzalezF_RicaldeN_Boadad_EspinozaA.Models;

namespace GonzalezF_RicaldeN_Boadad_EspinozaA.Controllers
{
    public class GuardarInformacionChatsController : Controller
    {
        private readonly BDDChatContext _context;

        public GuardarInformacionChatsController(BDDChatContext context)
        {
            _context = context;
        }

        // GET: GuardarInformacionChats
        public async Task<IActionResult> Index()
        {
            var bDDChatContext = _context.GuardarInformacionChat.Include(g => g.Usuario);
            return View(await bDDChatContext.ToListAsync());
        }

        // GET: GuardarInformacionChats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guardarInformacionChat = await _context.GuardarInformacionChat
                .Include(g => g.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guardarInformacionChat == null)
            {
                return NotFound();
            }

            return View(guardarInformacionChat);
        }

        // GET: GuardarInformacionChats/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nombre");
            return View();
        }

        // POST: GuardarInformacionChats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Respuesta,Fecha,Proveedor,UsuarioId")] GuardarInformacionChat guardarInformacionChat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guardarInformacionChat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nombre", guardarInformacionChat.UsuarioId);
            return View(guardarInformacionChat);
        }

        // GET: GuardarInformacionChats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guardarInformacionChat = await _context.GuardarInformacionChat.FindAsync(id);
            if (guardarInformacionChat == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nombre", guardarInformacionChat.UsuarioId);
            return View(guardarInformacionChat);
        }

        // POST: GuardarInformacionChats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Respuesta,Fecha,Proveedor,UsuarioId")] GuardarInformacionChat guardarInformacionChat)
        {
            if (id != guardarInformacionChat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guardarInformacionChat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuardarInformacionChatExists(guardarInformacionChat.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Nombre", guardarInformacionChat.UsuarioId);
            return View(guardarInformacionChat);
        }

        // GET: GuardarInformacionChats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guardarInformacionChat = await _context.GuardarInformacionChat
                .Include(g => g.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guardarInformacionChat == null)
            {
                return NotFound();
            }

            return View(guardarInformacionChat);
        }

        // POST: GuardarInformacionChats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guardarInformacionChat = await _context.GuardarInformacionChat.FindAsync(id);
            if (guardarInformacionChat != null)
            {
                _context.GuardarInformacionChat.Remove(guardarInformacionChat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuardarInformacionChatExists(int id)
        {
            return _context.GuardarInformacionChat.Any(e => e.Id == id);
        }
    }
}
