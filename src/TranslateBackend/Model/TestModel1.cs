namespace TranslateBackend.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class TestModel1
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public string Language { get; set; }

        public bool IsFallback { get; set; }

        public string Html { get; set; }
    }
}
