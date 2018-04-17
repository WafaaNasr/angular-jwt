using System;
using System.Collections.Generic;
using System.Linq;
using PtcApi.Model;

namespace ptcApi.Model {
    public class SecurityManager {
        public AppUserAuth ValidateUser (AppUser user) {
            AppUserAuth userAuth = new AppUserAuth ();
            List<AppUserClaim> claims = new List<AppUserClaim> ();

            try {
                using (var db = new PtcDbContext ()) {
                    var authUser = db.Users.FirstOrDefault (usr => usr.UserName.ToLower () == user.UserName && usr.Password == user.Password);
                    if (authUser != null) {
                        userAuth = BuildUserAuthObject (authUser);
                    }
                }
            } catch (System.Exception ex) { // Check which one with ex or not that keeps the Call Stack 
                throw ex;
            }
            return userAuth;
        }
        private AppUserAuth BuildUserAuthObject (AppUser user) {
            AppUserAuth userAuth = new AppUserAuth ();
            List<AppUserClaim> claims = new List<AppUserClaim> ();
            userAuth.UserName = user.UserName;
            userAuth.IsAuthenticated = true;
            userAuth.BearerToken = new Guid ().ToString ();
            claims = GetUserClaims (user);
            foreach (var claim in claims) {
                try {
                    typeof (AppUserAuth).GetProperty (claim.ClaimType).SetValue (userAuth, Convert.ToBoolean (claim.ClaimValue));
                } catch (System.Exception ex) {
                    throw ex;
                }

            }
            return userAuth;
        }

        private List<AppUserClaim> GetUserClaims (AppUser user) {
            List<AppUserClaim> claims = new List<AppUserClaim> ();
            try {
                using (var db = new PtcDbContext ()) {
                    claims = db.UserClaims.Where (claim => claim.UserId == user.UserId).ToList ();
                }
            } catch (System.Exception ex) {
                throw ex;
            }
            return claims;
        }
    }
}