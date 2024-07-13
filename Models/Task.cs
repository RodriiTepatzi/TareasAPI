using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TareasEntrevista.Models
{
	public class TaskApp
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsCompleted { get; set; }
    }
}
