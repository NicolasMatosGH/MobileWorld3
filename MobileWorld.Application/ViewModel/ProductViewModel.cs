using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWorld.Application.ViewModel
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo Marca é obrigatório")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "O campo Modelo é Obrigatório")]
        public string Model { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        [Required(ErrorMessage = "O campo Preço é obrigatório, mesmo que seja zero")]
        public decimal Price { get; set; }
        public DateTime DateRegister { get; set; }
        public string Image { get; set; }
        public int StockQuantity { get; set; }
    }
}
