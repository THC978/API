using System;
using System.ComponentModel.DataAnnotations;

namespace EquipsLibrary
{
    public class Equips
    {

        public string EquipsId { get; set; }
        [Required]
        public string EquipName { get; set; }
        [Required]
        public string EquipCount { get; set; }
        [Required]
        public string EquipType { get; set; }


    }
}
