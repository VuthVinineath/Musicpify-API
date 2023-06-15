using Musipify_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Musipify_API.Controllers
{
    public class ArtistsController : ApiController
    {
        #region DECLARATION
        private SQLExecutor executeQuery = new SQLExecutor();
        private HttpResponseMessage response = new HttpResponseMessage();
        DataTable dataTable = new DataTable();
        #endregion

        #region GET SINGLE ARTIST
        [HttpGet]
        [Route("api/artists/artist")]
        public IHttpActionResult getArtist(int artist_id)
        {
            string[] P1 = { "P_CMD", "P_ARTIST_ID", "P_COUNTRY" };
            string[] V1 = { "GET_ARTIST", artist_id.ToString() ,""};
            executeQuery.ExecuteQuery("GET_ARTIST", P1, V1, out dataTable);

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

        #region GET ARTISTS
        [HttpGet]
        [Route("api/artists")]
        public IHttpActionResult getArtists()
        {
            string[] P1 = { "P_CMD", "P_ARTIST_ID","P_COUNTRY" };
            string[] V1 = { "GET_ARTISTS", "" ,""};
            executeQuery.ExecuteQuery("GET_ARTIST", P1, V1, out dataTable);
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

        #region GET ARTISTS
        [HttpGet]
        [Route("api/artists/country")]
        public IHttpActionResult getArtistsByCountry(string country)
        {
            string[] P1 = { "P_CMD", "P_ARTIST_ID","P_COUNTRY" };
            string[] V1 = { "GET_ARTISTS_COUNTRY", "",country };
            executeQuery.ExecuteQuery("GET_ARTIST", P1, V1, out dataTable);
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

        #region GET ARTIST'S ALBUM
        [HttpGet]
        [ActionName("albums")]
        public HttpResponseMessage getArtistAlbum([FromUri] int artist_id)
        {
            DataTable dataTable;
            object content;
            string[] P1 = { "@P_CMD", "@P_ARTIST_ID" };
            string[] V1 = { "GET_ARTIST_ALBUM", artist_id.ToString() };
            executeQuery.ExecuteQuery("GET_ARTIST", P1, V1, out dataTable);

            if (dataTable.Rows.Count > 0)
            {
                content = new { messageCode = HttpStatusCode.OK, message = executeQuery.message, data = dataTable };
            }
            else
            {
                content = new { messageCode = HttpStatusCode.BadRequest, message = executeQuery.message };
            }
            response.Content = new ObjectContent(content.GetType(), content, new JsonMediaTypeFormatter());
            return response;
        }
        #endregion
    }
}
