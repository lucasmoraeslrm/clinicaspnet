﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using clinic.Data;
using clinic.Models;
using Microsoft.AspNetCore.Authorization;

namespace clinic.Controllers
{
    public class ConsultasController : Controller
    {
        
       
        private readonly ApplicationDbContext _context;

        public ApplicationDbContext Context => _context;

        public ConsultasController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = Context.Consultas.Include(c => c.Paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await Context.Consultas
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            ViewData["fk_PacienteID"] = new SelectList(Context.Pacientes, "Id", "Convenio");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataHoraConsulta,DataHoraRetorno,Status,ObservacoesAdm,ObservacoesMedica,fk_PacienteID")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                Context.Add(consulta);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["fk_PacienteID"] = new SelectList(Context.Pacientes, "Id", "Nome", consulta.fk_PacienteID);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await Context.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewData["fk_PacienteID"] = new SelectList(Context.Pacientes, "Id", "Nome", consulta.fk_PacienteID);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataHoraConsulta,DataHoraRetorno,Status,ObservacoesAdm,ObservacoesMedica,fk_PacienteID")] Consulta consulta)
        {
            if (id != consulta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Context.Update(consulta);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.Id))
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
            ViewData["fk_PacienteID"] = new SelectList(Context.Pacientes, "Id", "Nome", consulta.fk_PacienteID);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await Context.Consultas
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consulta = await Context.Consultas.FindAsync(id);
            if (consulta != null)
            {
                Context.Consultas.Remove(consulta);
            }

            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
            return Context.Consultas.Any(e => e.Id == id);
        }
    }
}
