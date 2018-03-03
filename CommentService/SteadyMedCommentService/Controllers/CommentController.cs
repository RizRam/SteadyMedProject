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
                _context.Comments.Add(new Comment { CommentId = 111, MedicationPlanId = 333, AuthorId = 777, CommentSection = "This is a test", MessageRead = false, CreatedDate = DateTime.Now });
                _context.Comments.Add(new Comment { CommentId = 222, MedicationPlanId = 333, AuthorId = 777, CommentSection = "This is a test 2", MessageRead = false, CreatedDate = DateTime.Now });
                _context.SaveChanges();
            }
        }

        //Create or Write a comment
        [HttpPost]
        public IActionResult Create([FromBody] Comment addComment)
        {
            if (addComment == null)
            {
                return BadRequest();
            }
            _context.Comments.Add(addComment);
            _context.SaveChanges();

            return CreatedAtRoute("GetComment", new { id = addComment.AuthorId }, addComment);
        }

        //Update the comment
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Comment updateComment)
        {
            if (updateComment == null || updateComment.CommentId != id)
            {
                return BadRequest();
            }

            Comment commentToUpdate = _context.Comments.FirstOrDefault(c => c.CommentId == id);
            if (commentToUpdate == null)
            {
                return NotFound();
            }

            commentToUpdate.CommentSection = updateComment.CommentSection;
            commentToUpdate.ModifiedDate = DateTime.Now;
            _context.Comments.Update(commentToUpdate);
            _context.SaveChanges();
            return new NoContentResult();
        }

        //Retrieve All comments related to a medication plan
        [HttpGet("{id}", Name = "GetMedicationPlanComments")]
        public IActionResult GetMedicationPlanComments(int id)
        {
            var comments = from c in _context.Comments where c.MedicationPlanId == id select c;
            if (comments == null)
            {
                return NotFound();
            }
            return new ObjectResult(comments);
        }

        //Delete a comment
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Comment commentToDelete = _context.Comments.FirstOrDefault(c => c.CommentId == id);
            if (commentToDelete == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(commentToDelete);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
