using Newtonsoft.Json.Linq;

namespace HyperLove.Services.Facebook
{
    public interface IFacebookAlbums
    {

        void GetAlbums(JObject albumsData);

        FacebookAlbum GetAlbumInfo();
    }
}
