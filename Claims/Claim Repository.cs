using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_AC
{
    public class Claim_Repository
    {

        private List<Claim> _listOfClaims = new List<Claim>();

        //Adding a claim
        public void AddClaim(Claim claim)
        {
            _listOfClaims.Add(claim);
        }
        //Read List of claims
        public List<Claim> GetClaims()
        {
            return _listOfClaims;
        }
        //Update
        public bool UpdateClaim(int originalClaim,Claim newClaim)
        {
            //Find the claim
            Claim oldclaim = GetClaimById(originalClaim);
            //Udpdate the claim
            if(oldclaim != null)
            {
                oldclaim.ClaimId = newClaim.ClaimId;
                oldclaim.ClaimType = newClaim.ClaimType ;
                oldclaim.Description = newClaim.Description;
                oldclaim.ClaimAmount = newClaim.ClaimAmount;
                oldclaim.DateOfIncident = newClaim.DateOfIncident;
                oldclaim.DateOfClaim = newClaim.DateOfClaim;
                oldclaim.IsValid = newClaim.IsValid;
                return true;
            }
            else
            {
                return false;
            }
                
        }


        //Delete --- Not needed for this Challenge but wanted to add it as practice
        public bool RemoveClaim(int ClaimId)
        {
            Claim content = GetClaimById(ClaimId);
            if(content == null)
            {
                return false;
            }
            int initialCount = _listOfClaims.Count;
            _listOfClaims.Remove(content);
            if (initialCount > _listOfClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Claim Helper
        public Claim GetClaimById(int claimId)
        {
            foreach (Claim content in _listOfClaims)
            {
                if(content.ClaimId == claimId)
                {
                    return content;
                }

            }
            return null;
        }


    }
}
