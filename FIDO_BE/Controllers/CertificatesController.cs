﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FIDO_BE.Data;
using FIDO_BE.Models;

namespace FIDO_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private readonly FIDOContext _context;

        public CertificatesController(FIDOContext context)
        {
            _context = context;
        }

        // GET: api/Certificates
        [HttpGet]
        public IEnumerable<Certificate> GetCertificates()
        {
            return _context.Certificates;
        }

        // GET: api/Certificates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCertificate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var certificate = await _context.Certificates.FindAsync(id);

            if (certificate == null)
            {
                return NotFound();
            }

            return Ok(certificate);
        }

        // PUT: api/Certificates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificate([FromRoute] int id, [FromBody] Certificate certificate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != certificate.CertificateID)
            {
                return BadRequest();
            }

            _context.Entry(certificate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Certificates
        [HttpPost]
        public async Task<IActionResult> PostCertificate([FromBody] Certificate certificate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Certificates.Add(certificate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCertificate", new { id = certificate.CertificateID }, certificate);
        }

        // DELETE: api/Certificates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var certificate = await _context.Certificates.FindAsync(id);
            if (certificate == null)
            {
                return NotFound();
            }

            _context.Certificates.Remove(certificate);
            await _context.SaveChangesAsync();

            return Ok(certificate);
        }

        private bool CertificateExists(int id)
        {
            return _context.Certificates.Any(e => e.CertificateID == id);
        }
    }
}