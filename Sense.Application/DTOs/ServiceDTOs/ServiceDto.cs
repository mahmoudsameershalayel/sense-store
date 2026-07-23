using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.DTOs.ServiceDTOs
{
	public class ServiceDto
	{
		public int Id { get; set; }
		public string TitleAr { get; set; }
		public string SubTitleAr { get; set; }
		public string SummaryAr { get; set; }
        public string DetailsAr { get; set; }
        public string? ImageURL { get; set; }
        public int SortId { get; set; }

		

       

      
	}
}
