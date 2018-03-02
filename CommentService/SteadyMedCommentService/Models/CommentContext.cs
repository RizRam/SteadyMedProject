using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

//Author:Craig Rainey
//Context for the Comments
namespace SteadyMedCommentService.Models
{
    public class CommentContext : DbContext
    {
        //Constructor
        public CommentContext(DbContextOptions<CommentContext> options) : base(options)
        {
        }

        //List of Comments
        public DbSet<Comment> Comments { get; set; }
    }
}
