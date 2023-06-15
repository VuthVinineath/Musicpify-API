using Microsoft.AspNetCore.Mvc;
using Musipify_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.IO;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Musipify_API.Controllers
{

    public class UsersController : ApiController
    {

        #region DECLARATION
        private SQLExecutor executeQuery = new SQLExecutor();
        DataTable dataTable = new DataTable();
        Response response = new Response();
        bool status = false;
        #endregion

        #region GET ACCOUNTS
        [HttpGet]
        [Route("api/users/account")]
        public IHttpActionResult getUserAccout()
        {
            string[] P1 = { "P_CMD", "P_USER_ID"};
            string[] V1 = { "GET_ALL_ACCOUNT",""};   
            executeQuery.ExecuteQuery("GET_USER", P1, V1, out dataTable);
            if (dataTable.Rows.Count > 0)
            {
                return Ok(dataTable);
            }
            else
            {
                return NotFound();
            }
        }
        #endregion

        #region GET_USER_PROFILE
        [HttpGet]
        [Route("api/users/profile")]
        public IHttpActionResult getUserProfile(int user_id)
        {
            string[] P1 = { "P_CMD", "P_USER_ID" };
            string[] V1 = { "GET_USER_PROFILE", user_id.ToString() };
            executeQuery.ExecuteQuery("GET_USER", P1, V1, out dataTable);
            if (dataTable.Rows.Count > 0)
            {
                return Ok(dataTable);
            }
            else
            {
                return NotFound();
            }
        }
        #endregion

        #region CREATE USER
        [HttpPost]
        [Route("api/users/account")]
        public IHttpActionResult newUserAccount([FromBody] UserInformation user)
        {
            string[] P1 = { "P_CMD", "P_USER_ID", "P_EMAIL", "P_PASSWORD", "P_USERNAME", "P_PHOTO" };
            string[] V1 = { "INSERT_ACC", null, user.EMAIL, user.PASSWORD, user.USERNAME, user.PHOTO };
            executeQuery.ExecuteQuery("USER_SETTING", P1, V1, out status);

            if (status == true)
            {
                response.statusCode = "200";
                response.message = "User Created Successful";
                response.data = user;
                return Ok(response);
            }
            else
            {
                return BadRequest("Invalid data");
            }
        }
        #endregion

        #region [PUT] USER ACCOUNT
        [HttpPut]
        [Route("api/users/account")]
        public IHttpActionResult updateUseraAcc(int user_id, [FromBody] User user)
        {
            string[] P2 = { "P_CMD", "P_USER_ID", "P_EMAIL","P_PASSWORD","P_USERNAME","P_PHOTO" };
            string[] V2 = { "UPDATE_USER_ACC", user_id.ToString(), user.EMAIL,"","",""};
            executeQuery.ExecuteQuery("USER_SETTING", P2, V2, out status);

            if (status == true)
            {
                response.statusCode = "200";
                response.message = "Update user Successful";
                response.data = user;
                return Ok(response);
            }
            else
            {
                return BadRequest("Update Failed");
            }
            
        }
        #endregion

        #region [PUT] USER INFORMATIONS
        [HttpPut]
        [Route("api/users/information")]
        public IHttpActionResult updateUseraInfor(int user_id, [FromBody] UserInformation user)
        {
            string[] P1 = { "P_CMD", "P_USER_ID", "P_EMAIL", "P_PASSWORD", "P_USERNAME", "P_ACCOUNT_TYPE", "P_PHOTO" };
            string[] V1 = { "UPDATE_USER_INFO", user_id.ToString(), "", "", user.USERNAME, "", user.PHOTO };
            executeQuery.ExecuteQuery("USER_SETTING", P1, V1, out status);

            if (status == true)
            {
                response.statusCode = "200";
                response.message = "Update User Information Successful";
                response.data = user;
                return Ok(response);
            }
            else
            {
                return BadRequest("Update user information failed");
            }
        }
        #endregion

        //#region GET USER INFORMATION IMAGE
        //[HttpGet]
        //[Route("api/users/information")]
        //public IHttpActionResult getUserAccout(int user_id)
        //{
        //    string[] P1 = { "P_CMD", "P_USER_ID" };
        //    string[] V1 = { "GET_USER_PHOTO", user_id.ToString() };
        //    executeQuery.ExecuteQuery("GET_USER", P1, V1, out dataTable);
        //    string base_path = @"C:\inetpub\wwwroot\Files";
        //    List<UserInformation> user = new List<UserInformation>();
        //    if (dataTable.Rows.Count > 0)
        //    {
        //        user.Add(new UserInformation()
        //        {
        //            USER_ID = int.Parse(dataTable.Rows[0][0].ToString()),
        //            PHOTO = base_path+dataTable.Rows[0][1].ToString(),

        //        });
        //        response.statusCode = "200";
        //        response.message = "Success";
        //        response.data = user;
        //        return Ok(response);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}
        //#endregion
    }
}
