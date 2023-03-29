﻿using System.ComponentModel.DataAnnotations;
using static System.String;

namespace OnlineShop.Models.DTO.PhotoDTOs
{
	public class CreatePhotoDTO
	{
		[Required]
		[Display(Name = "FileName")]
		public string FileName { get; set; } = Empty;

		[Required]
		[Display(Name = "PhotoUrl")]
		public string PhotoUrl { get; set; } = Empty;

		[Required]
		[Display(Name = "ProductId")]
		public int ProductId { get; set; }
	}
}