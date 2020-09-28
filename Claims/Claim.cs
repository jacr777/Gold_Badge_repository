using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_AC
{
    public class Claim
    {
        public enum TypeOfClaim
        {
            Car = 1,
            Home,
            Theft
        }

        public int ClaimId { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() {}
        public Claim(int claimId,TypeOfClaim claimType,string description,decimal claimAmount,DateTime dateOfIncident,DateTime dateOfClaim,bool isValid)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

    }




}
