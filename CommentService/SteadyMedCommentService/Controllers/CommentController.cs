using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SteadyMedCommentService.Models;

//Author: Craig Rainey
//Controller for the Comment service
namespace SteadyMedCommentService.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {

        //Reference to the CommentContext
        private readonly CommentContext _context;

        public CommentController(CommentContext context)
        {
            _context = context;

            if (_context.Comments.Count() == 0)
            {
                _context.Comments.Add(new Comment { CommentId = 111, MedicationPlanId = 333, AuthorId = 777, CommentSection = "This is a test", MessageRead = false });
                _context.SaveChanges();
            }
        }

        //Create or Write a comment
        [HttpPost]
        public void Create(int medicationPlanId)
        {

        }

        //Update the comment
        [HttpPost]
        public void Update(int id, string comment)
        {
        }

        //Retrieve a comment
        [HttpGet("{id}", Name = "GetComment")]
        public IActionResult Get(int Id)
        {
            Comment comment = _context.Comments.FirstOrDefault(c => c.CommentId == Id);
            if (comment == null)
            {
                return NotFound();
            }
            return new ObjectResult(comment);
        }

        //Delete a comment
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
