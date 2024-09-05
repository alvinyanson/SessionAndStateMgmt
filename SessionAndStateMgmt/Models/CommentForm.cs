using System.ComponentModel.DataAnnotations;

namespace SessionAndStateMgmt.Models
{
    public class CommentForm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
