﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Medicine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public ICollection<MedicineReport> MedicineReport { get; set; }
        public ICollection<PrescribedMedicine> PrescribedMedicine { get; set; }
    }
}
