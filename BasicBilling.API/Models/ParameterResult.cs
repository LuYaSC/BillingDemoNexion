using System;

namespace BasicBilling.API.Models
{
    public class ParameterResult
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public DateTime DateCreation { get; set; }

        public DateTime DateModification { get; set; }

        public string StateDescription { get; set; }

        public bool State { get; set; }
    }
}
