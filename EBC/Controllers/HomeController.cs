using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EBC.Models;
using Microsoft.EntityFrameworkCore;

namespace EBC.Controllers;

public class HomeController : Controller
{
    private readonly AppContext _context;

    public HomeController()
    {
        _context = new AppContext();
    }

    // GET: CustomerCRUD
    public async Task<IActionResult> Index()
    {
        return _context.Customers != null ?
                    View(await _context.Customers.ToListAsync()) :
                    Problem("Entity set 'AppContext.Customers'  is null.");
    }

    // GET: CustomerCRUD/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null || _context.Customers == null)
        {
            return NotFound();
        }

        var customer = await _context.Customers
            .FirstOrDefaultAsync(m => m.CustomerId == id);
        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    // GET: CustomerCRUD/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CustomerCRUD/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,Email,Phone")] Customer customer)
    {
        var customerExist = await _context.Customers.FindAsync(customer.CustomerId);
        if (ModelState.IsValid && customerExist == null)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(customer);
    }

    // GET: CustomerCRUD/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null || _context.Customers == null)
        {
            return NotFound();
        }

        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return View(customer);
    }

    // POST: CustomerCRUD/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, [Bind("CustomerId,FirstName,LastName,Email,Phone")] Customer customer)
    {
        if (id != customer.CustomerId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(customer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(customer.CustomerId))
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
        return View(customer);
    }

    // GET: CustomerCRUD/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null || _context.Customers == null)
        {
            return NotFound();
        }

        var customer = await _context.Customers
            .FirstOrDefaultAsync(m => m.CustomerId == id);
        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    // POST: CustomerCRUD/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        if (_context.Customers == null)
        {
            return Problem("Entity set 'AppContext.Customers'  is null.");
        }
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CustomerExists(long id)
    {
        return (_context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

