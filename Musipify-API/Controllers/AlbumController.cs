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
    public class AlbumController : ApiController
    {
        #region DECLARATION
        private SQLExecutor executeQuery = new SQLExecutor();
        private Response response = new Response();
        DataTable dataTable;
        #endregion

        #region GET_ALBUM
        [HttpGet]
        [Route("api/albums/album")]
        public IHttpActionResult getAlbum(int album_id)
        {
            string[] P1 = { "P_CMD", "P_ALBUM_ID" };
            string[] V1 = { "GET_ALBUM", album_id.ToString() };
            executeQuery.ExecuteQuery("GET_ALBUM", P1, V1, out dataTable);
            if (dataTable.Rows.Count > 0)
            {
                //response.statusCode = "200";
                //response.message = "Successful";
                //response.data = dataTable;
                return Ok(dataTable);
            }
            else
            {
                return NotFound();
            }
        }
        #endregion

        #region GET_ALBUMS
        [HttpGet]
        [Route("api/albums/album")]
        public IHttpActionResult getAlbums()
        {
            string[] P1 = { "P_CMD", "P_ALBUM_ID", "P_ARTIST_ID" };
            string[] V1 = { "GET_ALBUMS", "","" };
            executeQuery.ExecuteQuery("GET_ALBUM", P1, V1, out dataTable);
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

        #region GET_ALBUM_PLAYLIST
        [HttpGet]
        [Route("api/albums/playlist")]
        public IHttpActionResult getAlbumPlaylist(int album_id)
        {
            string[] P1 = { "P_CMD", "P_ALBUM_ID", "P_ARTIST_ID" };
            string[] V1 = { "GET_ALBUM_PLAYLIST", album_id.ToString(),""};
            executeQuery.ExecuteQuery("GET_ALBUM", P1, V1, out dataTable);
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

        #region GET_ALBUM_PLAYLIST
        [HttpGet]
        [Route("api/albums/artist")]
        public IHttpActionResult getAlbumByArtist(int artist_id)
        {
            string[] P1 = { "P_CMD", "P_ALBUM_ID", "P_ARTIST_ID" };
            string[] V1 = { "GET_ALBUM_ARTIST", "",artist_id.ToString() };
            executeQuery.ExecuteQuery("GET_ALBUM", P1, V1, out dataTable);
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

        //#region GET_RELEASE_TODAY
        //[ActionName("release-today")]
        //public HttpResponseMessage getAlbumsReleaseToday()
        //{
        //    string[] P1 = { "@P_CMD", "@P_ALBUM_ID" };
        //    string[] V1 = { "GET_RELEASE_TODAY", "" };
        //    executeQuery.ExecuteQuery("GET_ALBUM", P1, V1, out dataTable);
        //    if (dataTable.Rows.Count > 0)
        //    {
        //        content = new { messageCode = HttpStatusCode.OK, message = executeQuery.message };
        //    }
        //    else
        //    {
        //        content = new { messageCode = HttpStatusCode.BadRequest, message = executeQuery.message };
        //    }
        //    response.Content = new ObjectContent(content.GetType(), content, new JsonMediaTypeFormatter());
        //    return response;
        //}
        //#endregion

        //#region GET_NEW_RELEASE
        //[ActionName("release-week")]
        //public HttpResponseMessage getAlbumsReleaseThisWeek()
        //{
        //    string[] P1 = { "@P_CMD", "@P_ALBUM_ID" };
        //    string[] V1 = { "GET_NEW_RELEASE", "" };
        //    executeQuery.ExecuteQuery("GET_ALBUM", P1, V1, out dataTable);
        //    if (dataTable.Rows.Count > 0)
        //    {
        //        content = new { messageCode = HttpStatusCode.OK, message = executeQuery.message };
        //    }
        //    else
        //    {
        //        content = new { messageCode = HttpStatusCode.BadRequest, message = executeQuery.message };
        //    }
        //    response.Content = new ObjectContent(content.GetType(), content, new JsonMediaTypeFormatter());
        //    return response;
        //}
        //#endregion
    }
}
