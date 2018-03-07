using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Author: Craig Rainey
/// Context for the comments. This is the access point for the database that will contain comments
/// </summary>
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
