
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeverManagementSystemMVC.Logger;

namespace SeverManagementSystemMVC.Controllers
{

    public class ServerController : Controller
    {
        private ServerManagementEntities _context;
        private ILogger logger;
        public ServerController(ILogger ilogger)
        {
            _context = new ServerManagementEntities();
            logger = ilogger;
            
        }
        // GET: Server
        public ActionResult Display()
        {

            return View();
        }

        // GET: Server/Details
        public ActionResult Details()
        {
            var serverInfos = _context.spGetSeverInfo();
            logger.Log("Details");

            return View(serverInfos);
        }


        // POST: Server/Save
        [HttpPost]
        public ActionResult Save(string loginId, string password, string username, int serverId)
        {
            var credentials = _context.Credentials.ToList();
            var vpnusers = _context.VPNUsers.ToList();

            var matchingCredential = _context.Credentials.FirstOrDefault(c => c.LoginId == loginId && c.LoginPwd == password
                        && c.ServerID == serverId);

            if (matchingCredential != null)
            {
                var credentialId = matchingCredential.CredentialID;
                var vpnuserID = vpnusers.Where(u => u.VPNUserName == username).First().VPNUSerId;

                if (matchingCredential.Status == false)
                {
                    Usage_Detail UsageDetails = new Usage_Detail();
                    UsageDetails.ServerID = serverId;
                    UsageDetails.CredentialId = credentialId;
                    UsageDetails.VPNUSerId = vpnuserID;
                    matchingCredential.Status = true;
                    _context.SaveChanges();
                    //_context.Credentials.Add(matchingCredential);
                    _context.Usage_Detail.Add(UsageDetails);
                    _context.SaveChanges();

                    var serverInfos = _context.spGetSeverInfo();
                    return Content("success");//200
                }
                else
                {
                    return Content("Please try with other credential.");
                }

            }
            else
            {
                return Content("failed");
            }
        }

    
 


   
    }
}
