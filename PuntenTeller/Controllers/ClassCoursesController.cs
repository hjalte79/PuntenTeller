using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PuntenTeller.Data;
using PuntenTeller.Models;

namespace PuntenTeller.Controllers
{
    public class ClassCoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassCoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClassCourses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClassCourse.Include(c => c.course).Include(c => c.schoolClass);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClassCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classCourse = await _context.ClassCourse
                .Include(c => c.course)
                .Include(c => c.schoolClass)
                .FirstOrDefaultAsync(m => m.id == id);
            if (classCourse == null)
            {
                return NotFound();
            }

            return View(classCourse);
        }

        // GET: ClassCourses/Create
        public IActionResult Create()
        {
            ViewData["courseID"] = new SelectList(_context.Course, "id", "name");
            ViewData["schoolClassID"] = new SelectList(_context.SchoolClass, "id", "name");
            return View();
        }

        // POST: ClassCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,schoolClassID,courseID")] ClassCourse classCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["courseID"] = new SelectList(_context.Course, "id", "name", classCourse.courseID);
            ViewData["schoolClassID"] = new SelectList(_context.SchoolClass, "id", "name", classCourse.schoolClassID);
            return View(classCourse);
        }

        // GET: ClassCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classCourse = await _context.ClassCourse.FindAsync(id);
            if (classCourse == null)
            {
                return NotFound();
            }
            ViewData["courseID"] = new SelectList(_context.Course, "id", "name", classCourse.courseID);
            ViewData["schoolClassID"] = new SelectList(_context.SchoolClass, "id", "name", classCourse.schoolClassID);
            return View(classCourse);
        }

        // POST: ClassCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,schoolClassID,courseID")] ClassCourse classCourse)
        {
            if (id != classCourse.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassCourseExists(classCourse.id))
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
            ViewData["courseID"] = new SelectList(_context.Course, "id", "name", classCourse.courseID);
            ViewData["schoolClassID"] = new SelectList(_context.SchoolClass, "id", "name", classCourse.schoolClassID);
            return View(classCourse);
        }

        // GET: ClassCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classCourse = await _context.ClassCourse
                .Include(c => c.course)
                .Include(c => c.schoolClass)
                .FirstOrDefaultAsync(m => m.id == id);
            if (classCourse == null)
            {
                return NotFound();
            }

            return View(classCourse);
        }

        // POST: ClassCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classCourse = await _context.ClassCourse.FindAsync(id);
            _context.ClassCourse.Remove(classCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassCourseExists(int id)
        {
            return _context.ClassCourse.Any(e => e.id == id);
        }
    }
}
