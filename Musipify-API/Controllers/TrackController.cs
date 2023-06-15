using Musipify_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Musipify_API.Content
{
    public class TrackController : ApiController
    {
        #region DECLARATION
        private SQLExecutor executeQuery = new SQLExecutor();
        private HttpResponseMessage response = new HttpResponseMessage();
        DataTable dataTable;
        object content;
        #endregion

        #region GET_SONG_TRACK
        public HttpResponseMessage getSongTrack([FromUri] int song_id, [FromBody] Playlist playlist)
        {
            string[] P1 = { "@P_CMD", "@P_SONG_ID", "@P_ALBUM_ID" };
            string[] V1 = { "GET_SONG_TRACK", song_id.ToString(), playlist.ALBUM_ID.ToString() };
            executeQuery.ExecuteQuery("GET_TRACK", P1, V1, out dataTable);
            if (dataTable.Rows.Count > 0)
            {
                content = new { messageCode = HttpStatusCode.OK, message = executeQuery.message };
            }
            else
            {
                content = new { messageCode = HttpStatusCode.OK, message = executeQuery.message };
            }
            response.Content = new ObjectContent(content.GetType(), content, new JsonMediaTypeFormatter());
            return response;

        }
        #endregion
    }
}
