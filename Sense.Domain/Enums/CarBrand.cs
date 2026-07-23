using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Domain.Enums
{

    public enum CarBrand
    {
        [Display(Name = "Toyota")]
        Toyota = 1,

        [Display(Name = "Nissan")]
        Nissan = 2,

        [Display(Name = "Mercedes")]
        Mercedes = 3,

        [Display(Name = "BMW")]
        BMW = 4,

        [Display(Name = "Audi")]
        Audi = 5,

        [Display(Name = "Honda")]
        Honda = 6,

        [Display(Name = "Ford")]
        Ford = 7,

        [Display(Name = "Chevrolet")]
        Chevrolet = 8,

        [Display(Name = "Hyundai")]
        Hyundai = 9,

        [Display(Name = "Kia")]
        Kia = 10,

        [Display(Name = "Lexus")]
        Lexus = 11,

        [Display(Name = "Jeep")]
        Jeep = 12,

        [Display(Name = "Mazda")]
        Mazda = 13,

        [Display(Name = "Mitsubishi")]
        Mitsubishi = 14,

        [Display(Name = "Porsche")]
        Porsche = 15,

        [Display(Name = "Rolls Royce")]
        RollsRoyce = 16,

        [Display(Name = "Land Rover")]
        LandRover = 17,

        [Display(Name = "Suzuki")]
        Suzuki = 18,

        [Display(Name = "Tesla")]
        Tesla = 19,

        [Display(Name = "Dodge")]
        Dodge = 20
    }

}
